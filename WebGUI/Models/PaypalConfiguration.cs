using PayPal.Api;
using System.Collections.Generic;

namespace WebGUI.Models
{
    public class PaypalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }

        public static APIContext GetAPIContext() =>
            new APIContext(GetAccessToken())
            {
                Config = GetConfig()
            };

        static string GetAccessToken() =>
            new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
    }
}