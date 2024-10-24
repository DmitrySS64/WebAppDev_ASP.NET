using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LW_1.Models.Entities;

namespace LW_1.Controllers
{
    public class Lab2Controller : Controller
    {
        // GET: Lab2
        public ActionResult ListCallSchedule()
        {
            List<CallSchedule> Call = new List<CallSchedule>();
            using (var db = new SchoolDBEntities())
            {
                Call = db.CallSchedule.ToList();
            }
            return View(Call);
        }

        [HttpGet]
        public ActionResult GetCallSchedule(int? callId)
        {
            if (callId == null) { return View(); }
            CallSchedule model = new CallSchedule();
            using (var db = new SchoolDBEntities())
            {
                model = db.CallSchedule.Find(callId);
            }
            return View(model);
        }

        public ActionResult ListGroup()
        {
            List<Группы> Groups = new List<Группы>();
            //Dictionary<Guid, >
            using (var db = new TPUEntities())
            {
                Groups = db.Группы.ToList();
            }

            return View(Groups);
        }

        [HttpGet]
        public ActionResult GetGroup(Guid? groupID)
        {
            if (groupID == null) { return View(); }
            Группы model = new Группы();
            using (var db = new TPUEntities())
            {
                model = db.Группы.Find(groupID);
            }
            return View(model);
        }

        public ActionResult ListStudents()
        {
            List<Студенты> Groups = new List<Студенты>();
            using (var db = new TPUEntities())
            {
                Groups = db.Студенты.ToList();
            }
            return View(Groups);
        }

        [HttpGet]
        public ActionResult GetStudent(Guid? studentID)
        {
            if (studentID == null) { return View(); }
            Студенты model = new Студенты();
            using (var db = new TPUEntities())
            {
                model = db.Студенты.Find(studentID);
            }
            return View(model);
        }

        public ActionResult TestGrid()
        {
            return View();
        }
    }
}