using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace atp2labtask1.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllDepartment()
        {
            return View();
        }

        public ActionResult AddDepartment()
        {
            return View();
        }
    }
}