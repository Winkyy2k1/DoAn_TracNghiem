using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Models;
using TracNghiemOnline.Common;
namespace TracNghiemOnline.Controllers
{
    public class HomeController : Controller
    {
        User user = new User();

        StudentDA Model = new StudentDA();
        // GET: Home
        public ActionResult Index() 
        {            
            return View(Model.GetDashboard());
        }
        
        public ActionResult About()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
    }
}