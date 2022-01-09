using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Squad21.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Idioma()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Doacoes()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}