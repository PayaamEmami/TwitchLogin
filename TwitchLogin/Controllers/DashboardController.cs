﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitchLogin.Models;

namespace TwitchLogin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index(string code)
        {
            // Uses the short term access code to request an access token
            Client.AccessTokenRequest(code);

            return View();
        }
    }
}