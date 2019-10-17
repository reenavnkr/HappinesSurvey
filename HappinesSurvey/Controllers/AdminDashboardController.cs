using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappinesSurvey.Controllers
{
    public class AdminDashboardController : Controller
    {
        [App_Start.FilterConfig]
        // GET: AdminDashboard
        public ActionResult Index()
        {
            if (Session["RoleID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View("~/Home/AdminDashboard");
           
        }
       
    }
}