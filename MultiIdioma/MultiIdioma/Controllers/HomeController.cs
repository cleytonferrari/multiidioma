using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using MultiIdioma.Helper;

namespace MultiIdioma.Controllers
{
    public class HomeController : Controller
    {
        [Localization]
        public ActionResult Index()
        {
            return View();
        }

        [GET("{lang?}/Home/About")]
        [GET("{lang?}/Home/Sobre")]
        public ActionResult Sobre()
        {
            return View();
        }

    }
}