using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Models;
using TracNghiemOnline.Common;

namespace TracNghiemOnline.Controllers
{
    public class AdminController : Controller
    {
        private tracnghiemEntities db = new tracnghiemEntities();

        User user = new User();
        AdminDA Model = new AdminDA();
        // GET: Admin
        public ActionResult Index()
        {
            if (!user.IsAdmin())
                return View("Error");
            Model1.UpdateLastLogin();
            Model1.UpdateLastSeen("Trang Chủ", Url.Action("Index"));
            Dictionary<string, int> ListCount = Model1.GetDashBoard();
            return View(ListCount);
        }


    }
}
