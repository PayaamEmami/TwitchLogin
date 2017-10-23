using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TwitchLogin.Models
{
    public static class Client
    {
        // Client ID and Secret provided by my Twitch Client
        private static string clientId;
        private static string clientSecret;
        // Redirect URI which points where twitch sends the user back to my application
        private static string redirectUri;
        // URL link that is used for a request to retrieve client credentials
        private static string urlClientCredentials;
        // Query string that is used for a request to retrieve client credentials
        private static string queryStringClientCredentials;
        // Additional parameters used for requests 
        private static string responseType;
        private static string scope;
        // Client credentials retrieved from the Twitch API
        public static string idToken { get; set; }
        public static string accessToken { get;  set; }
        // URL link that sends our user to Twitch to login
        public static string urlLogin { get; set; }
        // This is our client used to send requests to the Twitch API
        private static HttpClient client = new HttpClient();

        /* *
         * Default Constructor: Creates urls required for requests made to the Twitch API
         * */
        static Client()
        {
            clientId = "CLIENT-ID-GOES-HERE";
            clientSecret = "CLIENT-SECRET-GOES-HERE";
            redirectUri = "http://localhost:56463/Dashboard/Index";
            urlClientCredentials = "https://api.twitch.tv/kraken/oauth2/token";
            responseType = "token id_token";
            scope = "openid";

            urlLogin = "https://api.twitch.tv/kraken/oauth2/authorize"
                + "?client_id=" + clientId
                + "&redirect_uri=" + redirectUri
                + "&response_type=" + HttpUtility.UrlEncode(responseType)
                + "&scope=" + scope;

            queryStringClientCredentials = "?client_id=" + clientId
                + "&client_secret=" + clientSecret
                + "&grant_type=" + "client_credentials";
        }
        /* *
         * Creates a request to retrive client credientials (accessToken and idToken)
         * */
        public static void clientCredentialsRequest()
        {
            // Sends the request and retrieves the response
            // TODO: This results in a bad request, we are getting closer :)
            var response = client.PostAsync(urlClientCredentials, new StringContent(queryStringClientCredentials)).Result;

            // If we have a success status code on our response
            if(response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                string responseString = responseContent.ReadAsStringAsync().Result;
            }
        }
    }
}