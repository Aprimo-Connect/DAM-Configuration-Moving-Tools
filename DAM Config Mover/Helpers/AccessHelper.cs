
using System;
using System.Text;

namespace Aprimo.DAM.ConfigurationMover.Helpers
{
    public class AccessHelper
    {
        private string clientId;
        private string clientSecret;
        private string tokenEndpoint;
        private string accessToken;
        private string refreshToken;

        public AccessHelper(string clientId, string clientSecret, string tokenEndpoint)
        {

            this.clientSecret = clientSecret;
            this.clientId = clientId;
            this.tokenEndpoint = tokenEndpoint;
        }
        public string GetToken()
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                return accessToken;
            }

            accessToken = JsonHelper.GetAccessToken(clientSecret, tokenEndpoint, clientId);

            return accessToken;
        }

        public string GetRefreshedToken()
        {
            accessToken = JsonHelper.GetAccessToken(clientSecret, tokenEndpoint, clientId);
            return accessToken;
        }
    }
}
