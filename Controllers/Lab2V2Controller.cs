using LW_1.Models.Entities;
using LW_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace LW_1.Controllers
{
    public class Lab2V2Controller : Controller
    {
        // GET: Lab2V2
        [AllowAnonymous]
        public ActionResult ListOfCashier()
        {
            List<Сотрудник> cashier = new List<Сотрудник>();
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                cashier = db.Сотрудник.ToList();
            }
            return View(cashier);
        }

        [AllowAnonymous]
        public ActionResult ListOfCashiersPartialView()
        {
            List<CashierVM> cashiers = new List<CashierVM>();
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                var kassirs = db.Сотрудник.ToList();
                cashiers = kassirs.Select(k => new CashierVM(k)).ToList();
            }
            return PartialView("_CashierList", cashiers);
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult CashierDetails(Guid? cashierId)
        {
            if (cashierId == null) return View();
            CashierVM model;
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                Сотрудник кассир = db.Сотрудник.Find(cashierId);
                model = new CashierVM(кассир);
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ListOfProducts()
        {
            List<Товары> products = new List<Товары>();
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                products = db.Товары.ToList();
            }
            return View(products);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ProductDetails(long? id)
        {
            if (id == null) return View();
            Товары product = new Товары();
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                product = db.Товары.Find(id);

            }
            return View(product);
        }
    }
}