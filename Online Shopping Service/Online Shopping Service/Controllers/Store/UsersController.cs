﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shopping_Service.Controllers.Store
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}