using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.DAL;

namespace HappinesSurvey.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                //var ratelist = from q in entities.surveyquestions join s in entities.surveytbls on q.sur_id equals s.sur_id
                //               join t in entities.teamtbls on s.proj_id equals t.pro_id;
            }
                return View();
        }
    }
}