using Helpers;
using Models;
using Newtonsoft.Json;
using OfficeOpenXml;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aprimo.Samples.Forms.SecurityExporter.Helpers
{
    public static class ExtractionHelper
    {
        public static UserGroups GetAllUserGroups(AccessHelper accessHelper, string aprimoMoUrl)
        {
            string urlFormat = "groups?offset={1}&limit=50";
            int offset = 0;
            var client = new RestClient(aprimoMoUrl);
            var accessToken = accessHelper.GetToken();
            UserGroups userGroups = new UserGroups();
            userGroups._embedded = new UserGroups.EmbeddedGroups();
            userGroups._embedded.group = new List<UserGroups.Group>();
            do
            {
                var request = new RestRequest(string.Format(urlFormat, urlFormat, offset), Method.GET);
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
                        var userGroupsTemp = JsonHelper.Deserialize<UserGroups>(response.Content);
                        if (userGroupsTemp != null)
                        {
                            userGroups._embedded.group.AddRange(userGroupsTemp._embedded.group);
                            userGroups._total = userGroupsTemp._total;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                offset = userGroups._total > userGroups._embedded.group.Count ? userGroups._embedded.group.Count - 1 : 0;
            }
            while (offset > 0);

            return userGroups;

        }

        public static void GetAllClassifications(AccessHelper accessHelper, string aprimoDamUrl, string classificationFilter, Dictionary<Guid, string> Classifications)
        {
            var client = new RestClient(aprimoDamUrl);
            string url = "classifications";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
                request.AddHeader("Accept", "application/hal+json");
                request.AddHeader("API-VERSION", "1");
                request.AddHeader("pageSize", "500");
                request.AddHeader("select-classification", "NamePath");
                if ((classificationFilter != null) && (classificationFilter.Length > 0))
                {
                    request.AddHeader("filter", classificationFilter);
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
                            Classifications.Add(Guid.Parse(classification.id.ToString()), classification.namePath.Value);
                        }
                        catch (Exception) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
            }
            while (url.Length > 0);
        }

        /// <summary>
        /// Gets classification permissions and fills excel sheet appropriately 
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="accessHelper"></param>
        /// <param name="aprimoDamUrl"></param>
        /// <param name="classificationId"></param>
        /// <param name="classificationPath"></param>
        /// <param name="permissionType"></param>
        /// <param name="userGroups"></param>
        /// <param name="rowIndex"></param>
        public static void GetClassificationPermission(ref ExcelWorksheet worksheet, AccessHelper accessHelper, string aprimoDamUrl, Guid classificationId, string classificationPath, PermissionType permissionType, List<UserGroups.Group> userGroups, ref int rowIndex)
        {
            var end = worksheet.Dimension.End;
            var client = new RestClient(aprimoDamUrl);

            var request = new RestRequest(string.Format("classification/{0}/{1}", classificationId, permissionType), Method.GET);
            var accessToken = accessHelper.GetToken();
            request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
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
                if ((jsonResponse.permissions.Count > 0) || (jsonResponse.breakInheritance == true))
                {
                    worksheet.Cells[rowIndex, 1].Value = classificationPath;
                    worksheet.Cells[rowIndex, 2].Value = permissionType;
                    worksheet.Cells[rowIndex, 3].Value = jsonResponse.breakInheritance.ToString();
                    foreach (var permission in jsonResponse.permissions)
                    {
                        string userGroupId = permission.userGroupId.ToString();
                        int index = Array.IndexOf(userGroups.Select(x => x.adamUserId).ToArray(), Guid.Parse(permission.userGroupId.ToString()).ToString());
                        if(index != -1)
                        {
                            worksheet.Cells[rowIndex, 4 + index].Value = permission.accessRight.ToString();
                        }                        
                    }
                    rowIndex++;
                }
            }
        }


        public static void GetAllDAMFunctionalPermission(AccessHelper accessHelper, string aprimoDamUrl, Dictionary<string, string> FunctionalPermissions)
        {
            var client = new RestClient(aprimoDamUrl);
            string url = "permissions";

            do
            {
                var request = new RestRequest(url, Method.GET);
                var accessToken = accessHelper.GetToken();
                request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
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

                    foreach (dynamic permission in jsonResponse.items)
                    {
                        try
                        {
                            FunctionalPermissions.Add(permission.name.ToString(), permission.labels[0].value.ToString());
                        }
                        catch (Exception) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
            }
            while (url.Length > 0);
        }

        public static void GetFunctionalPermissionPerUserGroup(ref ExcelWorksheet worksheet, AccessHelper accessHelper, string aprimoDamUrl, Guid userGroupId, Dictionary<string, string> FunctionalPermissions, List<UserGroups.Group> userGroups)
        {
            var end = worksheet.Dimension.End;
            var client = new RestClient(aprimoDamUrl);

            var request = new RestRequest(string.Format("usergroup/{0}/permissions", userGroupId), Method.GET);
            var accessToken = accessHelper.GetToken();
            request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
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
                if ((jsonResponse.items.Count > 0))
                {
                    foreach (var permission in jsonResponse.items)
                    {
                        int rowIndex = Array.IndexOf(FunctionalPermissions.Keys.ToArray(), permission.name.ToString());
                        int columnIndex = Array.IndexOf(userGroups.Select(x => x.adamUserId).ToArray(), userGroupId.ToString());
                        if (columnIndex != -1)
                        {
                            worksheet.Cells[rowIndex + 2, columnIndex + 3].Value = permission.value.ToString();
                        }
                    }
                }
            }
        }
    }
}
