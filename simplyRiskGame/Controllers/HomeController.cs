using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace simplyRiskGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.myTroopLimit = 10;
            ViewBag.IATroopLimit = 10;
            return View();
        }

        //this methods are called with ajax
        [HttpPost]
        public ActionResult commit()
        {
            return Json(new { success = false, });
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