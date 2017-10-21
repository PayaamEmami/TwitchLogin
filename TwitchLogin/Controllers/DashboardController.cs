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
        // TODO - This isn't correct
        public ActionResult Index(string accessToken, string idToken, string scope, string type)
        {
            // Object to store information on the user
            User user = new User(accessToken, idToken);

            return View(user);
        }
    }
}