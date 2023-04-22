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

            string text = form["txtSearch"];      // text tìm kiếm 
            int sub_droplist = Convert.ToInt32(form["id_subject"]);   // droplist 

            if (sub_droplist == 0 && String.IsNullOrEmpty(text))
            {
                ViewBag.ListSubject = Model.GetSubjects();
                return View(Model.GetListTest());
            }
            else
            {
                if (String.IsNullOrEmpty(text) && sub_droplist > 0)
                {

                    ViewBag.ListSubject = Model.GetSubjects();
                    return View(Model.GetListTestBySubject(sub_droplist));
                }
                else
                {
                    if (!String.IsNullOrEmpty(text) && sub_droplist == 0)
                    {

                        ViewBag.ListSubject = Model.GetSubjects();
                        return View(Model.GetListTestByName(text));
                    }

                    ViewBag.ListSubject = Model.GetSubjects();
                    return View(Model.GetListTestBySubject_Name(sub_droplist, text));
                }
            }
        }


        public ActionResult DeLuyenTap(FormCollection form)
        {
            if (!user.IsTeacher())
                return View("Error");
            Model.UpdateLastLogin();
            Model.UpdateLastSeen("Trang Chủ", Url.Action("DeLuyenTap"));
            //int id_subject = Convert.ToInt32(form["txtSearch"]);

            string text = form["txtSearch"];      // text tìm kiếm 
            int sub_droplist = Convert.ToInt32(form["id_subject"]);   // droplist 

            if (sub_droplist == 0 && String.IsNullOrEmpty(text))
            {
                ViewBag.ListSubject = Model.GetSubjects();
                return View(Model.DeLuyenTap());
            }
            else
            {
                if (String.IsNullOrEmpty(text) && sub_droplist > 0)
                {

                    ViewBag.ListSubject = Model.GetSubjects();
                    return View(Model.DeLuyenTapBySubject(sub_droplist));
                }
                else
                {
                    if (!String.IsNullOrEmpty(text) && sub_droplist == 0)
                    {

                        ViewBag.ListSubject = Model.GetSubjects();
                        return View(Model.DeLuyenTapByName(text));
                    }

                    ViewBag.ListSubject = Model.GetSubjects();
                    return View(Model.DeLuyenTapSubject_Name(sub_droplist, text));
                }
            }
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