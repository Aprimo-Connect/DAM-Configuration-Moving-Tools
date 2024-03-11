using Helpers;
using Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Aprimo.SecurityImporter
{
    public partial class Main : Form
    {
        private string ClientId;
        private string UserToken;
        private string UserName;
        private string Registration;
        private string PathToXlsx;

        private string aprimoMoUrl;
        private string aprimoDamUrl;

        private ExcelWorksheet WorksheetClsPermissions;
        private ExcelWorksheet WorksheetDAMFuncPermissions;
        private ExcelWorksheet WorksheetUserGroups;

        public Main()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            try
            {
                ClientId = tbClientID.Text;
                UserToken = tbUserToken.Text;
                UserName = tbUsername.Text;
                Registration = tbRegistration.Text;
                PathToXlsx = tbPathToXlsx.Text;

                aprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", Registration);
                aprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", Registration);

                if (!cbImportClsPermissions.Checked && !cbImportFuncPermissions.Checked && !cbImportUserGroups.Checked)
                {
                    LogInfo("Nothing is selected for import.");
                    return;
                }

                var accessHelper = new AccessHelper(UserName, UserToken, aprimoMoUrl, ClientId);

                LogInfo("Starting import...");
                LogInfo("Loading all usergroups in Aprimo...");

                UserGroups userGroups = ImportHelper.GetAllUserGroups(accessHelper, aprimoMoUrl);
                List<UserGroups.Group> userGroupsDamOnly = userGroups._embedded.group.Where(x => !string.IsNullOrEmpty(x.adamUserId)).ToList();
                FileInfo fileInfo = new FileInfo(PathToXlsx);

                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    if (cbImportUserGroups.Checked)
                    {
                        LogInfo("Processing all user groups...");
                        WorksheetUserGroups = excelPackage.Workbook.Worksheets["User Groups"];

                        DomainRights allDomainRighs = ImportHelper.GetAllDomainRights(accessHelper, aprimoMoUrl);
                        progressBar1.Maximum = WorksheetUserGroups.Dimension.Rows;
                        progressBar1.Step = 1;


                        for (int i = 2; i <= WorksheetUserGroups.Dimension.Rows; i++)
                        {
                            progressBar1.PerformStep();

                            string userGroupName = WorksheetUserGroups.Cells[i, 2].Text.Trim();
                            UserGroups.Group groupDetails = new UserGroups.Group();
                            groupDetails.name = userGroupName;
                            groupDetails.status = WorksheetUserGroups.Cells[i, 4].Text.Trim().Equals("Active") ? "1" : "0";
                            groupDetails.financeGroup = WorksheetUserGroups.Cells[i, 5].Text.Trim().Equals("Yes") ? "1" : "0";
                            groupDetails.description = WorksheetUserGroups.Cells[i, 6].Text.Trim();
                            groupDetails.domainRights = new List<UserGroups.DomainRight>();
                            groupDetails.domainRights.Add(new UserGroups.DomainRight() { domainId = "1", rights = new List<UserGroups.Right>() });
                            foreach (string domainRightName in WorksheetUserGroups.Cells[i, 7].Text.Trim().Split(';'))
                            {
                                if (allDomainRighs._embedded.domainRight.Any(x => x.name.Equals(domainRightName)))
                                {
                                    var rightPair = allDomainRighs._embedded.domainRight.Where(x => x.name.Equals(domainRightName)).FirstOrDefault();
                                    UserGroups.Right right = new UserGroups.Right() { domainID = "1", functionID = rightPair.functionID, functionName = rightPair.name };
                                    groupDetails.domainRights.FirstOrDefault().rights.Add(right);
                                }
                            }
                            string message = "";

                            //if group exists, update it
                            if (userGroups._embedded.group.Any(x => x.name.Equals(userGroupName)))
                            {
                                LogInfo(string.Format("Editing user group {0}", userGroupName));
                                var existingUserGroup = userGroups._embedded.group.Where(x => x.name.Equals(userGroupName)).FirstOrDefault();
                                groupDetails.groupId = existingUserGroup.groupId;
                                groupDetails.modifiedBy = existingUserGroup.modifiedBy;
                                groupDetails.createdBy = existingUserGroup.createdBy;
                                //TODO - users need to be covered by this so that they wouldn't be removed from group with update
                                //groupDetails.users = existingUserGroup.users;
                                message = ImportHelper.UpdateUserGroup(accessHelper, aprimoMoUrl, groupDetails);

                            }
                            //if group doesn't exist, create it
                            else
                            {
                                LogInfo(string.Format("Importing user group {0}", userGroupName));
                                groupDetails.groupId = "0";
                                var currentUserId = ImportHelper.GetCurrentUser(accessHelper, aprimoMoUrl);
                                groupDetails.modifiedBy = currentUserId;
                                groupDetails.createdBy = currentUserId;
                                message = ImportHelper.CreateUserGroup(accessHelper, aprimoMoUrl, groupDetails);
                            }
                            LogInfo(message);
                        }
                        progressBar1.Value = progressBar1.Maximum;
                    }
                    if (cbImportFuncPermissions.Checked)
                    {
                        LogInfo("Processing all functional permissions...");
                        WorksheetDAMFuncPermissions = excelPackage.Workbook.Worksheets["DAM Functional Permissions"];
                        Dictionary<string, string> FunctionalPermissions = new Dictionary<string, string>();
                        ImportHelper.GetAllDAMFunctionalPermission(accessHelper, aprimoDamUrl, FunctionalPermissions);

                        progressBar1.Maximum = WorksheetDAMFuncPermissions.Dimension.Columns - 2;
                        progressBar1.Step = 1;
                        for (int i = 3; i <= WorksheetDAMFuncPermissions.Dimension.Columns; i++)
                        {
                            progressBar1.PerformStep();
                            string message = "";
                            string userGroupName = WorksheetDAMFuncPermissions.Cells[1, i].Text.Trim();
                            if (userGroupsDamOnly.Any(x => x.name.Equals(userGroupName)) && (userGroupName != "DAM Administrators Group") && (userGroupName != "DAM Operators Group"))
                            {
                                var userGroupId = "";
                                try
                                {
                                    userGroupId = userGroupsDamOnly.Where(x => x.name.Equals(userGroupName)).FirstOrDefault().adamUserId;
                                    LogInfo(string.Format("Updating permissions for user group {0}", userGroupName));
                                    SetFunctionalPermissionsRequest funcPermissionsRequest = new SetFunctionalPermissionsRequest();
                                    funcPermissionsRequest.permissions = new SetFunctionalPermissionsRequest.Permissions();

                                    for (int j = 2; j <= WorksheetDAMFuncPermissions.Dimension.Rows; j++)
                                    {
                                        string permissionLabel = WorksheetDAMFuncPermissions.Cells[j, 2].Text.Trim();
                                        if (FunctionalPermissions.ContainsKey(permissionLabel))
                                        {
                                            SetFunctionalPermissionsRequest.PermissionsAddOrUpdate permissionAddOrUpdate = new SetFunctionalPermissionsRequest.PermissionsAddOrUpdate();
                                            permissionAddOrUpdate.name = FunctionalPermissions[permissionLabel];
                                            permissionAddOrUpdate.value = WorksheetDAMFuncPermissions.Cells[j, i].Text.Trim();
                                            funcPermissionsRequest.permissions.addOrUpdate = new List<SetFunctionalPermissionsRequest.PermissionsAddOrUpdate>();
                                            funcPermissionsRequest.permissions.addOrUpdate.Add(permissionAddOrUpdate);
                                            message = ImportHelper.UpdateFunctionalPermissions(accessHelper, userGroupId, aprimoDamUrl, funcPermissionsRequest);
                                            if (!string.IsNullOrEmpty(message))
                                                LogInfo(message);
                                        }
                                    }
                                    LogInfo(string.Format("Updating permissions for user group {0} finished.", userGroupName));
                                }
                                catch (Exception) { }
                            }
                        }
                        progressBar1.Value = progressBar1.Maximum;
                    }
                    if (cbImportClsPermissions.Checked)
                    {
                        LogInfo("Processing all classification permissions...");
                        WorksheetClsPermissions = excelPackage.Workbook.Worksheets["Classification Security"];

                        progressBar1.Maximum = WorksheetClsPermissions.Dimension.Rows;
                        progressBar1.Step = 1;

                        for (int i = 2; i <= WorksheetClsPermissions.Dimension.Rows; i++)
                        {
                            progressBar1.PerformStep();

                            string namePath = WorksheetClsPermissions.Cells[i, 1].Text.Trim();
                            LogInfo(string.Format("Processing classification {0}", namePath));
                            string classId = ImportHelper.GetClassificationByNamepath(accessHelper, HttpUtility.UrlEncode(namePath), aprimoDamUrl);
                            if (!string.IsNullOrEmpty(classId))
                            {
                                LogInfo(string.Format("Updating permissions for classification {0}", namePath));
                                string permissionType = WorksheetClsPermissions.Cells[i, 2].Text.Trim();
                                var breakInheritance = Convert.ToBoolean(WorksheetClsPermissions.Cells[i, 3].Text.Trim());
                                PermissionsForClassification classificationPermissionsToSet = new PermissionsForClassification() { breakInheritance = breakInheritance, permissions = new List<PermissionsForClassification.Permissions>() };
                                for (int j = 4; j <= WorksheetClsPermissions.Dimension.Columns; j++)
                                {
                                    string groupName = WorksheetClsPermissions.Cells[1, j].Text.Trim();
                                    string permissionValue = WorksheetClsPermissions.Cells[i, j].Text.Trim();
                                    if (permissionValue.Length > 0)
                                    {
                                        if (userGroupsDamOnly.Any(x => x.name.Equals(groupName)) && (groupName != "DAM Administrators Group"))
                                        {
                                            var userGroupId = "";
                                            try
                                            {
                                                userGroupId = userGroupsDamOnly.Where(x => x.name.Equals(groupName)).FirstOrDefault().adamUserId;
                                                classificationPermissionsToSet.permissions.Add(new PermissionsForClassification.Permissions() { userGroupId = userGroupId, accessRight = permissionValue });
                                            }
                                            catch (Exception) { }
                                        }
                                    }
                                }
                                string message = ImportHelper.UpdateClassificationPermissions(accessHelper, classId, aprimoDamUrl, permissionType, classificationPermissionsToSet);
                                LogInfo(message);
                            }
                        }
                        progressBar1.Value = progressBar1.Maximum;
                    }
                }

                LogInfo("Import finished.");
            }
            catch (Exception error)
            {
                LogInfo(error.Message);
                LogInfo("Import unsuccessful.");
                progressBar1.Value = progressBar1.Maximum;

            }
            btnImport.Enabled = true;
        }

        private void LogInfo(string format)
        {
            LogInfoFormat(format);
        }

        private void LogInfoFormat(String format, params object[] args)
        {
            tbLog.AppendText(string.Format(format, args) + Environment.NewLine);
        }

        private void BtnSaveLog_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Log";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter wText = new StreamWriter(myStream);
                    wText.AutoFlush = true;
                    wText.Write(tbLog.Text);

                    myStream.Close();
                }
            }
        }
    }
}
