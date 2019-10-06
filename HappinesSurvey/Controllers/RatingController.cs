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
                //select top 1 sq_id, question from teamtbl as t 
                //    left join surveytbl as st on t.pro_id = st.proj_id 
                //    left join surveyquestion as sq on sq.sur_id = st.sur_id 
                //    left join questiontbl as qt on sq.q_id = qt.q_id 
                //    where t.user_id = 2  
                //    order by Start_date desc

                  int id = Convert.ToInt32( Session[""]);
                var QueRateList = (from t in entities.teamtbls
                                    join st in entities.surveytbls on t.pro_id equals st.proj_id
                                    join sq in entities.surveyquestions on st.sur_id equals sq.sur_id
                                    join qt in entities.questiontbls on sq.sur_id equals qt.q_id
                                    where t.user_id == id
                                    orderby st.sur_id descending
                                    select new
                                    {
                                        sq.sq_id ,
                                        qt.question

                                     }).FirstOrDefault();
                //  List<>
                //foreach (var v in  )
                //{

                //}
                return View();



            }
          
        }
    }
}