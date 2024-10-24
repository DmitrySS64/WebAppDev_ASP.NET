using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controllers = new List<Type>
            {
                typeof(Lab1Controller),
                typeof(Lab2Controller),
                typeof(Lab3Controller),
                typeof(Lab4Controller)
            };
            return View(controllers);
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