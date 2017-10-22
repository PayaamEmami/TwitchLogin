using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchLogin.Models;

namespace TwitchLogin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        /* *
         * So, what's happening is that the query string parameters are actually fragments,
         * denoted by '#' instead of '?'. I need to figure out a way to retrieve these 
         * fragment parameters instead of what I thought were query string parameters.
         * */
        public ActionResult Index(string access_token, string id_token, string scope, string token_type)
        {
            // Object to store information on the user
            User user = new User(access_token, id_token);

            return View(user);
        }
    }
}