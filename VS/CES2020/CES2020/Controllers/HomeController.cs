using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CES2020.Integrs;
using CES2020.Integrs.dto;
using CES2020.Models;

namespace CES2020.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ForbindelseDto());
        }

        [HttpPost]
        public ActionResult Index(ForbindelseDto ff)
        {
            ConnectionsIntegration oc = new ConnectionsIntegration();
            List<ForbindelseDto> ocean = oc.GetOceanicRoutes(ff);
            Forsendelse fors = new Forsendelse();
            ForbindelseDto fb = new ForbindelseDto();
            fb.To = ocean[0].To;
            fb.From = ocean[0].From;
            return View(fb);
        }
    }
}
