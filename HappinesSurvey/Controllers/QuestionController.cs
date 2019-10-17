using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.DAL;
using System.Data.Entity;
using HappinessSurvey.BAL.Interface;
using HappinessSurvey.BAL.Implementation;
using HappinessSurvey.Model.ViewModels;
using HappinessSurvey.Model.Models;



namespace HappinesSurvey.Controllers
{
    public class QuestionController : Controller
    {
   
      //[App_Start.FilterConfig]
        // GET: Question
        public ActionResult Index()
        {
            if (Session["RoleID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View("question");
           
            
        }

        public ActionResult getdata()
        {
            try
            {
                using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
                {
                    var listvalue = (from q in entities.questiontbls select q).ToList();

                    List<Questionmodel> questions = new List<Questionmodel>();

                    foreach (var item in listvalue)
                    {
                        Questionmodel question = new Questionmodel();
                        question.q_id = item.q_id;
                        question.questions = item.question;
                        questions.Add(question);
                    }

                    // List<questiontbl> listvalue = entities.questiontbls.ToList<questiontbl>();
                    return Json(new { data = questions }, JsonRequestBehavior.AllowGet);
                }
            }catch(Exception ex)
            {
                throw;
            }
               
        }

     
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            try
            {
                using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
                {
                    Questionmodel questionmodel = new Questionmodel();
                    List<Questionmodel> qlist = new List<Questionmodel>();
                    var question = (from q in entities.questiontbls
                                    where q.q_id == ID
                                    select q).FirstOrDefault();
                    questionmodel.q_id =  question.q_id;
                    questionmodel.questions= question.question ;
                    return View("Edit",questionmodel);
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [HttpPost]
        public ActionResult Edit(Questionmodel questionmodel)
        {
            try
            {
                using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
                {
                    var modiques = entities.questiontbls.Where(a => a.q_id.Equals(questionmodel.q_id)).First();
                    // questionmodel.q_id = modiques.q_id;

                    // List < Questionmodel > qlist = new List<Questionmodel>();                  
                    modiques.question = questionmodel.questions;
                    entities.SaveChanges();
                    return View("question");
                }
            }
            catch (Exception)
            {
                throw;
            }
           //eturn View("Edit", questionmodel);
        }
        //[HttpGet]
        //public ActionResult delete()
        //{
        //    return View("question");
        //}

        [HttpPost]
        public JsonResult delete(int? id)
        {
            try
            {
               
                    using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
                    {
                    if (id == null)
                    {
                        return Json(new { data = "Not Deleted" }, JsonRequestBehavior.AllowGet);
                    }
                        var deleteques = entities.questiontbls.Find(id);
                        entities.questiontbls.Remove(deleteques);
                        entities.SaveChanges();
                        return Json(new { data = "Delete" }, JsonRequestBehavior.AllowGet);
                    
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public ActionResult Create()
        {
            var addque = new Questionmodel();
            addque.questions = "";
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Questionmodel questionmodel)
        {
            try
            {
                using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
                {
                    //var addques = entities.questiontbls.Where(a => a.q_id.Equals(questionmodel.q_id)).First();
                    questiontbl ques = new questiontbl();
                    // List < Questionmodel > qlist = new List<Questionmodel>();                  
                    ques.question = questionmodel.questions;
                    entities.questiontbls.Add(ques);
                    entities.SaveChanges();
                    return View("question");
                }
            }
            catch (Exception)
            {
                throw;
            }
           // return View("Edit");
        }
    }
}