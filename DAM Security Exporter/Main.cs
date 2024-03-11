using Aprimo.Samples.Forms.SecurityExporter.Helpers;
using Helpers;
using Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Aprimo.SecurityExporter
{
    public partial class Main : Form
    {
        private Dictionary<Guid, string> Classifications = new Dictionary<Guid, string>();
        private Dictionary<string, string> FunctionalPermissions = new Dictionary<string, string>();

        private string ClientId;
        private string UserToken;
        private string UserName;
        private string CustomerUrlBaseName;
        private string PathToXlsx;
        private string ClassificationFilter;

        private string aprimoMoUrl;
        private string aprimoDamUrl;

        private ExcelWorksheet WorksheetClsPermissions;
        private ExcelWorksheet WorksheetDAMFuncPermissions;
        private ExcelWorksheet WorksheetUserGroups;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtPathToXlsx.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                string.Format(@"SecurityExport_{0}.xlsx", DateTime.Now.ToString("yyyyMMdd-hhmmss")));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            try
            {
                ClientId = txtClientId.Text;
                UserToken = txtUserToken.Text;
                UserName = txtUserName.Text;
                CustomerUrlBaseName = txtSubDomain.Text;
                PathToXlsx = txtPathToXlsx.Text;
                ClassificationFilter = txtClassificationFilter.Text;

                aprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", CustomerUrlBaseName);
                aprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", CustomerUrlBaseName);

                if (!cbExportClsPermissions.Checked && !cbExportDAMPermissions.Checked && !cbExportUserGroups.Checked)
                {
                    LogInfo("Nothing is selected for export.");
                    return;
                }
                var accessHelper = new AccessHelper(UserName, UserToken, aprimoMoUrl, ClientId);

                LogInfo("Starting export...");
                LogInfo("Loading all usergroups in Aprimo...");
                UserGroups userGroups = ExtractionHelper.GetAllUserGroups(accessHelper, aprimoMoUrl);
                List<UserGroups.Group> userGroupsDamOnly = userGroups._embedded.group.Where(x => !string.IsNullOrEmpty(x.adamUserId)).ToList();
                FileInfo fileInfo = new FileInfo(PathToXlsx);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    if (cbExportClsPermissions.Checked)
                    {
                        int RowIndex = 1;
                        int ColumnIndex = 1;
                        LogInfo("Loading all classifications in Aprimo DAM...");
                        ExtractionHelper.GetAllClassifications(accessHelper, aprimoDamUrl, ClassificationFilter, Classifications);

                        WorksheetClsPermissions = excelPackage.Workbook.Worksheets.Add("Classification Security");

                        //Header row
                        WorksheetClsPermissions.Cells[RowIndex, ColumnIndex++].Value = "Path";
                        WorksheetClsPermissions.Cells[RowIndex, ColumnIndex++].Value = "Permission Type";
                        WorksheetClsPermissions.Cells[RowIndex, ColumnIndex++].Value = "Break Inheritance";

                        foreach (UserGroups.Group group in userGroupsDamOnly)
                        {
                            WorksheetClsPermissions.Cells[1, ColumnIndex++].Value = group.name;
                        }
                        RowIndex++;

                        int counter = 1;
                        progressBar1.Maximum = Classifications.Count;
                        progressBar1.Step = 1;

                        foreach (Guid classificationId in Classifications.Keys)
                        {
                            LogInfoFormat("Processing classification {0} of {1}", counter++, Classifications.Count);
                            progressBar1.PerformStep();
                            ExtractionHelper.GetClassificationPermission(ref WorksheetClsPermissions, accessHelper, aprimoDamUrl, classificationId, Classifications[classificationId], PermissionType.ClassificationTreePermissions, userGroupsDamOnly, ref RowIndex);
                            ExtractionHelper.GetClassificationPermission(ref WorksheetClsPermissions, accessHelper, aprimoDamUrl, classificationId, Classifications[classificationId], PermissionType.RecordPermissions, userGroupsDamOnly, ref RowIndex);
                            ExtractionHelper.GetClassificationPermission(ref WorksheetClsPermissions, accessHelper, aprimoDamUrl, classificationId, Classifications[classificationId], PermissionType.DownloadPermissions, userGroupsDamOnly, ref RowIndex);
                        }
                        //Postprocessing
                        FormatWorksheet(WorksheetClsPermissions, 4);
                    }
                    if (cbExportUserGroups.Checked)
                    {
                        int RowIndex = 1;
                        int ColumnIndex = 1;
                        WorksheetUserGroups = excelPackage.Workbook.Worksheets.Add("User Groups");

                        //Header row
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "User Group ID";
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "User Group Name";
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "DAM User Group ID";
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "Status";
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "Finance Group";
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "Description";
                        WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "Domain Rights";
                        //WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "Roles";  - todo
                        //WorksheetUserGroups.Cells[RowIndex, ColumnIndex++].Value = "Users" - todo
                        RowIndex++;

                        int counter = 1;
                        progressBar1.Maximum = userGroups._embedded.group.Count;
                        progressBar1.Step = 1;
                        foreach (UserGroups.Group group in userGroups._embedded.group)
                        {
                            LogInfoFormat("Processing user groups {0} of {1}", counter++, userGroups._embedded.group.Count);
                            progressBar1.PerformStep();
                            WorksheetUserGroups.Cells[RowIndex, 1].Value = group.groupId;
                            WorksheetUserGroups.Cells[RowIndex, 2].Value = group.name;
                            WorksheetUserGroups.Cells[RowIndex, 3].Value = group.adamUserId;
                            WorksheetUserGroups.Cells[RowIndex, 4].Value = group.status.Equals("1") ? "Active" : "Inactive";
                            WorksheetUserGroups.Cells[RowIndex, 5].Value = group.financeGroup != null && group.financeGroup.Equals("1") ? "Yes" : "No";
                            WorksheetUserGroups.Cells[RowIndex, 6].Value = group.description;
                            WorksheetUserGroups.Cells[RowIndex, 7].Value = String.Join(";", group.domainRights[0].rights.Select(x => x.functionName).ToList());
                            RowIndex++;
                        }

                        //Postprocessing
                        FormatWorksheet(WorksheetUserGroups, 0);
                    }
                    if (cbExportDAMPermissions.Checked)
                    {
                        int RowIndex = 1;
                        int ColumnIndex = 1;
                        WorksheetDAMFuncPermissions = excelPackage.Workbook.Worksheets.Add("DAM Functional Permissions");
                        ExtractionHelper.GetAllDAMFunctionalPermission(accessHelper, aprimoDamUrl, FunctionalPermissions);

                        //Header row
                        WorksheetDAMFuncPermissions.Cells[RowIndex, ColumnIndex++].Value = "Functional Permission Name";
                        WorksheetDAMFuncPermissions.Cells[RowIndex, ColumnIndex++].Value = "Functional Permission Label";

                        foreach (UserGroups.Group group in userGroupsDamOnly)
                        {
                            WorksheetDAMFuncPermissions.Cells[RowIndex, ColumnIndex++].Value = group.name;
                        }
                        RowIndex++;
                        //First column with permission names
                        foreach (string permissionName in FunctionalPermissions.Keys)
                        {
                            WorksheetDAMFuncPermissions.Cells[RowIndex, 1].Value = permissionName;
                            WorksheetDAMFuncPermissions.Cells[RowIndex++, 2].Value = FunctionalPermissions[permissionName];
                        }

                        int counter = 1;
                        progressBar1.Maximum = userGroupsDamOnly.Count;
                        progressBar1.Step = 1;

                        foreach (UserGroups.Group group in userGroupsDamOnly)
                        {
                            LogInfoFormat("Processing functional permissions for user group {0} of {1}", counter++, userGroupsDamOnly.Count);
                            progressBar1.PerformStep();
                            ExtractionHelper.GetFunctionalPermissionPerUserGroup(ref WorksheetDAMFuncPermissions, accessHelper, aprimoDamUrl, new Guid(group.adamUserId.ToString()), FunctionalPermissions, userGroupsDamOnly);
                            RowIndex++;
                        }
                        //Postprocessing
                        FormatWorksheet(WorksheetDAMFuncPermissions, 3);
                    }

                    excelPackage.Save();
                }

                LogInfo("Export finished.");
                System.Diagnostics.Process.Start(PathToXlsx);
            }
            catch (Exception error)
            {
                LogInfo(error.Message);
                LogInfo("Export unsuccessful.");
                progressBar1.Value = progressBar1.Maximum;
            }
            btnExport.Enabled = true;
        }

        private void LogInfo(string format)
        {
            LogInfoFormat(format);
        }

        private void LogInfoFormat(String format, params object[] args)
        {
            txtLog.AppendText(string.Format(format, args) + Environment.NewLine);
        }

        private void FormatWorksheet(ExcelWorksheet worksheet, int rotateHeaderColumnFromIndex)
        {
            //Set header row in bold, apply background color, apply vertical text orientation
            ExcelRange headerCells = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
            ExcelFill headerFill = headerCells.Style.Fill;
            headerFill.PatternType = ExcelFillStyle.Solid;
            headerFill.BackgroundColor.SetColor(Color.Gray);
            if (rotateHeaderColumnFromIndex > 0)
            {
                worksheet.Cells[1, rotateHeaderColumnFromIndex, 1, worksheet.Dimension.End.Column].Style.TextRotation = 90;
            }

            //Freeze header row
            worksheet.View.FreezePanes(2, 1);

            //Enable filter for header row
            worksheet.Cells[worksheet.Dimension.Address].AutoFilter = true;

            //Autofit column width
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(10, 70);

            //(if a column is completely blank, delete it)
            for (int j = worksheet.Dimension.End.Column; j >= 1; j--)
            {
                bool columnIsBlank = true;
                for (int i = 2; i < worksheet.Dimension.End.Row; i++)
                {
                    if (worksheet.Cells[i, j].Text.Length > 0)
                    {
                        columnIsBlank = false;
                        break;
                    }
                }

                if (columnIsBlank)
                {
                    worksheet.DeleteColumn(j);
                }
                else
                {
                    worksheet.Column(j).Style.WrapText = true;
                }
            }
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
                    wText.Write(txtLog.Text);

                    myStream.Close();
                }
            }
        }
    }
}