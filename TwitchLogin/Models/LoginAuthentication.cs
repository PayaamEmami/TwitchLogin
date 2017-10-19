using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitchLogin.Models
{
    public class LoginAuthentication
    {
        private string clientId;
        private string redirectUri;
        private string urlAuthorize;
        private string responseType;
        private string scope;
        public static string urlRequest { get; set; }

        /* *
         * Default Constructor:
         * Creates the authentication url for sending user to Twitch login page
         * */
        public LoginAuthentication()
        {
            clientId = "PUT YOUR CLIENT ID HERE";
            redirectUri = "http://localhost:56463/Dashboard/Index";
            urlAuthorize = "https://api.twitch.tv/kraken/oauth2/authorize";
            responseType = "token id_token";
            scope = "openid";
            urlRequest = urlAuthorize
                + "?client_id=" + clientId
                + "&redirect_uri=" + redirectUri
                + "&response_type=" + responseType
                + "&scope=" + scope;
        }
    }
}