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
            TwitchClient.AccessTokenRequest(code);

            return View();
        }
    }
}