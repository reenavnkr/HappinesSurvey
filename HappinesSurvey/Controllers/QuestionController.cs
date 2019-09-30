using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.BAL.Interface;
using HappinessSurvey.BAL.Implementation;
using HappinessSurvey.Model.ViewModels;

namespace HappinesSurvey.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index(UserDisplayViewModel user)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["isuserId"]);
                ILogin _ud = new Login();

                UserDisplayViewModel model = new UserDisplayViewModel();
                model = _ud.isdetail(id);
                return View("question", model);
               
            }
                return View("AdminDashboard");
        }
    }
}