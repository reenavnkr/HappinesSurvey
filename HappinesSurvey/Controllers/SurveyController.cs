using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.DAL;

namespace HappinesSurvey.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult Index()
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                if(Session["RoleID"] == null)
                {
                    RedirectToAction("Login", "Home");
                  
                }

                int rid = Convert.ToInt32(Session["RoleID"]);
                if (rid == 4)
                {

                }
                if (rid == 5)
                {

                }
                if (rid == 6)
                {

                }

            }
                return View();
        }
    }
}