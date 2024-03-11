using Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Helpers
{
    public static class ImportHelper
    {
        public static UserGroups GetAllUserGroups(AccessHelper accessHelper, string aprimoMoUrl)
        {
            string urlFormat = "groups?offset={1}&limit=250";
            int offset = 0;
            var client = new RestClient(aprimoMoUrl);
            var accessToken = accessHelper.GetToken();
            UserGroups userGroups = new UserGroups();
            userGroups._embedded = new UserGroups.EmbeddedGroups();
            userGroups._embedded.group = new List<UserGroups.Group>();
            do
            {
                var request = new RestRequest(string.Format(urlFormat, urlFormat, offset), Method.Get);
                request.AddHeader("X-Access-Token", accessToken);
                request.AddHeader("Accept", "application/json");

                RestResponse response = client.Execute(request);
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

        public static string GetClassificationByNamepath(AccessHelper accessHelper, string encodedNamepath, string RESTEndpoint)
        {
            // Perform request
            var client = new RestClient(RESTEndpoint);
            var request = new RestRequest(string.Format("classification/?namepath={0}", encodedNamepath), Method.Get);
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
            if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                return jsonResponse.id.ToString();
            }
            return "";
        }

        public static string UpdateClassificationPermissions(AccessHelper accessHelper, string classificationId, string RESTEndpoint, string permissionType, PermissionsForClassification copyPermissions)
        {
            var accessToken = accessHelper.GetToken();

            // Perform request
            var client = new RestClient(RESTEndpoint);
            var request = new RestRequest(string.Format("classification/{0}/{1}", classificationId, permissionType), Method.Put);
            request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
            request.AddHeader("API-VERSION", "1");
            request.AddHeader("Accept", "application/hal+json");
            request.RequestFormat = DataFormat.Json;

            var bodyRequest = new SetClassificationPermissionsRequest();

            bodyRequest.breakInheritance = copyPermissions.breakInheritance;

            if (copyPermissions.permissions.Count > 0)
            {
                bodyRequest.permissions = new SetClassificationPermissionsRequest.Permissions();
                bodyRequest.permissions.addOrUpdate = new List<SetClassificationPermissionsRequest.PermissionsAddOrUpdate>();
                foreach (PermissionsForClassification.Permissions permissionsToSet in copyPermissions.permissions)
                {
                    bodyRequest.permissions.addOrUpdate.Add(new SetClassificationPermissionsRequest.PermissionsAddOrUpdate() { userGroupId = permissionsToSet.userGroupId, accessRight = permissionsToSet.accessRight });
                }
            }

            request.AddJsonBody(bodyRequest);
            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                response = client.Execute(request);
            }

            if (!response.StatusCode.ToString().Equals("NoContent"))
            {
                return string.Format("UpdateClassificationPermissions failed, error: {0}, {1}", response.StatusCode, response.ErrorMessage);
            }
            return string.Format("Permissions for classification {0} updated.", classificationId);
        }

        public static DomainRights GetAllDomainRights(AccessHelper accessHelper, string aprimoMoUrl)
        {
            string url = "domain-rights?offset={0}&limit=50";
            int offset = 0;
            var client = new RestClient(aprimoMoUrl);
            var accessToken = accessHelper.GetToken();
            DomainRights domainRights = new DomainRights();
            domainRights._embedded = new DomainRights.EmbeddedDomainRights();
            domainRights._embedded.domainRight = new List<DomainRights.DomainRight>();
            do
            {
                var request = new RestRequest(string.Format(url, offset), Method.Get);
                request.AddHeader("X-Access-Token", accessToken);
                request.AddHeader("Accept", "application/json");

                RestResponse response = client.Execute(request);
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
                        dynamic domainRightsTemp = JsonHelper.Deserialize<DomainRights>(response.Content);
                        if (domainRightsTemp != null)
                        {
                            domainRights._embedded.domainRight.AddRange(domainRightsTemp._embedded.domainRight);
                            domainRights._total = domainRightsTemp._total;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                offset = domainRights._total > domainRights._embedded.domainRight.Count ? domainRights._embedded.domainRight.Count - 1 : 0;
            }
            while (offset > 0);

            return domainRights;
        }

        public static string GetCurrentUser(AccessHelper accessHelper, string aprimoMoUrl)
        {
            var client = new RestClient(aprimoMoUrl);
            var accessToken = accessHelper.GetToken();

            var request = new RestRequest("users/me", Method.Get);
            request.AddHeader("X-Access-Token", accessToken);
            request.AddHeader("Accept", "application/json");

            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("X-Access-Token", accessToken);
                response = client.Execute(request);
            }
            if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                return jsonResponse.userId.ToString();
            }

            return "";
        }
        public static string CreateUserGroup(AccessHelper accessHelper, string aprimoMoUrl, UserGroups.Group group)
        {
            var client = new RestClient(aprimoMoUrl);
            var accessToken = accessHelper.GetToken();
            var request = new RestRequest("groups", Method.Post);
            request.AddHeader("X-Access-Token", accessToken);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(group);

            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("X-Access-Token", accessToken);
                response = client.Execute(request);
            }

            if (!response.StatusCode.ToString().Equals("OK"))
            {
                return string.Format("CreatUserGroup failed, error: {0}, {1}", response.StatusCode, response.ErrorMessage);
            }
            return string.Format("User group {0} created.", group.name);
        }

        public static string UpdateUserGroup(AccessHelper accessHelper, string aprimoMoUrl, UserGroups.Group group)
        {
            var client = new RestClient(aprimoMoUrl);
            var accessToken = accessHelper.GetToken();
            var request = new RestRequest(string.Format("groups/{0}", group.groupId), Method.Put);
            request.AddHeader("X-Access-Token", accessToken);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(group);

            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("X-Access-Token", accessToken);
                response = client.Execute(request);
            }

            if (!response.StatusCode.ToString().Equals("OK"))
            {
                return string.Format("UpdateUserGroup failed, error: {0}, {1}", response.StatusCode, response.ErrorMessage);
            }
            return string.Format("User group {0} updated.", group.name);
        }

        public static string UpdateFunctionalPermissions(AccessHelper accessHelper, string userGroupId, string RESTEndpoint, SetFunctionalPermissionsRequest copyPermissions)
        {
            var accessToken = accessHelper.GetToken();

            // Perform request
            var client = new RestClient(RESTEndpoint);
            var request = new RestRequest(string.Format("usergroup/{0}/permissions", userGroupId), Method.Put);
            request.AddHeader("Authorization", string.Format("Bearer " + accessToken));
            request.AddHeader("API-VERSION", "1");
            request.AddHeader("Accept", "application/hal+json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(JsonHelper.Serialize(copyPermissions));
            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("unauthorized", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = accessHelper.GetRefreshedToken();
                request.AddOrUpdateParameter("Authorization", string.Format("Bearer " + accessToken));
                response = client.Execute(request);
            }

            if (!response.StatusCode.ToString().Equals("NoContent"))
            {
                return string.Format("UpdateFunctionalPermissions {0} failed, error: {1}, {2}", copyPermissions.permissions.addOrUpdate[0].name, response.StatusCode, response.ErrorMessage);
            }
            return "";
        }

        public static void GetAllDAMFunctionalPermission(AccessHelper accessHelper, string aprimoDamUrl, Dictionary<string, string> FunctionalPermissions)
        {
            var client = new RestClient(aprimoDamUrl);
            string url = "permissions";

            do
            {
                var request = new RestRequest(url, Method.Get);
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
                if (response.StatusCode.ToString().Equals("OK", StringComparison.OrdinalIgnoreCase))
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);

                    foreach (dynamic permission in jsonResponse.items)
                    {
                        try
                        {
                            FunctionalPermissions.Add(permission.labels[0].value.ToString(), permission.name.ToString());
                        }
                        catch (Exception) { }
                    }
                    url = (jsonResponse._links.next == null) ? "" : jsonResponse._links.next.href;
                }
            }
            while (url.Length > 0);
        }

    }
}
