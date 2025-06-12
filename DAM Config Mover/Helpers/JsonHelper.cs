using Models;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using RestSharp;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Aprimo.DAM.ConfigurationMover.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string json)
        {
            var result = Activator.CreateInstance<T>();
            var settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("o"),
            };
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(result.GetType(), settings);
                return (T)ser.ReadObject(ms);
            }
        }

        public static string Serialize<T>(T t)
        {
            var settings = new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("o"),
            };
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), settings);
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static string GetAccessToken(string clientSecret, string tokenEndpoint, string clientId)
        {
            // Get the access and refresh tokens
            string accessToken = "";
            var client = new RestClient(tokenEndpoint);

            var request = new RestRequest("login/connect/token", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_credentials=configmover&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);

            RestResponse response = client.Execute(request);
            if (response.StatusCode.ToString().Equals("OK"))
            {
                var tokens = JsonHelper.Deserialize<Tokens>(response.Content);

                accessToken = tokens.accessToken;
            }
            else throw new Exception(string.Format("Access token was not created, responese status is {0}, response message: {1}", response.StatusCode, response.Content));
            return accessToken;
        }


    }
}
