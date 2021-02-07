using System;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace WebDevedor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Informações";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contato";
            return View();
        }
    }
}