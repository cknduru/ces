using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CES2020.Integrs;
using CES2020.Integrs.dto;
using CES2020.Models;
using CES2020.Services;

namespace CES2020.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Forsendelse());
        }

        [HttpPost]
        public ActionResult Index(Forsendelse ff)
        {
            ff.Forsendelsesdato = new DateTime();

            RuteberegningService rbs = new RuteberegningService();

            rbs.GetBeregnedeRuter(ff);

            return View(ff);

        }
    }
}
