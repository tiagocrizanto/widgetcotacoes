using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cotacoes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetCotacoes()
        {
            string json_data = "";
            using (var w = new WebClient())
            {
                try
                {
                    IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                    defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                    w.Proxy = defaultWebProxy;
                    json_data = w.DownloadString("http://webservices.infoinvest.com.br/cotacoes/cotacoes_handler.asp?&quotes=&quotes=sp.petr4&quotes=sp.itub4&quotes=sp.pcar4&quotes=BR.IBOVESPA&quotes=US.DOLARC");
                }
                catch (Exception ex)
                {
                    throw new Exception("", ex);
                }
            }
            return Json(json_data, JsonRequestBehavior.AllowGet);
        }
    }
}