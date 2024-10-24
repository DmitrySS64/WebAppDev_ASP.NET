using LW_1.Models.Entities;
using LW_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW_1.Controllers
{
    public class Lab3Controller : Controller
    {
        // GET: Lab3
        [HttpGet]
        public ActionResult CreateGroup()
        {
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

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateGroup(GroupVM newGroup)
        {
            if(ModelState.IsValid)
            {
                using (var context = new TPUEntities())
                {
                    Группы group = new Группы
                    {
                        ID_группы = Guid.NewGuid(),
                        ID_института = newGroup.ID_института,
                        Наименование = newGroup.Наименование,
                        Год_поступления = newGroup.Год_поступления,
                        Длительность_обучения = newGroup.Длительность_обучения,
                        Код_формы_обучения = newGroup.Код_формы_обучения,
                        Код_направления_подготовки = newGroup.Код_направления_подготовки
                    };
                    context.Группы.Add(group);
                    context.SaveChanges();
                }
                return RedirectToAction("ListGroup", "Lab2");
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

            return View(newGroup);
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            List<Tuple<string, bool>> s = new List<Tuple<string, bool>> { 
                new Tuple<string, bool>("Женский", false),
                new Tuple<string, bool>("Мужской", true)
            };

            ViewBag.S = new SelectList(s, "Item2", "Item1");


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateStudent(StudentVM newStudent)
        {
            if (ModelState.IsValid)
            {
                using (var context = new TPUEntities())
                {
                    Студенты student = new Студенты
                    {
                        ID_студента = Guid.NewGuid(),
                        Фамилия = newStudent.Фамилия,
                        Имя = newStudent.Имя,
                        Отчество = newStudent.Отчество,
                        Пол = newStudent.Пол,
                        Адрес_проживания = newStudent.Адрес_проживания,
                        Дата_рождения = newStudent.Дата_рождения,
                        Уровень_владения_ИЯ = newStudent.Уровень_владения_ИЯ
                    };
                    context.Студенты.Add(student);
                    context.SaveChanges();
                }
                return RedirectToAction("ListStudents", "Lab2");
            }
            List<Tuple<string, bool>> s = new List<Tuple<string, bool>> {
                new Tuple<string, bool>("Женский", false),
                new Tuple<string, bool>("Мужской", true)
            };

            ViewBag.S = new SelectList(s, "Item2", "Item1");

            return View(newStudent);
        }
    }
}