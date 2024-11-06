using LW_1.Models.Entities;
using LW_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace LW_1.Controllers
{
    public class Lab4Controller : Controller
    {
        // GET: Lab4
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditCashier(Guid? cashierId)
        {
            if (cashierId == null) return View();
            CashierVM model;
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                Сотрудник кассир = db.Сотрудник.Find(cashierId);
                Телефон телефон = db.Телефон.Find(кассир.id_телефона);
                model = new CashierVM(кассир);
                model.PhoneNumber = $"+7 {телефон.Код_города:D3}-{телефон.Уникальный_номер:D7}";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditCashier(CashierVM cashier)
        {
            if (ModelState.IsValid)
            {
                using (var db = new IDZ_Sergeev_SupermarketEntities1())
                {
                    Сотрудник кассир = db.Сотрудник.Find(cashier.Id);
                    if (кассир == null) { return HttpNotFound(); }
                    кассир.Фамилия = cashier.Фамилия;
                    кассир.Имя = cashier.Имя;
                    кассир.Отчество = cashier.Отчество;
                    кассир.Дата_рождения = cashier.Дата_рождения;
                    кассир.Пол = cashier.Пол;

                    db.Сотрудник.Attach(кассир);
                    db.Entry(кассир).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("CashierDetails", "Lab2V2", new { cashierId = cashier.Id });
            }
            return View(cashier);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteCashier(Guid? id)
        {
            if (id == null) return HttpNotFound();
            CashierVM cashier;
            using (var db = new IDZ_Sergeev_SupermarketEntities1())
            {
                Сотрудник кассир = db.Сотрудник.Find(id);
                cashier = new CashierVM(кассир);
            }
            return View(cashier);
        }

        [HttpPost, ActionName("DeleteCashier")]
        public ActionResult DeleteCashierConfirmed(Guid id)
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
            return RedirectToAction("ListOfCashier", "Lab2V2");
        }

        /*
        [HttpGet]
        public ActionResult EditGroup(Guid? groupID)
        {
            if (groupID == null) return View();
            GroupVM model;
            using (var context = new TPUEntities())
            {
                Группы group = context.Группы.Find(groupID);
                model = new GroupVM
                {
                    ID_группы = group.ID_группы,
                    ID_института = group.ID_института,
                    Наименование = group.Наименование,
                    Год_поступления = group.Год_поступления,
                    Длительность_обучения = group.Длительность_обучения,
                    Код_формы_обучения = group.Код_формы_обучения,
                    Код_направления_подготовки = group.Код_направления_подготовки
                };
            }

            Dictionary<string, Guid> institutes = new Dictionary<string, Guid>();
            Dictionary<string, int> formOfTraining = new Dictionary<string, int>();
            Dictionary<string, string> areasOfTraining = new Dictionary<string, string>();


            using (var db = new TPUEntities())
            {
                institutes = db.Институты.ToDictionary(x => x.Наименование, x => x.ID_института);
                formOfTraining = db.Формы_обучения.ToDictionary(x => x.Наименование, x => x.Код_формы_обучения);
                areasOfTraining = db.Направления_подготовки.ToDictionary(x => x.Наименование, x => x.Код_направления_подготовки);
            }

            ViewBag.Institutes = new SelectList(institutes, "Value", "Key");
            ViewBag.FormOfTraining = new SelectList(formOfTraining, "Value", "Key");
            ViewBag.AreasOfTraining = new SelectList(areasOfTraining, "Value", "Key");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditGroup(GroupVM model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new TPUEntities())
                {
                    Группы group = new Группы
                    {
                        ID_группы = model.ID_группы,
                        ID_института = model.ID_института,
                        Наименование = model.Наименование,
                        Год_поступления = model.Год_поступления,
                        Длительность_обучения = model.Длительность_обучения,
                        Код_формы_обучения = model.Код_формы_обучения,
                        Код_направления_подготовки = model.Код_направления_подготовки
                    };

                    context.Группы.Attach(group);
                    context.Entry(group).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("ListGroup", "Lab2");
                }
            }

            Dictionary<string, Guid> institutes = new Dictionary<string, Guid>();
            Dictionary<string, int> formOfTraining = new Dictionary<string, int>();
            Dictionary<string, string> areasOfTraining = new Dictionary<string, string>();


            using (var db = new TPUEntities())
            {
                institutes = db.Институты.ToDictionary(x => x.Наименование, x => x.ID_института);
                formOfTraining = db.Формы_обучения.ToDictionary(x => x.Наименование, x => x.Код_формы_обучения);
                areasOfTraining = db.Направления_подготовки.ToDictionary(x => x.Наименование, x => x.Код_направления_подготовки);
            }

            ViewBag.Institutes = new SelectList(institutes, "Value", "Key");
            ViewBag.FormOfTraining = new SelectList(formOfTraining, "Value", "Key");
            ViewBag.AreasOfTraining = new SelectList(areasOfTraining, "Value", "Key");

            return View(model);
        }

        [HttpGet]
        public ActionResult EditStudent(Guid? studentID)
        {
            if (studentID == null) return View();
            StudentVM studentVM;

            using (var context = new TPUEntities())
            {

                Студенты student = context.Студенты.Find(studentID);

                studentVM = new StudentVM
                {
                    ID_студента = student.ID_студента,
                    Фамилия = student.Фамилия,
                    Имя = student.Имя,
                    Отчество = student.Отчество,
                    Пол = student.Пол,
                    Адрес_проживания = student.Адрес_проживания,
                    Дата_рождения = student.Дата_рождения,
                    Уровень_владения_ИЯ = student.Уровень_владения_ИЯ
                };
            }
            List<Tuple<string, bool>> s = new List<Tuple<string, bool>> {
                new Tuple<string, bool>("Женский", false),
                new Tuple<string, bool>("Мужской", true)
            };

            ViewBag.S = new SelectList(s, "Item2", "Item1");


            return View(studentVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult EditStudent(StudentVM model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new TPUEntities())
                {
                    Студенты student = new Студенты
                    {
                        ID_студента = model.ID_студента,
                        Фамилия = model.Фамилия,
                        Имя = model.Имя,
                        Отчество = model.Отчество,
                        Пол = model.Пол,
                        Адрес_проживания = model.Адрес_проживания,
                        Дата_рождения = model.Дата_рождения,
                        Уровень_владения_ИЯ = model.Уровень_владения_ИЯ
                    };
                    context.Студенты.Attach(student);
                    context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    return RedirectToAction("ListStudents", "Lab2");
                }
            }

            List<Tuple<string, bool>> s = new List<Tuple<string, bool>> {
                new Tuple<string, bool>("Женский", false),
                new Tuple<string, bool>("Мужской", true)
            };

            ViewBag.S = new SelectList(s, "Item2", "Item1");


            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteGroup(Guid? groupID)
        {
            if (groupID == null) return View();
            GroupVM groupToDelete;
            using (var context = new TPUEntities())
            {
                Группы group = context.Группы.Find(groupID);
                groupToDelete = new GroupVM {
                    ID_группы = group.ID_группы,
                    ID_института = group.ID_института,
                    Наименование = group.Наименование,
                    Год_поступления = group.Год_поступления,
                    Длительность_обучения = group.Длительность_обучения,
                    Код_формы_обучения = group.Код_формы_обучения,
                    Код_направления_подготовки = group.Код_направления_подготовки
                };
            }
            return View(groupToDelete);
        }

        [HttpPost, ActionName("DeleteGroup")]
        public ActionResult DeleteGroupConfirmed(Guid groupID)
        {
            using (var context = new TPUEntities())
            {
                Группы groupToDelete = new Группы { 
                    ID_группы = groupID
                };
                context.Entry(groupToDelete).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return RedirectToAction("ListGroup", "Lab2");
        }*/
    }
}