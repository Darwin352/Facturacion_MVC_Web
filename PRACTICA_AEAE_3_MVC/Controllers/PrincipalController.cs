﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRACTICA_AEAE_3_MVC.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ayuda()
        {
            return View();
        }
        public ActionResult Acerca()
        {
            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }
    }
}