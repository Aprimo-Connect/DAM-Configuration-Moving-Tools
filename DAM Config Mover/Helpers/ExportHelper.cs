using Aprimo.DAM.ConfigurationMover.Helpers.XmlHelpers;
using Aprimo.DAM.ConfigurationMover.Models;
using Aprimo.DAM.ConfigurationMover.Models.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Aprimo.DAM.ConfigurationMover.Helpers
{
    public class ExportHelper
    {
        public Logger logger;
        public Utils utils;        

        public ExportHelper(Logger logger)
        {
            this.logger = logger;
            utils = new Utils(logger);
        }
        public void ExportFieldGroups(ref List<FieldGroupDTO> fieldGroups, string exportDirectory, ref ProgressBar progressBar)
        {
            var outputFileName = "";
            
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "01_fieldgroups.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);           

            logger.LogInfo(string.Format("There are {0} field groups to export", fieldGroups.Count));

            utils.ExportFieldGroupsToFile(fieldGroups, outputFileName, ref progressBar);
            logger.LogInfo("Export of field groups finished");
        }

        public void ExportFieldDefinitions(ref List<FieldDefinitionDTO> fieldDefinitions, string exportDirectory, ref ProgressBar progressBar)
        {
            var outputFileName = "";

            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "02_fieldDefinitions.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

                        
            logger.LogInfo(string.Format("There are {0} field definitions to export", fieldDefinitions.Count));

            utils.ExportFieldsToFile(fieldDefinitions, outputFileName, ref progressBar);
            logger.LogInfo("Export of field definitions finished");
        }

        public void ExportClassifications(List<ClassificationDTO> classifications, string exportDirectory, ref ProgressBar progressBar)
        {

            var outputFileName = "";
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "03_classifications.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            logger.LogInfo(string.Format("There are {0} classifications to export", classifications.Count));

            utils.ExportClassificationsToFile(classifications, outputFileName, ref progressBar);
            logger.LogInfo("Export of classifications finished");
        }

        public void ExportFileTypes(List<FileTypeDTO> fileTypes, string exportDirectory, ref ProgressBar progressBar)
        {

            var outputFileName = "";
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "04_filetypes.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            logger.LogInfo(string.Format("There are {0} file types to export", fileTypes.Count));

            utils.ExportFileTypesToFile(fileTypes, outputFileName, ref progressBar);
            logger.LogInfo("Export of file types finished");
        }

        public void ExportSettingCategories(List<SettingCategoryDTO> settingCategories, string exportDirectory, ref ProgressBar progressBar)
        {

            var outputFileName = "";
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "07_settingCategories.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            logger.LogInfo(string.Format("There are {0} setting categories to export", settingCategories.Count));

            utils.ExportSettingCategoriesToFile(settingCategories, outputFileName, ref progressBar);
            logger.LogInfo("Export of setting categories is finished");
        }

        public void ExportSettingDefinitions(List<SettingDefinitionDTO> settingDefinitions, string exportDirectory, ref ProgressBar progressBar)
        {

            var outputFileName = "";
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "08_settingDefinitions.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            logger.LogInfo(string.Format("There are {0} setting definitions to export", settingDefinitions.Count));

            utils.ExportSettingDefinitionsToFile(settingDefinitions, outputFileName, ref progressBar);
            logger.LogInfo("Export of setting defitnions is finished");
        }

        public void ExportSettings(List<SettingValueDTO> settings, string exportDirectory, ref ProgressBar progressBar)
        {

            var outputFileName = "";
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "05_settings.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            logger.LogInfo(string.Format("There are {0} settings to export", settings.Count));

            utils.ExportSettingValuesToFile(settings, outputFileName, ref progressBar);
            logger.LogInfo("Export of setting values is finished");
        }

        public void ExportRules(List<RuleDTO> rules, string exportDirectory, ref ProgressBar progressBar, AccessHelper accessHelper, string aprimoMoUrl)
        {

            var outputFileName = "";
            if (!string.IsNullOrEmpty(exportDirectory))
            {
                outputFileName = Path.Combine(exportDirectory, "06_rules.xml");
            }

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            logger.LogInfo(string.Format("There are {0} rules to export", rules.Count));

            if (rules.Any(r => r.Conditions.Any(c => !string.IsNullOrEmpty(c.UserId))))
            {
                ReplaceUserIds(rules, accessHelper, aprimoMoUrl);
            }
            utils.ExportRulesToFile(rules, outputFileName, ref progressBar);
                       
            logger.LogInfo("Export of rules finished");
        }

        public List<FieldGroupDTO> GetFieldGroups(AccessHelper accessHelper, string aprimoDamUrl, string filter)
        {
            var fieldGroups = new List<FieldGroupDTO>();

            var client = new RestClient(aprimoDamUrl);
            string url = "fieldgroups";
            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {

                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    foreach (dynamic fieldGroup in jsonResponse.items)
                    {
                        try
                        {
                            fieldGroups.Add(JsonHelper.Deserialize<FieldGroupDTO>(fieldGroup.ToString()));
                        }
                        catch (Exception ex) { }
                    }

                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return fieldGroups;
        }        

        public List<FieldDefinitionDTO> GetFieldDefinitions(AccessHelper accessHelper, string aprimoDamUrl, string filter)
        {
            var fieldDefinitions = new List<FieldDefinitionDTO>();

            var client = new RestClient(aprimoDamUrl);
            string url = "fielddefinitions";
            
            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                request.AddHeader("select-fielddefinition", "Tag");
                request.AddHeader("languages", "*");
                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    foreach (dynamic fieldDef in jsonResponse.items)
                    {
                        try
                        {
                            FieldDefinitionDTO fieldDefinition = JsonHelper.Deserialize<FieldDefinitionDTO>(fieldDef.ToString());
                            fieldDefinition.SetDefaults();
                            fieldDefinitions.Add(fieldDefinition);
                        }
                        catch (Exception ex) { }
                    }

                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return fieldDefinitions;
        }

        public List<ClassificationDTO> GetClassifications(AccessHelper accessHelper, string aprimoDamUrl, string filter, bool forCache = false)
        {
            var classifications = new List<ClassificationDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "classifications";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "500");
                request.AddHeader("select-classification", "NamePath");
                request.AddHeader("select-classification", "HasChildren");
                request.AddHeader("languages", "*");
                if (!forCache)
                {
                    request.AddHeader("select-classification", "image");
                    request.AddHeader("select-classification", "fields");
                    request.AddHeader("select-classification", "slaveclassifications");                    
                }

                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic classification in jsonResponse.items)
                    {
                        try
                        {
                            ClassificationDTO classificationTemp = JsonHelper.Deserialize<ClassificationDTO>(classification.ToString());                            
                            classifications.Add(classificationTemp);
                        }
                        catch (Exception ex)
                        { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return classifications;
        }

        public List<LanguageDTO> GetLanguages(AccessHelper accessHelper, string aprimoDamUrl)
        {
            var languages = new List<LanguageDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "languages";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic language in jsonResponse.items)
                    {
                        try
                        {
                            var languageTemp = JsonHelper.Deserialize<LanguageDTO>(language.ToString());
                            languages.Add(languageTemp);
                        }
                        catch (Exception ex) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return languages;
        }

        public List<UserGroupDTO> GetUserGroups(AccessHelper accessHelper, string aprimoDamUrl)
        {
            var userGroups = new List<UserGroupDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "usergroups";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                //request.AddHeader("filter", "name <> '*DAM*'");
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic userGroup in jsonResponse.items)
                    {
                        try
                        {
                            var userGroupTemp = JsonHelper.Deserialize<UserGroupDTO>(userGroup.ToString());
                            userGroups.Add(userGroupTemp);
                        }
                        catch (Exception ex) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return userGroups;
        }

        public List<SettingDefinitionDTO> GetSettingDefinitions(AccessHelper accessHelper, string aprimoDamUrl, string filter)
        {
            var settingDefinitions = new List<SettingDefinitionDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "settingdefinitions";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }

                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic settingDef in jsonResponse.items)
                    {
                        try
                        {
                            var settingDefinitionTemp = JsonHelper.Deserialize<SettingDefinitionDTO>(settingDef.ToString());
                            settingDefinitions.Add(settingDefinitionTemp);
                        }
                        catch (Exception ex) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return settingDefinitions;
        }
        public List<SettingCategoryDTO> GetSettingCategories(AccessHelper accessHelper, string aprimoDamUrl, string filter)
        {
            var settingCategories = new List<SettingCategoryDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "settingcategories";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "500");               

                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic settingCategory in jsonResponse.items)
                    {
                        try
                        {
                            SettingCategoryDTO settingCategoryTemp = JsonHelper.Deserialize<SettingCategoryDTO>(settingCategory.ToString());
                            settingCategories.Add(settingCategoryTemp);
                        }
                        catch (Exception ex)
                        { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
                else
                {
                    logger.LogInfo("The request failed");
                    url = "";
                }
            }
            while (url.Length > 0);
            return settingCategories;
        }

        public List<SettingValueDTO> GetSettingValues(AccessHelper accessHelper, string aprimoDamUrl, ref ListBox.SelectedObjectCollection settingDefinitions, ref ListBox.SelectedObjectCollection filterUserGroups)
        {
            var settingValues = new List<SettingValueDTO>();
            var client = new RestClient(aprimoDamUrl);

            foreach (Item settingDef in settingDefinitions)
            {
                var settingValue = new SettingValueDTO();
                settingValue.SettingName = settingDef.Label;
                //get system level value first
                var request = new RestRequest(string.Format("setting/{0}", settingDef.ID), Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);                   
                    settingValue.SystemLevelValue = jsonResponse.value.ToString();                    
                }
                //then, get the values for user groups
                foreach(Item group in filterUserGroups)
                {                    
                    request = new RestRequest(string.Format("setting/{0}?scope=usergroup&scopeId={1}", settingDef.ID, group.ID), Method.GET);                    
                    request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
                    request.AddHeader("Accept", "application/hal+json");
                    request.AddHeader("API-VERSION", "1");

                    response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                        response = client.Execute(request);
                    }
                    if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        settingValue.UserGroupLevelValues.Add(group.Label, jsonResponse.value.ToString());
                    }
                }

                settingValues.Add(settingValue);
            }
            
            return settingValues;
        }

        public List<FileTypeDTO> GetFileTypes(AccessHelper accessHelper, string aprimoDamUrl, string filter)
        {
            var fileTypes = new List<FileTypeDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "filetypes";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                request.AddHeader("select-filetype", "Tag");
                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic fileType in jsonResponse.items)
                    {
                        try
                        {
                            var fileTypeTemp = JsonHelper.Deserialize<FileTypeDTO>(fileType.ToString());
                            fileTypes.Add(fileTypeTemp);
                        }
                        catch (Exception ex) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
            }
            while (url.Length > 0);
            return fileTypes;
        }

        public List<RuleDTO> GetRules(AccessHelper accessHelper, string aprimoDamUrl, string aprimoMoUrl, string filter)
        {
            var rules = new List<RuleDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "rules";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "100");
                request.AddHeader("select-rule", "Tag");
                request.AddHeader("select-rule", "conditions");
                request.AddHeader("select-rule", "actions");
                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic rule in jsonResponse.items)
                    {
                        try
                        {
                            RuleDTO ruleTemp = JsonHelper.Deserialize<RuleDTO>(rule.ToString());
                            ruleTemp.Conditions = new List<RuleDTO.RuleCondition>();
                            ruleTemp.Actions = new List<RuleDTO.RuleAction>();
                            foreach(dynamic condition in rule._embedded.conditions.items)
                            {
                                var conditionTemp = JsonHelper.Deserialize<RuleDTO.RuleCondition>(condition.ToString());
                                ruleTemp.Conditions.Add(conditionTemp);
                            }
                            foreach (dynamic action in rule._embedded.actions.items)
                            {
                                var actionTemp = JsonHelper.Deserialize<RuleDTO.RuleAction>(action.ToString());
                                ruleTemp.Actions.Add(actionTemp);
                            }
                            rules.Add(ruleTemp);
                        }
                        catch (Exception ex) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
            }
            while (url.Length > 0);
            return rules;
        }

        public List<WatermarkDTO> GetWatermarks(AccessHelper accessHelper, string aprimoDamUrl, string filter)
        {
            var watermarks = new List<WatermarkDTO>();
            var client = new RestClient(aprimoDamUrl);
            string url = "watermarks";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "1000");
                request.AddHeader("select-watermark", "Tag");
                if ((filter != null) && (filter.Length > 0))
                {
                    request.AddHeader("filter", filter);
                }
                IRestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic watermark in jsonResponse.items)
                    {
                        try
                        {
                            var watermarkTemp = JsonHelper.Deserialize<WatermarkDTO>(watermark.ToString());
                            watermarks.Add(watermarkTemp);
                        }
                        catch (Exception ex) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
            }
            while (url.Length > 0);
            return watermarks;
        }

        public string GetUsernameOfUser(AccessHelper accessHelper, string aprimoMoUrl, string userId)
        {
            var client = new RestClient(aprimoMoUrl);
            var request = new RestRequest(string.Format("users/{0}", userId), Method.GET);
            var accessToken = accessHelper.GetToken();
            request.AddHeader("X-Access-Token", accessToken);
            request.AddHeader("Accept", "application/json");

            IRestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("X-Access-Token", accessToken);
                response = client.Execute(request);
            }
            if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                   
                }
                catch (Exception ex)
                {
                }
            }
            
            return "";
        }

        private void ReplaceUserIds(List<RuleDTO> rules, AccessHelper accessHelper, string aprimoMoUrl)
        {
            foreach(RuleDTO rule in rules)
            {
                foreach(RuleDTO.RuleCondition condition in rule.Conditions)
                {
                    if(!string.IsNullOrEmpty(condition.UserId))
                    {
                        condition.UserId = GetUsernameOfUser(accessHelper, aprimoMoUrl, condition.UserId);
                    }
                }
            }
        }

    }
}
