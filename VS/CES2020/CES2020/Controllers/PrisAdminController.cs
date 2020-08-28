using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CES2020.Integrs;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Repositories;

namespace CES2020.Controllers
{
    public class PrisAdminController : Controller
    {
        [HttpGet]
        public ActionResult PrisAdmin()
        {
            var konfiguration = new KonfigurationRepository().Get();
            return View(konfiguration);
        }

    }
}
