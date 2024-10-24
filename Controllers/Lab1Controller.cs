using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW_1.Controllers
{
    public class Lab1Controller : Controller
    {

        // GET: Lab1
        public ActionResult FirstViewMethod()
        {
            List<string> vegatebles = GetVegetablesList();
            return View(vegatebles);
        }

        public ActionResult SecondViewMethod()
        {
            return View(GetVegetablesList().OrderBy(x => x).ToList());
        }

        public ActionResult ThirdViewMethod() 
        {
            return View(GetVegetablesList().OrderBy(x => x).ToList());
        }

        public List<string> GetVegetablesList()
        {
            List<string> vagetables = new List<string> {
                "Томат",
                "Огурец",
                "Картофель",
                "Кабачок",
                "Баклажан",
                "Капуста",
                "Брокколи"
            };
            return vagetables;
        }
    }
}