﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            var data = new Dictionary<string, object> {{"Placeholder", "Placeholder"}};
            return View(data);
        }
    }
}