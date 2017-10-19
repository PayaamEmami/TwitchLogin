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
        public ActionResult Index()
        {
            // TODO - THIS IS NOT CORRECTLY GETTING THE FULL URL WITH QUERYSTRING
            // Retrieves the current full url
            var url = Request.Url.AbsoluteUri;

            // Retrieves query string parameters
            var queryString = HttpUtility.ParseQueryString(url);

            // Retrieves access_token from query string
            var accessToken = queryString["access_token"];

            // Retrieves id_token from query string
            var idToken = queryString["id_token"];

            // Object to store information on the user
            User user = new User(accessToken, idToken);

            return View(user);
        }
    }
}