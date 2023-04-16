using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Common;
using TracNghiemOnline.Models;
namespace TracNghiemOnline.Controllers
{
    public class TeacherController : Controller
    {
        User user = new User();
        TeacherDA Model = new TeacherDA();
        // GET: Teacher
        public ActionResult Index(FormCollection form)
        {
            if (!user.IsTeacher())
                return View("Error");
            Model.UpdateLastLogin();
            Model.UpdateLastSeen("Trang Chủ", Url.Action("Index"));
            //int id_subject = Convert.ToInt32(form["txtSearch"]);
            string id_subject = form["txtSearch"];
            
            if (id_subject == null )
                return View(Model.GetListTest());
            else
                //return View(Model.GetListTestBySubject(id_subject));
                return View(Model.GetListTestByName(id_subject));
        }

        public ActionResult Preview(int id)
        {
            if (!user.IsTeacher())
                return View("Error");
            var list = Model.GetListScore(id);
            ViewBag.test_code = id;
            ViewBag.total = list.Count;
            return View(list);
        }
        public ActionResult Logout()
        {
            if (!user.IsTeacher())
                return View("Error");
            user.Reset();
            return RedirectToAction("Index", "Login");
        }
    }
}