using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;

namespace TwitchLogin.Models
{
    public static class TwitchClient
    {
        public static string UrlTwitchLogin;
        public static string OAuthAccessToken;
        private static HttpClient httpClient = new HttpClient();
        private static string oAuthClientId;
        private static string oAuthClientSecret;
        private static string oAuthRedirectUri;
        private static string oAuthResponseType;
        private static string oAuthScope;
        private static string urlTwitchAccessTokenRequest;

        /* *
         * Default Constructor: Creates variables and urls required for requests made to the Twitch API
         * */
        static TwitchClient()
        {
            oAuthClientId = "CLIENT-ID-GOES-HERE";
            oAuthClientSecret = "CLIENT-SECRET-GOES-HERE";
            oAuthRedirectUri = "http://localhost:56463/Dashboard/Index";
            oAuthScope = "channel_read";
            oAuthResponseType = "code";

            httpClient.DefaultRequestHeaders.Add("Client-ID", oAuthClientId);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.twitchtv.v5+json"));

            UrlTwitchLogin = "https://api.twitch.tv/kraken/oauth2/authorize"
                + "?client_id=" + oAuthClientId
                + "&redirect_uri=" + oAuthRedirectUri
                + "&response_type=" + oAuthResponseType
                + "&scope=" + oAuthScope;
            urlTwitchAccessTokenRequest = "https://api.twitch.tv/kraken/oauth2/token"
                + "?client_id=" + oAuthClientId
                + "&client_secret=" + oAuthClientSecret
                + "&grant_type=" + "authorization_code"
                + "&redirect_uri=" + oAuthRedirectUri;
        }

        /* *
         * Creates a request to retrive client credientials (accessToken)
         * */
        public static void AccessTokenRequest(string shortTermAccessCode)
        {
            urlTwitchAccessTokenRequest += "&code=" + shortTermAccessCode;

            var response = httpClient.PostAsync(urlTwitchAccessTokenRequest, null).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;

                string responseString = responseContent.ReadAsStringAsync().Result;

                JObject jsonObject = JObject.Parse(responseString);

                OAuthAccessToken = jsonObject["access_token"].ToString();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", OAuthAccessToken);
            }
        }
    }
}