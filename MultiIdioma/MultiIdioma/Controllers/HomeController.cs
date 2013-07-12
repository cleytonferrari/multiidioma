using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiIdioma.Helper;

namespace MultiIdioma.Controllers
{
    public class HomeController : Controller
    {
        //para testar 
        // http://localhost:XXXX/en-US
        // http://localhost:XXXX/pt-BR


        [Localization]
        public ActionResult Index()
        {
            return View();
        }

    }
}