using System;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    

    sealed public class AuthToken
    {
        public string raw_url { get; private set; }
        public string access_token { get => tokenInfo["access_token"]; }
        public string token_type { get => tokenInfo["token_type"]; }
        public int expires_in { get => int.Parse(tokenInfo["expires_in"]); }

        public bool IsActvated { get => !string.IsNullOrEmpty(raw_url);  }

        private Dictionary<string, string> tokenInfo = new Dictionary<string, string>();
        public AuthToken(string deepLinkUrl)
        {
            raw_url = deepLinkUrl;
            deepLinkUrl = deepLinkUrl.Replace("minify:///#", string.Empty);

            var parameters = deepLinkUrl.Split('&');

            foreach (var item in parameters)
            {
                var keyValueSplit = item.Split('=');
                var key = keyValueSplit[0];
                var value = keyValueSplit[1];

                tokenInfo[key] = value;
            }
        }

        public AuthToken()
        {
            raw_url = string.Empty;
        }

        public override string ToString()
        {
            return $"Access_Token: {access_token}; TokenType: {token_type}; ExpiresIn: {expires_in}";
        }
    }


}
