using LW_1.Models.Entities;
using LW_1.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW_1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Authorize]
        public ActionResult Index(string searchQuery)
        {
            List<Сотрудник> staff = new List<Сотрудник>(); 
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                if (!String.IsNullOrEmpty(searchQuery))
                {
                    staff = db.Сотрудник.Where(e => 
                        e.Фамилия.Contains(searchQuery) || 
                        e.Имя.Contains(searchQuery) || 
                        e.Отчество.Contains(searchQuery)
                    ).ToList();
                } else
                {
                    staff = db.Сотрудник.ToList();
                }
            }
            return View(staff);
        }

        // GET: Employee/Details/5
        [Authorize]
        public ActionResult Details(Guid id)
        {
            Сотрудник employee;
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                employee = db.Сотрудник.Find(id);
            }
            if (employee == null) return HttpNotFound();

            var buttons = new List<ActionButton> {
                new ActionButton { Text = "Edit", Method="Edit", Controller = "Employee", Roles = { ERole.admin }, Parameters = new { id = id } },
                new ActionButton { Text = "Delete", Method="Delete", Controller = "Employee", Roles = { ERole.admin }, Parameters = new { id = id } }
            };
            
            var model = new Tuple<object, IEnumerable<ActionButton>>(employee, buttons);

            return PartialView("_EntityDetailsModel", model);
        }

        // GET: Employee/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Guid id)
        {
            return PartialView("_ConfirmDeleteModal", id);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                using (var context = new IDZ_Sergeev_SupermarketEntities1())
                {
                    Сотрудник сashierToDelete = new Сотрудник
                    {
                        id_сотрудника = id
                    };
                    context.Entry(сashierToDelete).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }

                return PartialView();
            }
            catch
            {
                return PartialView();
            }
        }
    }
}
