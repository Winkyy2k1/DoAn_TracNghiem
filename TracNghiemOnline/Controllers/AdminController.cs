using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TracNghiemOnline.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult AdminManager()
        {
            return View();
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        public ActionResult DeleteAdmin(string id)
        {
            return RedirectToAction("AdminManager");
        }
        public ActionResult DeleteAdmin(FormCollection form)
        {
            return RedirectToAction("AdminManager");
        }

        public ActionResult EditAdmin(string id)
        {
            return RedirectToAction("AdminManager");
        }

        public ActionResult EditAdmin(FormCollection form)
        {

            return RedirectToAction("EditAdmin/");
        }
        public ActionResult TeacherManager()
        {

            return View();
        }
        public ActionResult AddTeacher(FormCollection form)
        {
            return RedirectToAction("TeacherManager");
        }

        public ActionResult DeleteTeacher(string id)
        {
            return RedirectToAction("TeacherManager");
        }
        public ActionResult DeleteTeacher(FormCollection form)
        {
            return RedirectToAction("TeacherManager");
        }
        public ActionResult EditTeacher(string id)
        {
            return View();
        }
        public ActionResult EditTeacher(FormCollection form)
        {
            return RedirectToAction("EditTeacher/");
        }

        public ActionResult StudentManager()
        {
            return View();
        }
        public ActionResult AddStudent(FormCollection form)
        {
            return RedirectToAction("StudentManager");
        }
        public ActionResult DeleteStudent(string id)
        {
            return RedirectToAction("StudentManager");
        }
        [HttpPost]
        public ActionResult DeleteStudent(FormCollection form)
        {
            return RedirectToAction("StudentManager");
        }
        public ActionResult EditStudent(string id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditStudent(FormCollection form)
        {
            return RedirectToAction("EditStudent/");
        }
        public ActionResult ClassManager()
        {
            return View();
        }
        public ActionResult AddGrade(FormCollection form)
        {
            return RedirectToAction("ClassManager");
        }
        public ActionResult AddClass(FormCollection form)
        {
            return RedirectToAction("ClassManager");
        }
        public ActionResult DeleteClass(string id)
        {
            return RedirectToAction("ClassManager");
        }
        public ActionResult DeleteClass(FormCollection form)
        {
            return RedirectToAction("ClassManager");
        }
        public ActionResult EditClass(string id)
        {
            return View();
        }
        public ActionResult EditClass(FormCollection form)
        {
            return RedirectToAction("EditClass/");
        }
        public ActionResult SpecialityManager()
        {
            return View();
        }
        public ActionResult AddSpeciality(FormCollection form)
        {
            return RedirectToAction("SpecialityManager");
        }
        public ActionResult DeleteSpeciality(string id)
        {
            return RedirectToAction("SpecialityManager");
        }
        public ActionResult DeleteSpeciality(FormCollection form)
        {
            return RedirectToAction("SpecialityManager");
        }
        public ActionResult EditSpeciality(string id)
        {
            return View();
        }
        public ActionResult EditSpeciality(FormCollection form)
        {
            return RedirectToAction("EditSpeciality/");
        }
        public ActionResult SubjectManager()
        {
            return View();
        }
        public ActionResult AddSubject(FormCollection form)
        {
            return RedirectToAction("SubjectManager");
        }
        public ActionResult DeleteSubject(string id)
        {
            return RedirectToAction("SubjectManager");
        }
        public ActionResult DeleteSubject(FormCollection form)
        {
            return RedirectToAction("SubjectManager");
        }
        public ActionResult EditSubject(string id)
        {
            return View();
        }
        public ActionResult EditSubject(FormCollection form)
        {
            return RedirectToAction("EditSubject/");
        }
        public ActionResult QuestionManager()
        {
            return View();
        }
        public ActionResult AddQuestion(FormCollection form, HttpPostedFileBase File)
        {
            return RedirectToAction("QuestionManager");
        }
        public ActionResult DeleteQuestion(string id)
        {
            return RedirectToAction("QuestionManager");
        }
        public ActionResult DeleteQuestion(FormCollection form)
        {
            return RedirectToAction("QuestionManager");
        }
        public ActionResult EditQuestion(string id)
        {
            return View();
        }
        public ActionResult EditQuestion(FormCollection form, HttpPostedFileBase File)
        {
            return View();
        }
        public ActionResult TestManager()
        {
            return View();
        }
        public JsonResult GetJsonUnits(int id)
        {
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddTest(FormCollection form)
        {
            return RedirectToAction("TestManager");
        }
        public ActionResult EditTest(string id)
        {
            return View();
        }
        public ActionResult EditTest(FormCollection form)
        {
            return RedirectToAction("EditTest/" + 1);
        }
        public ActionResult ToggleStatus(int id)
        {
            return RedirectToAction("TestManager/" + 1);
        }
        public ActionResult TestDetail(string id)
        {
            return View();
        }

    }
}