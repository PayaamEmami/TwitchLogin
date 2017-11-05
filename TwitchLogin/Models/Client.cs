using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

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
        private static Dictionary<string, string> queryStringClientCredentials;
        // Additional parameters used for requests 
        private static string responseType;
        private static string scope;
        // Client credentials retrieved from the Twitch API
        public static string accessToken { get;  set; }
        // URL link that sends our user to Twitch to login
        public static string urlLogin { get; set; }
        // This is our client used to send requests to the Twitch API
        private static HttpClient client = new HttpClient();

        /* *
         * Default Constructor: Creates variables and urls required for requests made to the Twitch API
         * */
        static Client()
        {
            clientId = "CLIENT-ID-GOES-HERE";
            clientSecret = "CLIENT-SECRET-GOES-HERE";
            redirectUri = "http://localhost:56463/Dashboard/Index";
            scope = "openid";
            responseType = "token id_token";
            // Url for the user to log in via twitch
            urlLogin = "https://api.twitch.tv/kraken/oauth2/authorize"
                + "?client_id=" + clientId
                + "&redirect_uri=" + redirectUri
                + "&response_type=" + HttpUtility.UrlEncode(responseType)
                + "&scope=" + scope;
            // Url for the request for client credentials (accessToken)
            urlClientCredentials = "https://api.twitch.tv/kraken/oauth2/token"
                + "?client_id=" + clientId
                + "&client_secret=" + clientSecret
                + "&grant_type=" + "client_credentials";
        }
        /* *
         * Creates a request to retrive client credientials (accessToken)
         * */
        public static void clientCredentialsRequest()
        {
            // Sends the request and retrieves the response, this API call requires all data be passed in query string, hence null body
            var response = client.PostAsync(urlClientCredentials, null).Result;

            // If we have a success status code on our response
            if(response.IsSuccessStatusCode)
            {
                // Retrieves the response into a variable
                var responseContent = response.Content;

                // Saves the JSON response as a string
                string responseString = responseContent.ReadAsStringAsync().Result;

                // Convert the JSON string into a JObject that is now accessible by key-value pairs
                JObject jsonObject = JObject.Parse(responseString);

                // Stores the access token to our client 
                accessToken = jsonObject["access_token"].ToString();
            }
        }
    }
}