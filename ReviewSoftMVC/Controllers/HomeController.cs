using ReviewSoftMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReviewSoftMVC.Controllers
{

    public class HomeController : Controller
    {
        private REVIEWSOFTEntities db = new REVIEWSOFTEntities();
        private DefaultConnectionEntities2 dc = new DefaultConnectionEntities2();

        public ActionResult Index()
        {
            if (Session["useRol"] != null) {

                if (Session["useRol"].ToString().Equals("1"))
                {
                   return RedirectToAction("Administrador", "Account");
                }
              
            }
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
    }
}