using Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers;
using Aprimo.DAM.ConfigurationMover.Models.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static Aprimo.DAM.ConfigurationMover.Models.DTOs.FileTypeImportDTO;

namespace Aprimo.DAM.ConfigurationMover.Helpers
{
    public class ImportHelper
    {
        public Logger logger;
        public Utils utils;
        public ImportHelper(Logger logger)
        {
            this.logger = logger;
            utils = new Utils(logger);
        }

        /// <summary>
        /// Imports the fieldgroup information from the given xml file. 
        /// </summary>      
        public List<FieldGroupDTO> GetFieldGroupsFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "01_fieldgroups.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing field groups {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all field groups to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetFieldGroups(document);
        }

        /// <summary>
        /// Imports the field definition information from the given xml file. 
        /// </summary>      
        public List<FieldDefinitionDTO> GetFieldDefinitionsFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "02_fieldDefinitions.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing field definitions {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all field definitions to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetFieldDefinitions(document);
        }

        // <summary>
        /// Imports the field definition information from the given xml file. 
        /// </summary>      
        public List<ClassificationImportDTO> GetClassificationsFromXML(string importDirectory, bool provideFields)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "03_classifications.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing classifications {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all classifications to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetClassifications(document, provideFields);
        }

        /// <summary>
        /// Imports the file type information from the given xml file. 
        /// </summary>      
        public List<FileTypeImportDTO> GetFileTypesFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "04_filetypes.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing file types {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all file types to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetFileTypes(document);
        }

        /// <summary>
        /// Imports the setting categories from the given xml file. 
        /// </summary>      
        public List<SettingCategoryDTO> GetSettingCategoriesFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "07_settingCategories.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing setting categories {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all setting categories to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetSettingCategories(document);
        }

        /// <summary>
        /// Imports the setting definitions from the given xml file. 
        /// </summary>      
        public List<SettingDefinitionDTO> GetSettingDefinitionsFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "08_settingDefinitions.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing setting definitions {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all setting definitions to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetSettingDefinitions(document);
        }

        /// <summary>
        /// Imports the settings information from the given xml file. 
        /// </summary>      
        public List<SettingValueDTO> GetSettingsFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "05_settings.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing settings {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all settings to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetSettingValues(document);
        }

        /// <summary>
        /// Imports the rule information from the given xml file. 
        /// </summary>      
        public List<RuleImportDTO> GetRulesFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "06_rules.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing rules {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all rules to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetRules(document);
        }

        /// <summary>
        /// Imports the content type information from the given xml file. 
        /// </summary>      
        public List<ContentTypeImportDTO> GetContentTypesFromXML(string importDirectory)
        {
            var importFileName = "";

            if (!string.IsNullOrEmpty(importDirectory))
            {
                importFileName = Path.Combine(importDirectory, "09_contentTypes.xml");
            }
            if (!File.Exists(importFileName))
            {
                throw new Exception(string.Format("File for importing content types {0} doesn't exist.", importFileName));
            }
            logger.LogInfo(string.Format("Getting all content types to import from {0}", importFileName));
            var document = XDocument.Load(importFileName);
            return utils.GetContentTypes(document);
        }

        public void ImportOrUpdateFieldGroups(AccessHelper accessHelper, string RESTEndpoint, List<FieldGroupDTO> fieldGroupsToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fieldGroupsToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var fieldGroup in fieldGroupsToImport)
            {
                logger.LogInfo(string.Format("Importing field group: {0}", fieldGroup.Name));
                RestRequest request = new RestRequest("fieldgroups", Method.Post);
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("Accept", "application/hal+json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(fieldGroup);
                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                    response = client.Execute(request);
                }

                if (!response.StatusCode.ToString().Equals("Created"))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    logger.LogInfo(string.Format("ERROR: FieldGroup {0} was not created, error message: {1}", fieldGroup.Name, jsonResponse.exceptionMessage.ToString()));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void ImportOrUpdateFieldDefinitions(AccessHelper accessHelper, string RESTEndpoint, List<FieldDefinitionDTO> fieldDefinitionsToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fieldDefinitionsToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var fieldDef in fieldDefinitionsToImport)
            {
                RestRequest request;
                bool isUpdate = false;
                //if field definition exists then just update, if it doesn't - create it
                if (utils.fieldDefinitions.Any(x => x.Name.Equals(fieldDef.Name)))
                {
                    logger.LogInfo(string.Format("Updating existing field definition: {0}", fieldDef.Name));
                    fieldDef.Id = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().Id;
                    request = new RestRequest(string.Format("fielddefinition/{0}", fieldDef.Id), Method.Put);
                    isUpdate = true;
                }
                else
                {
                    logger.LogInfo(string.Format("Importing field definition: {0}", fieldDef.Name));
                    request = new RestRequest("fielddefinitions", Method.Post);
                }
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("Accept", "application/hal+json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(GetFieldDefinitionForImport(fieldDef, isUpdate));

                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                    response = client.Execute(request);
                }
                if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    logger.LogInfo(string.Format("ERROR: Field defintion {0} was not imported/updated, error message: {1}", fieldDef.Name, jsonResponse.exceptionMessage.ToString()));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void RebuildSearchIndex(AccessHelper accessHelper, string RESTEndpoint)
        {
            var accessToken = accessHelper.GetToken();
            var client = new RestClient(RESTEndpoint);
            var request = new RestRequest("searchindex", Method.Put);
            request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
            request.AddHeader("API-VERSION", "1");
            request.AddHeader("Accept", "application/hal+json");
            request.AddJsonBody(@"{ 'rebuildScheduled': true }");
            request.RequestFormat = DataFormat.Json;
            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                response = client.Execute(request);
            }
            if (!response.StatusCode.ToString().Equals("NoContent"))
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                logger.LogInfo(string.Format("ERROR: Search index could not be rebuilt, error message: {0}", jsonResponse.exceptionMessage.ToString()));
            }
        }

        /// <summary>
        /// imports/updates classifictions without field values, to be able to register field groups and fields
        /// and also ensure all classifications are imported if any fields used on classification are classification lists
        /// </summary>
        /// <param name="accessHelper"></param>
        /// <param name="RESTEndpoint"></param>
        /// <param name="classificationsToImport"></param>
        /// <param name="progressBar"></param>
        public void ImportOrUpdateClassifications(AccessHelper accessHelper, string RESTEndpoint, List<ClassificationImportDTO> classificationsToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = classificationsToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);

            foreach (var classification in classificationsToImport)
            {
                try
                {
                    RestRequest request;
                    //if classification exists then just update, if it doesn't - create it
                    if (utils.classifications.Any(x => x.NamePath.Equals(classification.NamePath)))
                    {
                        logger.LogInfo(string.Format("Updating existing classification: {0}", classification.NamePath));
                        var id = utils.classifications.Where(x => x.NamePath.Equals(classification.NamePath)).FirstOrDefault().Id;
                        request = new RestRequest(string.Format("classification/{0}", id), Method.Put);
                        classification.IsUpdate = true;
                        ManageLinkedObjectsForClassifications(classification.RegisteredFieldGroups, classification.RegisteredFields, classification.Slaveclassifications, classification.NamePath);
                    }
                    else
                    {
                        logger.LogInfo(string.Format("Importing classification: {0}", classification.NamePath));
                        request = new RestRequest("classifications", Method.Post);
                    }
                    request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                    request.AddHeader("API-VERSION", "1");
                    request.AddHeader("Accept", "application/hal+json");
                    request.AddHeader("set-immediateSearchIndexUpdate", "true");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonHelper.Serialize(classification));

                    RestResponse response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: Classification {0} was not imported/updated, error message: {1}", classification.NamePath, jsonResponse.exceptionMessage.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInfo(string.Format("ERROR when importing/updating classification {0}, message: {1}", classification.NamePath, ex.Message));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// Adds field values to classifications that were imported/updated
        /// </summary>
        /// <param name="accessHelper"></param>
        /// <param name="RESTEndpoint"></param>
        /// <param name="classificationsToImport"></param>
        /// <param name="progressBar"></param>
        public void UpdateClassificationFields(AccessHelper accessHelper, string RESTEndpoint, List<ClassificationImportDTO> classificationsToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = classificationsToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);

            foreach (var classification in classificationsToImport)
            {
                try
                {
                    RestRequest request;
                    //if classification exists then just update, if it doesn't - create it
                    //all classifications should have been imported by the time this method runs
                    if (utils.classifications.Any(x => x.NamePath.Equals(classification.NamePath)))
                    {
                        logger.LogInfo(string.Format("Adding field values to existing classification: {0}", classification.NamePath));
                        var id = utils.classifications.Where(x => x.NamePath.Equals(classification.NamePath)).FirstOrDefault().Id;
                        request = new RestRequest(string.Format("classification/{0}", id), Method.Put);
                        classification.IsUpdate = true;
                        ManageLinkedObjectsForClassifications(classification.RegisteredFieldGroups, classification.RegisteredFields, classification.Slaveclassifications, classification.NamePath);
                    }
                    else
                    {
                        logger.LogInfo(string.Format("Importing classification: {0}", classification.NamePath));
                        request = new RestRequest("classifications", Method.Post);
                    }
                    request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                    request.AddHeader("API-VERSION", "1");
                    request.AddHeader("Accept", "application/hal+json");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonHelper.Serialize(classification));

                    RestResponse response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: Classification {0} was not updated with field values, error message: {1}", classification.NamePath, jsonResponse.exceptionMessage.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInfo(string.Format("ERROR when editing fields and mappings for classification {0}, meesage: {1}", classification.NamePath, ex.Message));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }
        public void ImportOrUpdateFileTypes(AccessHelper accessHelper, string RESTEndpoint, List<FileTypeImportDTO> fileTypesToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fileTypesToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var fileType in fileTypesToImport)
            {
                try
                {
                    RestRequest request;
                    bool isUpdate = false;
                    string fileTypeId = "";
                    FileTypeImportDTO fileType2 = new FileTypeImportDTO(fileType);
                    //if file type exists then just update, if it doesn't - create it
                    if (utils.fileTypes.Any(x => x.Name.Equals(fileType.Name)))
                    {
                        logger.LogInfo(string.Format("Updating existing file type: {0}", fileType.Name));
                        fileTypeId = utils.fileTypes.Where(x => x.Name.Equals(fileType.Name)).FirstOrDefault().Id;
                        request = new RestRequest(string.Format("filetype/{0}", fileTypeId), Method.Put);
                        ManageLinkedObjectsForFileTypes(fileType);
                        isUpdate = true;
                    }
                    else
                    {
                        logger.LogInfo(string.Format("Importing file type: {0}", fileType.Name));
                        request = new RestRequest("filetypes ", Method.Post);
                    }
                    request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                    request.AddHeader("API-VERSION", "1");
                    request.AddHeader("Accept", "application/hal+json");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonHelper.Serialize(fileType));

                    RestResponse response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: File Type {0} was not imported/updated, error message: {1}", fileType.Name, jsonResponse.exceptionMessage.ToString()));
                    }
                    //if update, then in first request we removed cataloging actions, media engines, 
                    //since the order of these is important; we now need to reimport
                    if (isUpdate)
                    {
                        RestRequest request2 = new RestRequest(string.Format("filetype/{0}", fileTypeId), Method.Put);
                        request2.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                        request2.AddHeader("API-VERSION", "1");
                        request2.AddHeader("Accept", "application/hal+json");
                        request2.RequestFormat = DataFormat.Json;
                        AddOrderedEnginesAndCatalogingActions(fileType2.CatalogActions, fileType2.MediaEngines, fileType2.Name);
                        request2.AddJsonBody(JsonHelper.Serialize(fileType2));
                        response = client.Execute(request2);
                        if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                        {
                            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                            logger.LogInfo(string.Format("ERROR: File Type {0} was not imported/updated, error message: {1}", fileType.Name, jsonResponse.exceptionMessage.ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInfo(string.Format("ERROR when importing/updating file type {0}, message: {1}", fileType.Name, ex.Message));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void ImportOrUpdateSettingCategories(AccessHelper accessHelper, string RESTEndpoint, List<SettingCategoryDTO> settingCategoriesToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = settingCategoriesToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var settingCategory in settingCategoriesToImport)
            {
                logger.LogInfo(string.Format("Importing setting category: {0}", settingCategory.Name));
                RestRequest request = new RestRequest("settingcategories", Method.Post);
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("Accept", "application/hal+json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(JsonHelper.Serialize(settingCategory));
                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                    response = client.Execute(request);
                }

                if (!response.StatusCode.ToString().Equals("Created"))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    logger.LogInfo(string.Format("ERROR: Setting Category {0} was not created, error message: {1}", settingCategory.Name, jsonResponse.exceptionMessage.ToString()));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void ImportOrUpdateSettingDefinitions(AccessHelper accessHelper, string RESTEndpoint, List<SettingDefinitionDTO> settingDefintionsToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = settingDefintionsToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var settingDef in settingDefintionsToImport)
            {
                bool isUpdate = false;
                RestRequest request;
                //if setting definition exists then just update, if it doesn't - create it
                if (utils.settingDefinitions.Any(x => x.Name.Equals(settingDef.Name)))
                {
                    logger.LogInfo(string.Format("Updating existing setting definition: {0}", settingDef.Name));
                    settingDef.Id = utils.settingDefinitions.Where(x => x.Name.Equals(settingDef.Name)).FirstOrDefault().Id;
                    request = new RestRequest(string.Format("settingdefinition/{0}", settingDef.Id), Method.Put);
                    isUpdate = true;
                }
                else
                {
                    logger.LogInfo(string.Format("Importing setting definition: {0}", settingDef.Name));
                    request = new RestRequest("settingdefinitions", Method.Post);
                }
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("Accept", "application/hal+json");
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(GetSettingDefinitionForImport(settingDef, isUpdate));

                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                    response = client.Execute(request);
                }
                if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    logger.LogInfo(string.Format("ERROR: Setting defintion {0} was not imported/updated, error message: {1}", settingDef.Name, jsonResponse.exceptionMessage.ToString()));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void ImportOrUpdateSettings(AccessHelper accessHelper, string RESTEndpoint, List<SettingValueDTO> settings, ref ProgressBar progressBar)
        {
            progressBar.Maximum = settings.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (SettingValueDTO setting in settings)
            {
                try
                {
                    RestRequest request;
                    logger.LogInfo(string.Format("Updating value(s) for setting: {0}", setting.SettingName));
                    request = new RestRequest(string.Format("setting/{0}", setting.SettingName), Method.Put);

                    request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                    request.AddHeader("API-VERSION", "1");
                    request.AddHeader("Accept", "application/hal+json");
                    request.RequestFormat = DataFormat.Json;
                    //fill in system value first
                    var settingRequest = new SettingValueImportDTO() { Name = setting.SettingName, Scope = "system", Value = setting.SystemLevelValue };
                    request.AddJsonBody(JsonHelper.Serialize(settingRequest));

                    RestResponse response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("NoContent"))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: Setting value {0} on system level was not updated, error message: {1}", setting.SettingName, jsonResponse.exceptionMessage.ToString()));
                    }
                    //then update user group levels if existing
                    foreach (var userGroupId in setting.UserGroupLevelValues.Keys)
                    {
                        RestRequest request2 = new RestRequest(string.Format("setting/{0}", setting.SettingName), Method.Put);
                        request2.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                        request2.AddHeader("API-VERSION", "1");
                        request2.AddHeader("Accept", "application/hal+json");
                        request2.RequestFormat = DataFormat.Json;
                        settingRequest = new SettingValueImportDTO() { Name = setting.SettingName, Scope = "usergroup", ScopeId = userGroupId, Value = setting.UserGroupLevelValues[userGroupId] };
                        request2.AddJsonBody(JsonHelper.Serialize(settingRequest));
                        response = client.Execute(request2);
                        if (!response.StatusCode.ToString().Equals("NoContent"))
                        {
                            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                            logger.LogInfo(string.Format("ERROR: Setting value {0} for user group {1} was not updated, error message: {2}", setting.SettingName, userGroupId, jsonResponse.exceptionMessage.ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogInfo(string.Format("ERROR when updating setting value {0}, message: {1}", setting.SettingName, ex.Message));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void ImportOrUpdateRules(AccessHelper accessHelper, string RESTEndpoint, List<RuleImportDTO> rulesToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = rulesToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var rule in rulesToImport)
            {
                try
                {
                    RestRequest request;
                    //if rule exists then just update, if it doesn't - create it
                    if (utils.rules.Any(x => x.Name.Equals(rule.Name)))
                    {
                        logger.LogInfo(string.Format("Updating existing rule: {0}", rule.Name));
                        var id = utils.rules.Where(x => x.Name.Equals(rule.Name)).FirstOrDefault().Id;
                        request = new RestRequest(string.Format("rule/{0}", id), Method.Put);
                        //ManageLinkedObjectsForRules(rule.Conditions, rule.Actions, rule.Name);
                    }
                    else
                    {
                        logger.LogInfo(string.Format("Importing rule: {0}", rule.Name));
                        request = new RestRequest("rules", Method.Post);
                    }
                    request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                    request.AddHeader("API-VERSION", "1");
                    request.AddHeader("Accept", "application/hal+json");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonHelper.Serialize(rule));

                    RestResponse response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: Rule {0} was not imported/updated, error message: {1}", rule.Name, jsonResponse.exceptionMessage.ToString()));
                    }

                }
                catch (Exception ex)
                {
                    logger.LogInfo(string.Format("ERROR when importing/updating rule {0}, message: {1}", rule.Name, ex.Message));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void ImportOrUpdateContentTypes(AccessHelper accessHelper, string RESTEndpoint, List<ContentTypeImportDTO> contentTypesToImport, ref ProgressBar progressBar)
        {
            progressBar.Maximum = contentTypesToImport.Count;
            progressBar.Step = 1;
            var accessToken = accessHelper.GetToken();

            // Perform request
            string result = String.Empty;
            var client = new RestClient(RESTEndpoint);
            foreach (var contentType in contentTypesToImport)
            {
                try
                {
                    RestRequest request;
                    //if contnet type exists then just update, if it doesn't - create it
                    if (utils.contentTypes.Any(x => x.Name.Equals(contentType.Name)))
                    {
                        logger.LogInfo(string.Format("Updating existing content type: {0}", contentType.Name));
                        var id = utils.contentTypes.Where(x => x.Name.Equals(contentType.Name)).FirstOrDefault().Id;
                        request = new RestRequest(string.Format("contenttype/{0}", id), Method.Put);
                        ManageLinkedObjectsForContentTypes(contentType.RegisteredFields, contentType.InheritableFields, contentType.Name);
                    }
                    else
                    {
                        logger.LogInfo(string.Format("Importing content type: {0}", contentType.Name));
                        request = new RestRequest("contenttypes", Method.Post);
                    }
                    request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                    request.AddHeader("API-VERSION", "1");
                    request.AddHeader("Accept", "application/hal+json");
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(JsonHelper.Serialize(contentType));

                    RestResponse response = client.Execute(request);

                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer {0}", accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("Created") && !response.StatusCode.ToString().Equals("NoContent"))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: Content type {0} was not imported/updated, error message: {1}", contentType.Name, jsonResponse.exceptionMessage.ToString()));
                    }

                }
                catch (Exception ex)
                {
                    logger.LogInfo(string.Format("ERROR when importing/updating content type {0}, message: {1}", contentType.Name, ex.Message));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        /// <summary>
        /// Gets correct field definition object to send in request to update field definition
        /// based on data type from FieldDefinitionDTO
        /// </summary>
        /// <param name="fieldDef"></param>
        private string GetFieldDefinitionForImport(FieldDefinitionDTO fieldDef, bool isUpdate)
        {
            switch (fieldDef.DataType.ToLowerInvariant())
            {
                case "classificationlist":
                    var clsFieldDef = new ClassificationListFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(clsFieldDef.FieldGroups, clsFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(clsFieldDef);
                case "date":
                    var dateFieldDef = new DateFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(dateFieldDef.FieldGroups, dateFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(dateFieldDef);
                case "time":
                    var timeFieldDef = new DateFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(timeFieldDef.FieldGroups, timeFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(timeFieldDef);
                case "datetime":
                    var dateTimeFieldDef = new DateTimeFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(dateTimeFieldDef.FieldGroups, dateTimeFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(dateTimeFieldDef);
                case "optionlist":
                    var optionListFieldDef = new OptionListFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(optionListFieldDef.FieldGroups, optionListFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    if (isUpdate)
                    {
                        var previousOptions = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().Options;
                        //for options that we're updating, id needs to be provided, otherwise for new options there should be no id
                        foreach (var addOrUpdateOption in optionListFieldDef.Options.AddOrUpdateOptions)
                        {
                            if (previousOptions.Any(po => po.Name.Equals(addOrUpdateOption.Name)))
                            {
                                addOrUpdateOption.Id = previousOptions.Where(po => po.Name.Equals(addOrUpdateOption.Name)).FirstOrDefault().Id;
                            }
                        }

                        //we need to set up options to remove, if any
                        var previousOptionsToRemove = previousOptions.Where(o => !optionListFieldDef.Options.AddOrUpdateOptions.Any(op => o.Name.Equals(op.Name))).ToList<OptionDTO>();
                        var optionsToRemove = new List<OptionImportDTO>();
                        foreach (var option in previousOptionsToRemove)
                        {
                            optionsToRemove.Add(new OptionImportDTO(option));
                        }
                        optionListFieldDef.Options.RemoveOptions = optionsToRemove;
                    }
                    return JsonHelper.Serialize(optionListFieldDef);
                case "numeric":
                    var numericFieldDef = new NumericFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(numericFieldDef.FieldGroups, numericFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(numericFieldDef);
                case "recordlink":
                    var recLinkFieldDef = new RecordLinkFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(recLinkFieldDef.FieldGroups, recLinkFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    if (isUpdate)
                    {
                        var previousParentClassifications = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().ParentClassifications;
                        recLinkFieldDef.ParentClassifications.Remove = previousParentClassifications.Where(x => !recLinkFieldDef.ParentClassifications.AddOrUpdate.Any(y => x.Equals(y))).ToList();

                        var previousParentContentTypes = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().ParentContentTypes;
                        recLinkFieldDef.ParentContentTypes.Remove = previousParentContentTypes.Where(x => !recLinkFieldDef.ParentContentTypes.AddOrUpdate.Any(y => x.Equals(y))).ToList();

                        var previousChildClassifications = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().ChildClassifications;
                        recLinkFieldDef.ChildClassifications.Remove = previousChildClassifications.Where(x => !recLinkFieldDef.ChildClassifications.AddOrUpdate.Any(y => x.Equals(y))).ToList();

                        var previousChildContentTypes = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().ChildContentTypes;
                        recLinkFieldDef.ChildContentTypes.Remove = previousChildContentTypes.Where(x => !recLinkFieldDef.ChildContentTypes.AddOrUpdate.Any(y => x.Equals(y))).ToList();

                        var previousLinkClassifications = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().LinkClassifications;
                        recLinkFieldDef.LinkClassifications.Remove = previousLinkClassifications.Where(x => !recLinkFieldDef.LinkClassifications.AddOrUpdate.Any(y => x.Equals(y))).ToList();

                        var previousLinkContentTypes = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldDef.Name)).FirstOrDefault().LinkContentTypes;
                        recLinkFieldDef.LinkContentTypes.Remove = previousLinkContentTypes.Where(x => !recLinkFieldDef.LinkContentTypes.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                    }
                    return JsonHelper.Serialize(recLinkFieldDef);
                case "recordlist":
                    var recListFieldDef = new RecordListFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(recListFieldDef.FieldGroups, recListFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(recListFieldDef);
                case "singlelinetext":
                case "multilinetext":
                case "html":
                    var textFieldDef = new TextFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(textFieldDef.FieldGroups, textFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(textFieldDef);
                case "userlist":
                case "usergrouplist":
                    var userFieldDef = new UserGroupListFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(userFieldDef.FieldGroups, userFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(userFieldDef);
                default:
                    var genFieldDef = new GenericFieldDefinitionDTO(fieldDef, isUpdate);
                    ManageLinkedObjectsForFields(genFieldDef.FieldGroups, genFieldDef.EnabledLanguages, isUpdate, fieldDef.Name);
                    return JsonHelper.Serialize(genFieldDef);
            }
        }

        /// <summary>
        /// Gets correct setting definition object to send in request to update setting definition
        /// based on data type from SettingDefinitionDTO
        /// </summary>
        /// <param name="settingDef"></param>
        private string GetSettingDefinitionForImport(SettingDefinitionDTO settingDef, bool isUpdate = false)
        {
            switch (settingDef.DataType.ToLowerInvariant())
            {
                case "boolean":
                    var boolSettingDef = new BooleanSettingDefinitionDTO(settingDef);
                    return JsonHelper.Serialize(boolSettingDef);
                case "numeric":
                    var numericSettingDef = new NumericSettingDefinitionDTO(settingDef);
                    return JsonHelper.Serialize(numericSettingDef);
                case "datetime":
                    var dateTimeSettingDef = new DateTimeSettingDefinitionDTO(settingDef);
                    return JsonHelper.Serialize(dateTimeSettingDef);
                case "role":
                    var roleSettingDef = new GenericSettingDefinitionDTO(settingDef);
                    if (!isUpdate)
                    {
                        roleSettingDef.RoleRequiredForChange = ".RoleChangeSystemSettings";
                    }
                    return JsonHelper.Serialize(roleSettingDef);
                case "xml":
                    var xmlSettingDef = new XmlSettingDefinitionDTO(settingDef);
                    if (string.IsNullOrEmpty(xmlSettingDef.DefaultValue))
                    {
                        xmlSettingDef.DefaultValue = "<empty/>";
                    }
                    //if (string.IsNullOrEmpty(xmlSettingDef.Schema))
                    //{
                    //    xmlSettingDef.Schema = @"<xs:schema xmlns:xs='http://www.w3.org/2001/XMLSchema'></xs:schema>";
                    //}
                    return JsonHelper.Serialize(xmlSettingDef);
                default: //text, reference
                    var textSettingDef = new TextSettingDefinitionDTO(settingDef);
                    return JsonHelper.Serialize(textSettingDef);
            }
        }

        /// <summary>
        /// in case of update, manages which linked objects need to be removed vs updated/created 
        /// </summary>
        /// <param name="groupMemberships"></param>
        /// <param name="enabledLanguages"></param>
        /// <param name="isUpdate"></param>
        /// <param name="fieldName"></param>
        private void ManageLinkedObjectsForFields(ListItemsToAddRemove groupMemberships, ListItemsToAddRemove enabledLanguages, bool isUpdate, string fieldName)
        {
            //manage list objects
            if (isUpdate)
            {
                if (groupMemberships != null)
                {
                    var previousMemberships = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldName)).FirstOrDefault().FieldGroups;
                    //we need to set up groups to remove, if any
                    groupMemberships.Remove = previousMemberships.Where(x => !groupMemberships.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                }
                if (enabledLanguages != null)
                {
                    var previousLanguages = utils.fieldDefinitions.Where(x => x.Name.Equals(fieldName)).FirstOrDefault().EnabledLanguages;
                    enabledLanguages.Remove = previousLanguages.Where(x => !enabledLanguages.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                }
            }
        }
        private void ManageLinkedObjectsForClassifications(ListItemsToAddRemove registeredFieldGroups, ListItemsToAddRemove registeredFields, ListItemsToAddRemove slaveClassifications, string classificationNamepath)
        {
            if (registeredFieldGroups != null)
            {
                var previousFieldGroups = utils.classifications.Where(x => x.NamePath.Equals(classificationNamepath)).FirstOrDefault().RegisteredFieldGroups.Select(x => x.FieldGroupId).ToList();
                //we need to set up groups to remove, if any
                registeredFieldGroups.Remove = previousFieldGroups.Where(x => !registeredFieldGroups.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = registeredFieldGroups.AddOrUpdate.Where(x => !previousFieldGroups.Any(y => x.Equals(y))).ToList();
                registeredFieldGroups.AddOrUpdate = addOrUpdate;
            }

            if (registeredFields != null)
            {
                var previousFields = utils.classifications.Where(x => x.NamePath.Equals(classificationNamepath)).FirstOrDefault().RegisteredFields.Select(x => x.FieldId).ToList();
                registeredFields.Remove = previousFields.Where(x => !registeredFields.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = registeredFields.AddOrUpdate.Where(x => !previousFields.Any(y => x.Equals(y))).ToList();
                registeredFields.AddOrUpdate = addOrUpdate;
            }

            if (slaveClassifications != null)
            {
                var previousSlaves = utils.GetClassificationIds(utils.classifications.Where(x => x.NamePath.Equals(classificationNamepath)).FirstOrDefault().Embedded.SlaveClassifications.SlaveItems.Select(x => x.NamePath).ToList());
                slaveClassifications.Remove = previousSlaves.Where(x => !slaveClassifications.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = slaveClassifications.AddOrUpdate.Where(x => !previousSlaves.Any(y => x.Equals(y))).ToList();
                slaveClassifications.AddOrUpdate = addOrUpdate;
            }
        }

        private void ManageLinkedObjectsForFileTypes(FileTypeImportDTO fileType)
        {
            if (fileType.RegisteredFieldGroups != null)
            {
                var previousFieldGroups = utils.fileTypes.Where(x => x.Name.Equals(fileType.Name)).FirstOrDefault().RegisteredFieldGroups.Select(x => x.FieldGroupId).ToList();
                //we need to set up groups to remove, if any
                fileType.RegisteredFieldGroups.Remove = previousFieldGroups.Where(x => !fileType.RegisteredFieldGroups.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = fileType.RegisteredFieldGroups.AddOrUpdate.Where(x => !previousFieldGroups.Any(y => x.Equals(y))).ToList();
                fileType.RegisteredFieldGroups.AddOrUpdate = addOrUpdate;
            }

            if (fileType.RegisteredFields != null)
            {
                var previousFields = utils.fileTypes.Where(x => x.Name.Equals(fileType.Name)).FirstOrDefault().RegisteredFields.Select(x => x.FieldId).ToList();
                fileType.RegisteredFields.Remove = previousFields.Where(x => !fileType.RegisteredFields.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = fileType.RegisteredFields.AddOrUpdate.Where(x => !previousFields.Any(y => x.Equals(y))).ToList();
                fileType.RegisteredFields.AddOrUpdate = addOrUpdate;
            }

            if (fileType.CatalogActions != null)
            {
                var previousCatalogActions = utils.fileTypes.Where(x => x.Name.Equals(fileType.Name)).FirstOrDefault().CatalogActions;
                fileType.CatalogActions.Remove = previousCatalogActions;
                fileType.CatalogActions.AddOrUpdate = new List<FileTypeDTO.FileTypeAction>();
            }

            if (fileType.PreviewPlayers != null)
            {
                var previousPreviewPlayers = utils.fileTypes.Where(x => x.Name.Equals(fileType.Name)).FirstOrDefault().PreviewPlayers.ToList();
                fileType.PreviewPlayers.Remove = previousPreviewPlayers.Where(x => !fileType.PreviewPlayers.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                //var addOrUpdate = previewPlayers.AddOrUpdate.Where(x => !previousPreviewPlayers.Any(y => x.Equals(y))).ToList();
                //previewPlayers.AddOrUpdate = addOrUpdate;
            }

            if (fileType.MediaEngines != null)
            {
                var previousMediaEngines = utils.fileTypes.Where(x => x.Name.Equals(fileType.Name)).FirstOrDefault().MediaEngines.ToList();
                fileType.MediaEngines.Remove = previousMediaEngines;
                fileType.MediaEngines.AddOrUpdate = new List<string>();
            }
        }

        private void ManageLinkedObjectsForRules(RuleImportDTO.ListConditionsToAddRemove ruleConditions, RuleImportDTO.ListActionsToAddRemove ruleActions, string ruleName)
        {
            //we will remove all previous actions and conditions and build the rule anew
            if (ruleConditions != null)
            {
                var previousConditions = utils.rules.Where(x => x.Name.Equals(ruleName)).FirstOrDefault().Conditions;
                ruleConditions.Remove = previousConditions.Select(x => x.Index.ToString()).ToList();
            }

            if (ruleActions != null)
            {
                var previousAction = utils.rules.Where(x => x.Name.Equals(ruleName)).FirstOrDefault().Actions;
                ruleActions.Remove = previousAction.Select(x => x.Index.ToString()).ToList();
            }
        }

        private void ManageLinkedObjectsForContentTypes(ListItemsToAddRemove registeredFields, ListItemsToAddRemove inheritableFields, string contentTypeName)
        {
            if (registeredFields != null)
            {
                var previousFields = utils.contentTypes.Where(x => x.Name.Equals(contentTypeName)).FirstOrDefault().RegisteredFields.Select(x => x.FieldId).ToList();
                registeredFields.Remove = previousFields.Where(x => !registeredFields.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = registeredFields.AddOrUpdate.Where(x => !previousFields.Any(y => x.Equals(y))).ToList();
                registeredFields.AddOrUpdate = addOrUpdate;
            }
            if (inheritableFields != null)
            {
                var previousFields = utils.contentTypes.Where(x => x.Name.Equals(contentTypeName)).FirstOrDefault().InheritableFields.Select(x => x.FieldId).ToList();
                inheritableFields.Remove = previousFields.Where(x => !inheritableFields.AddOrUpdate.Any(y => x.Equals(y))).ToList();
                var addOrUpdate = inheritableFields.AddOrUpdate.Where(x => !previousFields.Any(y => x.Equals(y))).ToList();
                inheritableFields.AddOrUpdate = addOrUpdate;
            }
        }
        private void AddOrderedEnginesAndCatalogingActions(ListCatalogActionsToAddRemove catalogActions, ListItemsToAddRemove mediaEngines, string fileTypeName)
        {
            if (catalogActions != null)
            {
                var previousCatalogActions = utils.fileTypes.Where(x => x.Name.Equals(fileTypeName)).FirstOrDefault().CatalogActions;
                catalogActions.Remove = new List<FileTypeDTO.FileTypeAction>();
            }

            if (mediaEngines != null)
            {
                var previousMediaEngines = utils.fileTypes.Where(x => x.Name.Equals(fileTypeName)).FirstOrDefault().MediaEngines.ToList();
                mediaEngines.Remove = new List<string>();
            }
        }
    }
}
