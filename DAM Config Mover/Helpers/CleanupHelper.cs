using Aprimo.DAM.ConfigurationMover.Models.DTOs;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Aprimo.DAM.ConfigurationMover.Helpers
{
    public class CleanupHelper
    {
        public Logger logger;
        public List<FieldGroupDTO> fieldGroups { get; set; }
        public List<ClassificationDTO> classifications { get; set; }

        public List<FieldDefinitionDTO> fieldDefinitions { get; set; }

        public CleanupHelper(Logger logger)
        {
            this.logger = logger;
        }

        public void CleanupAllFieldGroups(AccessHelper accessHelper, string aprimoDamUrl, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fieldGroups.Count;
            progressBar.Step = 1;
            var client = new RestClient(aprimoDamUrl);
            foreach (var id in fieldGroups.Select(x => x.Id).ToList())
            {
                var request = new RestRequest(string.Format("fieldgroup/{0}", id), Method.Delete);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (!response.StatusCode.ToString().Equals("NoContent", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    logger.LogInfo(string.Format("ERROR: Field group {0} was not deleted, error message: {1}", id, jsonResponse.exceptionMessage.ToString()));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void CleanupAllFieldDefinitions(AccessHelper accessHelper, string aprimoDamUrl, ref ProgressBar progressBar)
        {
            progressBar.Maximum = fieldDefinitions.Count;
            progressBar.Step = 1;
            var client = new RestClient(aprimoDamUrl);
            foreach (var id in fieldDefinitions.Select(x => x.Id).ToList())
            {
                var request = new RestRequest(string.Format("fielddefinition/{0}", id), Method.Delete);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                RestResponse response = client.Execute(request);
                if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                {
                    accessToken = accessHelper.GetRefreshedToken();
                    request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                    response = client.Execute(request);
                }
                if (!response.StatusCode.ToString().Equals("NoContent", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                    logger.LogInfo(string.Format("ERROR: Field defintion {0} was not deleted, error message: {1}", id, jsonResponse.exceptionMessage.ToString()));
                }
                progressBar.PerformStep();
            }
            progressBar.Value = progressBar.Maximum;
        }

        public void CleanupAllClassifications(AccessHelper accessHelper, string aprimoDamUrl, ref ProgressBar progressBar)
        {
            progressBar.Maximum = classifications.Count;
            progressBar.Step = 1;
            var exportHelper = new ExportHelper(logger);
            var client = new RestClient(aprimoDamUrl);
            while (classifications.Count > 0)
            {
                var listToDelete = classifications.Where(x => !x.HasChildren).ToList();
                foreach (var cls in listToDelete)
                {
                    var request = new RestRequest(string.Format("classification/{0}", cls.Id), Method.Delete);
                    var accessToken = accessHelper.GetToken();
                    request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
                    request.AddHeader("Accept", "application/hal+json");
                    request.AddHeader("API-VERSION", "1");
                    RestResponse response = client.Execute(request);
                    if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
                    {
                        accessToken = accessHelper.GetRefreshedToken();
                        request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                        response = client.Execute(request);
                    }
                    if (!response.StatusCode.ToString().Equals("NoContent", StringComparison.OrdinalIgnoreCase))
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                        logger.LogInfo(string.Format("ERROR: Classification {0} was not deleted, error message: {1}", cls.NamePath, jsonResponse.exceptionMessage.ToString()));
                    }
                    classifications.Remove(cls);
                    progressBar.PerformStep();
                }
                classifications = exportHelper.GetClassifications(accessHelper, aprimoDamUrl, "", true);
            }
            progressBar.Value = progressBar.Maximum;
        }

    }
}
