using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MultiIdioma.Helper
{
    public class LocalizedRazorViewEngine : RazorViewEngine
    {
        public LocalizedRazorViewEngine()
        {
            DefaultLanguageCode = "pt-BR";
        }
        public string DefaultLanguageCode { get; set; }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var language = DefaultLanguageCode;

            var controllerName = (string)controllerContext.RouteData.Values["controller"];

            if (controllerContext.RouteData.Values["lang"] != null 
                && !string.IsNullOrWhiteSpace(controllerContext.RouteData.Values["lang"].ToString()))
                language = controllerContext.RouteData.Values["lang"].ToString();

            if (language != "") language = "." + language;

            var masterPath = string.Format("~/Views/Shared/_Layout{0}.cshtml", language);
            var uri = string.Format("~/Views/{0}/{1}{2}.cshtml", controllerName, viewName, language);

            if (VirtualPathProvider.FileExists(uri))
                return new ViewEngineResult(CreateView(controllerContext, uri, masterPath), this);

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

    }
}