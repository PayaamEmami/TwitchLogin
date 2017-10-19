using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitchLogin.Models
{
    public class User
    {
        public string accessToken { get; set; }
        public string idToken { get; set; }

        /* *
         * Default Constructor:
         * Creates a user with null values
         * */
        public User()
        {
            this.accessToken = null;
            this.idToken = null;
        }

        /* *
         * Constructor:
         * Creates a user with accessToken and idToken values
         * */
        public User(string accessToken, string idToken)
        {
            this.accessToken = accessToken;
            this.idToken = idToken;
        }
    }
}