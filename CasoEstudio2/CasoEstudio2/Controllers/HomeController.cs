﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            return View();
        }
    }
}