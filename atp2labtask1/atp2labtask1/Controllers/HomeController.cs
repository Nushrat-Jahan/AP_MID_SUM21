using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atp2labtask1.Models;
using atp2labtask1.Models.Database;

namespace atp2labtask1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Allstudent()
        {
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        }

        public ActionResult AddStudent()
        {
            Student S = new Student();
            return View(S);

        }
        [HttpPost]
        public ActionResult AddStudent(Student S)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Insert(S);
                return RedirectToAction("Allstudent");
            }
            return View();
        }

        public ActionResult EditStudent(int id)
        {

            Database db = new Database();
            var S = db.Students.Get(id);

            return View(S);
        }
        [HttpPost]
        public ActionResult EditStudent(Student S)
        {
            //update to db
            Database db = new Database();
            db.Students.Update(S);
            return RedirectToAction("Allstudent");
        }

        public ActionResult DeleteStudent(int id)
        {
            Database db = new Database();
            db.Students.Delete(id);
            return View();
        }

    }
}