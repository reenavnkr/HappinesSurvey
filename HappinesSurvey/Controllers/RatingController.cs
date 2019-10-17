using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.DAL;
using HappinessSurvey.Model.Models;
using HappinessSurvey.Model.ViewModels;

namespace HappinesSurvey.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                if (Session["RoleID"] == null)

                {
                    return RedirectToAction("Login", "Home");
                   
                }
                int id = Convert.ToInt32(Session["isuserId"]);
                //select sq.sq_id,q.question,us.sur_id from questiontbl as q 
                //    inner join surveyquestion as sq on sq.q_id = q.q_id 
                //    full join userSurvey as us on sq.sur_id = us.sur_id 
                //    where us.user_id = 7

                var list = (from q in entities.questiontbls
                            join qs in entities.surveyquestions on q.q_id equals qs.q_id
                            join us in entities.userSurveys on qs.sur_id equals us.sur_id
                            where us.user_id == id
                            select new
                            {
                                qs.sq_id,
                                q.question,
                                q.q_id,
                                us.sur_id
                            }).ToList();


                List<Ratingmodel> questionmodelList = new List<Ratingmodel>();

                foreach (var l in list)
                {

                    Ratingmodel questionmodel = new Ratingmodel();
                    questionmodel.sur_id = l.sur_id;
                    questionmodel.sq_id = l.sq_id;
                    questionmodel.ques = l.question;
                    questionmodelList.Add(questionmodel);


                }
                return View(questionmodelList);


                //  return View();

            }

        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //int va = valueid;
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                string[] questions = Request.Form.GetValues("questionid");

               
                int userid = Convert.ToInt32(Session["isuserId"]);
                int roleno = Convert.ToInt32(Session["RoleID"]);


             

                //List<Submitsurvey> submitsurveys = new List<Submitsurvey>();

                foreach (var question in questions)
                {
                    String rat = Request.Form.Get("rank+" + question);
                    String comment = Request.Form.Get("comment+" + question);
                    String surveryid = Request.Form.Get("surveryid+" + question);

                    Submitsurvey submitsurvey = new Submitsurvey();
                    submitsurvey.rating = Convert.ToInt32(rat);
                    submitsurvey.comment = comment;
                    submitsurvey.sur_id = Convert.ToInt32(surveryid);
                    submitsurvey.u_id = userid;
                    submitsurvey.role_id = roleno;
                    submitsurvey.sq_id = Convert.ToInt32(question);
                    entities.Submitsurveys.Add(submitsurvey);
                    entities.SaveChanges();
                }
            }
          // string[] value =  Request.Form.GetValues("Country");
            return RedirectToAction("Index","Rating");

        }
    }
}


      