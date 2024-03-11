using Aprimo.DAM.ConfigurationMover.Helpers;
using Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers;
using Aprimo.DAM.ConfigurationMover.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Aprimo.DAM.ConfigurationMover.ConnectionsDetails;

namespace Aprimo.DAM.ConfigurationMover
{
    public partial class Main : Form
    {
        private Dictionary<Guid, string> Classifications = new Dictionary<Guid, string>();
        private Dictionary<string, string> FunctionalPermissions = new Dictionary<string, string>();
        //export caches
        private List<FieldGroupDTO> allSourceFieldGroups;
        private List<FieldDefinitionDTO> allSourceFieldDefinitions;
        private List<ClassificationDTO> allSourceClassifications;
        private List<LanguageDTO> allSourceLanguages;
        private List<WatermarkDTO> allSourceWatermarks;

        //import caches
        private List<FieldGroupDTO> allDestinationFieldGroups;
        private List<FieldDefinitionDTO> allDestinationFieldDefinitions;
        private List<ClassificationDTO> allDestinationClassifications;
        private List<LanguageDTO> allDestinationLanguages;
        private List<WatermarkDTO> allDestinationWatermarks;
        private string ClientId;
        private string UserToken;
        private string UserName;
        private string Password;
        private string AdamUrl;
        private string Registration;
        private string DirPath;

        public Logger logger;
        public ExportHelper exportHelper;
        public ImportHelper importHelper;
        public Utils utils;

        public ListBox.SelectedObjectCollection settingsFilter;
        public ListBox.SelectedObjectCollection userGroupsForSettingsFilter;

        public Main()
        {
            InitializeComponent();
            logger = new Logger(txtLog);
            exportHelper = new ExportHelper(logger);
            importHelper = new ImportHelper(logger);
            utils = new Utils(logger);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtExportDirPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                string.Format(@"DAMConfigurationExport_{0}", DateTime.Now.ToString("yyyyMMdd-hhmmss")));
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            btnImport.Enabled = false;
            btnReset.Enabled = false;
            try
            {
                ClientId = tbClientIDSource.Text;
                UserToken = tbUserTokenSource.Text;
                UserName = tbUsernameSource.Text;
                Registration = tbRegistrationSource.Text;
                DirPath = txtExportDirPath.Text;

                if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(UserToken) || string.IsNullOrEmpty(UserName)
               || string.IsNullOrEmpty(Registration) || string.IsNullOrEmpty(DirPath))
                {
                    logger.LogInfo("You have to provide environment information before taking any further action");
                    btnExport.Enabled = true;
                    btnImport.Enabled = true;
                    btnReset.Enabled = true;
                    return;
                }

                string aprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", Registration);
                string aprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", Registration);
                AccessHelper accessHelper = new AccessHelper(UserName, UserToken, aprimoMoUrl, ClientId);
                

                logger.LogInfo("Starting export...");

                if (!Directory.Exists(DirPath))
                    Directory.CreateDirectory(DirPath);

                DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);

                if (cbExportFieldGroups.Checked)
                {
                    logger.LogInfo("Loading all field groups in Aprimo DAM...");                    
                    var fieldGroupsToExport = exportHelper.GetFieldGroups(accessHelper, aprimoDamUrl, tbFieldGroupsFilter.Text);
                    exportHelper.ExportFieldGroups(ref fieldGroupsToExport, DirPath, ref progressBar1);
                }
                if (cbExportFieldDefinitions.Checked)
                {
                    var fieldDefinitions = exportHelper.GetFieldDefinitions(accessHelper, aprimoDamUrl, tbFieldDefinitionsFilter.Text).OrderBy(x => x.Name).ToList();
                    //cache all field definitions
                    if (allSourceFieldDefinitions == null && string.IsNullOrEmpty(tbFieldDefinitionsFilter.Text))
                    {
                        allSourceFieldDefinitions = fieldDefinitions;
                    }
                    FillCachesSource(accessHelper, aprimoDamUrl);
                    exportHelper.ExportFieldDefinitions(ref fieldDefinitions, DirPath, ref progressBar1);
                }
                if (cbExportClassifications.Checked)
                {
                    var classifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, tbClassificationFilter.Text).OrderBy(x => x.Name).ToList();
                    //cache all classifications
                    if (allSourceClassifications == null && string.IsNullOrEmpty(tbClassificationFilter.Text))
                    {
                        allSourceClassifications = classifications;
                    }
                    FillCachesSource(accessHelper, aprimoDamUrl);
                    exportHelper.ExportClassifications(classifications, DirPath, ref progressBar1);
                }
                if (cbExportSettingCategories.Checked)
                {
                    //cache all languages
                    if (allSourceLanguages == null)
                    {
                        logger.LogInfo("Filling languages cache...");
                        allSourceLanguages = exportHelper.GetLanguages(accessHelper, aprimoDamUrl);
                        exportHelper.utils.languages = allSourceLanguages;
                    }
                    var settingCategories = exportHelper.GetSettingCategories(accessHelper, aprimoDamUrl, tbSettingCategoriesFilter.Text);
                    exportHelper.ExportSettingCategories(settingCategories, DirPath, ref progressBar1);
                }
                if (cbExportSettingDefinitions.Checked)
                {
                    //cache all languages
                    if (allSourceLanguages == null)
                    {
                        logger.LogInfo("Filling languages cache...");
                        allSourceLanguages = exportHelper.GetLanguages(accessHelper, aprimoDamUrl);
                        exportHelper.utils.languages = allSourceLanguages;
                    }
                    var settingDefinitions = exportHelper.GetSettingDefinitions(accessHelper, aprimoDamUrl, tbSettingDefinitionsFilter.Text);
                    logger.LogInfo("Loading all setting categories in Aprimo DAM...");
                    exportHelper.utils.categories = exportHelper.GetSettingCategories(accessHelper, aprimoDamUrl, "");
                    exportHelper.ExportSettingDefinitions(settingDefinitions, DirPath, ref progressBar1);
                }
                if (cbExportSettings.Checked)
                {
                    var settings = exportHelper.GetSettingValues(accessHelper, aprimoDamUrl, ref settingsFilter, ref userGroupsForSettingsFilter);
                    exportHelper.ExportSettings(settings, DirPath, ref progressBar1);
                }
                if (cbExportFileTypes.Checked)
                {
                    FillCachesSource(accessHelper, aprimoDamUrl);
                    var fileTypes = exportHelper.GetFileTypes(accessHelper, aprimoDamUrl, tbFileTyepsFilter.Text);
                    exportHelper.ExportFileTypes(fileTypes, DirPath, ref progressBar1);
                }
               if (cbExportRules.Checked)
                {
                    var rules = exportHelper.GetRules(accessHelper, aprimoDamUrl, aprimoMoUrl, tbRuleFilter.Text);                    
                    FillCachesSource(accessHelper, aprimoDamUrl);
                    //add watermarks cache
                    exportHelper.utils.watermarks = exportHelper.GetWatermarks(accessHelper, aprimoDamUrl, "");
                    exportHelper.ExportRules(rules, DirPath, ref progressBar1, accessHelper, aprimoMoUrl);
                }


                logger.LogInfo("Export finished.");
            }
            catch (Exception error)
            {
                logger.LogInfo(error.Message);
                logger.LogInfo("Export unsuccessful.");
                progressBar1.Value = progressBar1.Maximum;
            }
            btnExport.Enabled = true;
            btnImport.Enabled = true;
            btnReset.Enabled = true;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            btnExport.Enabled = false;
            btnReset.Enabled = false;

            try
            {
                ClientId = tbClientIDDestination.Text;
                UserToken = tbUserTokenDestination.Text;
                UserName = tbUsernameDestination.Text;
                Registration = tbRegistrationDestination.Text;
                DirPath = tbImportDirPath.Text;

                if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(UserToken) || string.IsNullOrEmpty(UserName)
                || string.IsNullOrEmpty(Registration) || string.IsNullOrEmpty(DirPath))
                {
                    logger.LogInfo("You have to provide environment information before taking any further action");
                    btnExport.Enabled = true;
                    btnImport.Enabled = true;
                    btnReset.Enabled = true;
                    return;
                }

                var aprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", Registration);
                var aprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", Registration);

                var accessHelper = new AccessHelper(UserName, UserToken, aprimoMoUrl, ClientId);

                logger.LogInfo("Starting import...");

                if (!Directory.Exists(DirPath))
                    Directory.CreateDirectory(DirPath);

                DirectoryInfo directoryInfo = new DirectoryInfo(DirPath);

                if (cbImportFieldGroups.Checked)
                {
                    var fieldGroupsFromXML = importHelper.GetFieldGroupsFromXML(DirPath);
                    logger.LogInfo("Loading all field groups from Aprimo DAM destination environment, checking existing field groups...");
                    var allDestinationFieldGroups = exportHelper.GetFieldGroups(accessHelper, aprimoDamUrl, "");
                    importHelper.utils.fieldGroups = allDestinationFieldGroups;
                    var fieldGroupsToImport = fieldGroupsFromXML.Where(x => !allDestinationFieldGroups.Any(y => y.Name.Equals(x.Name))).ToList();
                    logger.LogInfo(string.Format("Importing field groups, total count is {0}", fieldGroupsToImport.Count));
                    importHelper.ImportOrUpdateFieldGroups(accessHelper, aprimoDamUrl, fieldGroupsToImport, ref progressBar1);
                }
                if (cbImportFieldDefinitions.Checked)
                {
                    FillCachesDesination(accessHelper, aprimoDamUrl);
                    var fieldDefintionsFromXML = importHelper.GetFieldDefinitionsFromXML(DirPath);
                    importHelper.ImportOrUpdateFieldDefinitions(accessHelper, aprimoDamUrl, fieldDefintionsFromXML, ref progressBar1);
                    logger.LogInfo("Rebuilding search index...");
                    importHelper.RebuildSearchIndex(accessHelper, aprimoDamUrl);
                }
                if (cbImportClassifications.Checked)
                {
                    var classifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, tbClassificationFilter.Text);
                    //cache all classifications
                    if (allDestinationClassifications == null && string.IsNullOrEmpty(tbClassificationFilter.Text))
                    {
                        allDestinationClassifications = classifications;
                    }
                    FillCachesDesination(accessHelper, aprimoDamUrl);
                    logger.LogInfo("Importing all classifications...");
                    //first import all classifications without setting field values
                    var classificationsFromXML = importHelper.GetClassificationsFromXML(DirPath, false);
                    importHelper.ImportOrUpdateClassifications(accessHelper, aprimoDamUrl, classificationsFromXML, ref progressBar1);
                    if (cbImportClsFieldValues.Checked)
                    {
                        //then set classification field values
                        logger.LogInfo("Refreshing classifications cache...");
                        allDestinationClassifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, "");
                        importHelper.utils.classifications = allDestinationClassifications;
                        logger.LogInfo("Importing classification field values...");
                        classificationsFromXML = importHelper.GetClassificationsFromXML(DirPath, true);
                        importHelper.UpdateClassificationFields(accessHelper, aprimoDamUrl, classificationsFromXML, ref progressBar1);
                    }
                }
                if (cbImportSettingCategories.Checked)
                {
                    //cache all languages
                    if (allDestinationLanguages == null)
                    {
                        logger.LogInfo("Filling languages cache...");
                        allDestinationLanguages = exportHelper.GetLanguages(accessHelper, aprimoDamUrl);                       
                        importHelper.utils.languages = allDestinationLanguages;
                    }
                    logger.LogInfo("Importing setting categories...");
                    var settingCategoriesFromXML = importHelper.GetSettingCategoriesFromXML(DirPath);
                    var allDestinationSettingCategories = exportHelper.GetSettingCategories(accessHelper, aprimoDamUrl, "");
                    importHelper.utils.categories = allDestinationSettingCategories;
                    var settingCategoriesToImport = settingCategoriesFromXML.Where(x => !allDestinationSettingCategories.Any(y => y.Name.Equals(x.Name))).ToList();
                    logger.LogInfo(string.Format("Importing setting categories, total count is {0}", settingCategoriesToImport.Count));
                    importHelper.ImportOrUpdateSettingCategories(accessHelper, aprimoDamUrl, settingCategoriesToImport, ref progressBar1);
                }
                if (cbImportSettingDefinitions.Checked)
                {
                    //cache all languages
                    if (allDestinationLanguages == null)
                    {
                        logger.LogInfo("Filling languages cache...");
                        allDestinationLanguages = exportHelper.GetLanguages(accessHelper, aprimoDamUrl);
                        importHelper.utils.languages = allDestinationLanguages;
                    }
                    //cache all setting categories cache                    
                    logger.LogInfo("Filling user groups cache...");
                    importHelper.utils.categories = exportHelper.GetSettingCategories(accessHelper, aprimoDamUrl, "");
                    logger.LogInfo("Filling setting definitions cache...");
                    importHelper.utils.settingDefinitions = exportHelper.GetSettingDefinitions(accessHelper, aprimoDamUrl, "");
                    logger.LogInfo("Importing setting definitions...");
                    var settingDefinitionsFromXML = importHelper.GetSettingDefinitionsFromXML(DirPath);
                    importHelper.ImportOrUpdateSettingDefinitions(accessHelper, aprimoDamUrl, settingDefinitionsFromXML, ref progressBar1);
                }
                if (cbImportSettings.Checked)
                {
                    //cache all user groups
                    logger.LogInfo("Filling user groups cache...");
                    importHelper.utils.userGroups = exportHelper.GetUserGroups(accessHelper, aprimoDamUrl);
                    logger.LogInfo("Importing setting values...");
                    var settingsFromXML = importHelper.GetSettingsFromXML(DirPath);
                    importHelper.ImportOrUpdateSettings(accessHelper, aprimoDamUrl, settingsFromXML, ref progressBar1);
                }
                if (cbImportFileTypes.Checked)
                {
                    //Cache all destination file types
                    logger.LogInfo("Loading all file types in Aprimo DAM...");
                    importHelper.utils.fileTypes = exportHelper.GetFileTypes(accessHelper, aprimoDamUrl, "");
                    FillCachesDesination(accessHelper, aprimoDamUrl);
                    logger.LogInfo("Importing all file types...");
                    var fileTypesFromXML = importHelper.GetFileTypesFromXML(DirPath);
                    importHelper.ImportOrUpdateFileTypes(accessHelper, aprimoDamUrl, fileTypesFromXML, ref progressBar1);
                }
                if (cbImportRules.Checked)
                {
                    //Cache all destination rules
                    logger.LogInfo("Loading all rules in Aprimo DAM...");
                    importHelper.utils.rules = exportHelper.GetRules(accessHelper, aprimoDamUrl, aprimoMoUrl, "");
                    FillCachesDesination(accessHelper, aprimoDamUrl);
                    importHelper.utils.watermarks = exportHelper.GetWatermarks(accessHelper, aprimoDamUrl, "");
                    logger.LogInfo("Importing all rules...");
                    var rulesFromXML = importHelper.GetRulesFromXML(DirPath);
                    importHelper.ImportOrUpdateRules(accessHelper, aprimoDamUrl, rulesFromXML, ref progressBar1);
                }

                logger.LogInfo("Import finished.");
            }
            catch (Exception error)
            {
                logger.LogInfo(error.Message);
                logger.LogInfo("Import unsuccessful.");
                progressBar1.Value = progressBar1.Maximum;
            }
            btnExport.Enabled = true;
            btnImport.Enabled = true;
            btnReset.Enabled = true;
        }

        private void FillCachesSource(AccessHelper accessHelper, string aprimoDamUrl)
        {
            logger.LogInfo("Loading all field definitions in Aprimo DAM...");
            //cache all field groups
            if (allSourceFieldGroups == null)
            {
                logger.LogInfo("Filling field groups cache...");
                allSourceFieldGroups = exportHelper.GetFieldGroups(accessHelper, aprimoDamUrl, "");
            }
            exportHelper.utils.fieldGroups = allSourceFieldGroups;
            //cache all languages
            if (allSourceLanguages == null)
            {
                logger.LogInfo("Filling languages cache...");
                allSourceLanguages = exportHelper.GetLanguages(accessHelper, aprimoDamUrl);
            }
            exportHelper.utils.languages = allSourceLanguages;
            //cache all classifications
            if (allSourceClassifications == null)
            {
                logger.LogInfo("Filling classification cache...");
                allSourceClassifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, "", true);
            }
            exportHelper.utils.classifications = allSourceClassifications;
            //cache all field definitions
            if (allSourceFieldDefinitions == null)
            {
                logger.LogInfo("Filling field definitions cache...");
                allSourceFieldDefinitions = exportHelper.GetFieldDefinitions(accessHelper, aprimoDamUrl, "");
            }
            exportHelper.utils.fieldDefinitions = allSourceFieldDefinitions;
        }

        private void FillCachesDesination(AccessHelper accessHelper, string aprimoDamUrl)
        {
            logger.LogInfo("Loading all field definitions in Aprimo DAM...");
            //cache all field groups
            if (allDestinationFieldGroups == null)
            {
                logger.LogInfo("Filling field groups cache...");
                allDestinationFieldGroups = exportHelper.GetFieldGroups(accessHelper, aprimoDamUrl, "");
            }
            importHelper.utils.fieldGroups = allDestinationFieldGroups;
            //cache all languages
            if (allDestinationLanguages == null)
            {
                logger.LogInfo("Filling languages cache...");
                allDestinationLanguages = exportHelper.GetLanguages(accessHelper, aprimoDamUrl);
            }
            importHelper.utils.languages = allDestinationLanguages;
            //cache all classifications
            if (allDestinationClassifications == null)
            {
                logger.LogInfo("Filling classification cache...");
                allDestinationClassifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, "", true);
            }
            importHelper.utils.classifications = allDestinationClassifications;
            //cache all field definitions
            if (allDestinationFieldDefinitions == null)
            {
                logger.LogInfo("Filling field definitions cache...");
                allDestinationFieldDefinitions = exportHelper.GetFieldDefinitions(accessHelper, aprimoDamUrl, "");
            }
            importHelper.utils.fieldDefinitions = allDestinationFieldDefinitions;
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            btnImport.Enabled = false;
            btnReset.Enabled = false;
            try
            {
                ClientId = tbClientIDDestination.Text;
                UserToken = tbUserTokenDestination.Text;
                UserName = tbUsernameDestination.Text;
                Registration = tbRegistrationDestination.Text;
                DirPath = tbImportDirPath.Text;

                if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(UserToken) || string.IsNullOrEmpty(UserName)
                    || string.IsNullOrEmpty(Registration) || string.IsNullOrEmpty(DirPath))
                {
                    logger.LogInfo("You have to provide environment information before taking any further action");
                    btnExport.Enabled = true;
                    btnImport.Enabled = true;
                    btnReset.Enabled = true;
                    return;
                }

                string title = "Confirm envirionment reset";
                string message = string.Format("This action will reset the configuration to original configuration of newly provisioned environment. Are you sure you want to delete all custom configuration from environment {0}?", Registration);
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    //do the cleanup of classifications, field defintions, field groups
                    var aprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", Registration);
                    var aprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", Registration);
                    var accessHelper = new AccessHelper(UserName, UserToken, aprimoMoUrl, ClientId);

                    CleanupHelper cleanupHelper = new CleanupHelper(logger);
                    logger.LogInfo("Loading all field groups...");
                    cleanupHelper.fieldGroups = exportHelper.GetFieldGroups(accessHelper, aprimoDamUrl, "");

                    logger.LogInfo("Loading all classifications...");
                    cleanupHelper.classifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, "", true);

                    logger.LogInfo("Loading field definitions...");
                    cleanupHelper.fieldDefinitions = exportHelper.GetFieldDefinitions(accessHelper, aprimoDamUrl, "");

                    cleanupHelper.CleanupAllFieldGroups(accessHelper, aprimoDamUrl, ref progressBar1);
                    cleanupHelper.CleanupAllFieldDefinitions(accessHelper, aprimoDamUrl, ref progressBar1);
                    cleanupHelper.CleanupAllClassifications(accessHelper, aprimoDamUrl, ref progressBar1);
                }
                logger.LogInfo("Environment reset finished.");
            }
            catch (Exception error)
            {
                logger.LogInfo(error.Message);
                logger.LogInfo("Environment reset unsuccessful.");
                progressBar1.Value = progressBar1.Maximum;
            }
            btnExport.Enabled = true;
            btnImport.Enabled = true;
            btnReset.Enabled = true;
        }

        private void CbImportClassifications_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImportClassifications.Checked)
            {
                cbImportClsFieldValues.Visible = true;
            }
            else
            {
                cbImportClsFieldValues.Visible = false;
            }
        }

        private void BtnSelectSettings_Click(object sender, EventArgs e)
        {
            ClientId = tbClientIDSource.Text;
            UserToken = tbUserTokenSource.Text;
            UserName = tbUsernameSource.Text;
            Registration = tbRegistrationSource.Text;
            DirPath = txtExportDirPath.Text;

            if (string.IsNullOrEmpty(ClientId) || string.IsNullOrEmpty(UserToken) || string.IsNullOrEmpty(UserName)
               || string.IsNullOrEmpty(Registration) || string.IsNullOrEmpty(DirPath))
            {
                logger.LogInfo("You have to provide environment information before taking any further action");
                return;
            }


            string aprimoDamUrl = string.Format(@"https://{0}.dam.aprimo.com/api/core", Registration);
            string aprimoMoUrl = string.Format(@"https://{0}.aprimo.com/api", Registration);
            AccessHelper accessHelper = new AccessHelper(UserName, UserToken, aprimoMoUrl, ClientId);            

            SettingsSelector settingsSelector = new SettingsSelector(accessHelper, exportHelper, aprimoDamUrl);
            DialogResult dialogresult = settingsSelector.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                settingsFilter = settingsSelector.lbSelectSettings.SelectedItems;
                userGroupsForSettingsFilter = settingsSelector.lbSelectUserGroups.SelectedItems;
            }

            settingsSelector.Dispose();
        }

        private void BtnSaveConnectionDetailsImport_Click(object sender, EventArgs e)
        {
            ClientId = tbClientIDDestination.Text;
            UserToken = tbUserTokenDestination.Text;
            UserName = tbUsernameDestination.Text;
            Registration = tbRegistrationDestination.Text;
            ConnectionDTO connectionToSave = new ConnectionDTO()
            {
                username = UserName,
                clientId = ClientId,
                token = UserToken,
                registration = Registration,
                name = Registration
            };
            ConnectionsDetails connectionDetails = new ConnectionsDetails(connectionToSave);
            DialogResult dialogresult = connectionDetails.ShowDialog();
            connectionDetails.Dispose();            
        }
        private void BtnSaveConnectionDetailsExport_Click(object sender, EventArgs e)
        {
            ClientId = tbClientIDSource.Text;
            UserToken = tbUserTokenSource.Text;
            UserName = tbUsernameSource.Text;
            Registration = tbRegistrationSource.Text;
            ConnectionDTO connectionToSave = new ConnectionDTO()
            {
                username = UserName,
                clientId = ClientId,
                token = UserToken,
                registration = Registration,
                name = Registration
            };
            ConnectionsDetails connectionDetails = new ConnectionsDetails(connectionToSave);
            DialogResult dialogresult = connectionDetails.ShowDialog();
            connectionDetails.Dispose();
        }

        private void BtnGetConnectionDetailsExport_Click(object sender, EventArgs e)
        {
            ConnectionsDetails connectionDetails = new ConnectionsDetails();
            DialogResult dialogresult = connectionDetails.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                string selectedConnectionName = connectionDetails.cbSelectEnvironment.SelectedValue.ToString();
                ConnectionDTO details = connectionDetails.SavedConnections.Where(c => c.name.Equals(selectedConnectionName)).FirstOrDefault();
                tbClientIDSource.Text = details.clientId;
                tbRegistrationSource.Text = details.registration;
                tbUsernameSource.Text = details.username;
                tbUserTokenSource.Text = details.token;
            }
            connectionDetails.Dispose();
        }

        private void BtnGetConnectionDetailsImport_Click(object sender, EventArgs e)
        {
            ConnectionsDetails connectionDetails = new ConnectionsDetails();
            DialogResult dialogresult = connectionDetails.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                string selectedConnectionName = connectionDetails.cbSelectEnvironment.SelectedValue.ToString();
                ConnectionDTO details = connectionDetails.SavedConnections.Where(c => c.name.Equals(selectedConnectionName)).FirstOrDefault();
                tbClientIDDestination.Text = details.clientId;
                tbRegistrationDestination.Text = details.registration;
                tbUsernameDestination.Text = details.username;
                tbUserTokenDestination.Text = details.token;
            }
            connectionDetails.Dispose();
        }
    }
}