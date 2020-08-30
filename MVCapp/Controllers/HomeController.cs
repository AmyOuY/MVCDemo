using MVCapp.Models;
using MVCData.Library.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCapp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewStudents()
        {
            ViewBag.Message = "Students List";

            var data = StudentProcessor.LoadStudents();
            List<StudentModel> students = new List<StudentModel>();

            foreach (var row in data)
            {
                students.Add(new StudentModel
                {
                    StudentId = row.StudentId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Email = row.Email,
                    ConfirmedEmail = row.Email
                });
            }

            return View(students);
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Student Sign Up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                StudentProcessor.CreateStudent(model.StudentId, model.FirstName, model.LastName, model.Email);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}