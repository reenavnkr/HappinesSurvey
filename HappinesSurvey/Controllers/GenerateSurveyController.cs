using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappinessSurvey.DAL;

namespace HappinesSurvey.Controllers
{
    public class GenerateSurveyController : Controller
    {
        // GET: GenerateSurvey
        public ActionResult Index()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                //var depdata = new SelectList(entities.departmenttbls.ToList(),"dep_id","dep_name").to;
               List < SelectListItem > departmentlist = Getdepartment();
                ViewData["Department"] = departmentlist;

                // var prodata = new SelectList(entities.projecttbls.ToList(), "pro_id", "pro_name");
                List<SelectListItem> projectlist = Getproject();
                ViewData["Project"] = projectlist;

                // var roledata = new SelectList(entities.roletbls.ToList(), "role_id", "role_name");
                List<SelectListItem> rolelist = Getrole();
                ViewData["Role"] = rolelist;

                var qlist = from q in entities.questiontbls select new { q.q_id,q.question };

                foreach (var v in qlist)
                {
                    items.Add(new SelectListItem
                    {
                        Value = v.q_id.ToString(),
                        Text = v.question.ToString()

                    });
                }
                
            }
                return View("Questionlist", items);
        }

        [HttpPost]
        public ActionResult Index(List<SelectListItem> items ,FormCollection form )
        {

            string ddldep =Request.Form["Departmentddl"].ToString();
            string ddlproj = Request.Form["Projectddl"].ToString();
            string ddlrole = Request.Form["Roleddl"].ToString();

            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {
                int id,ids;
                //  ViewBag.Message = "Selected Items:\\n";
                foreach (SelectListItem item in items)
                {
                    if (item.Selected)
                    {
                        try
                        {
                            var surveyCre = new surveytbl();
                            {
                                surveyCre.role_id = Convert.ToInt32(ddlrole);
                                surveyCre.Start_date = DateTime.Now;
                                surveyCre.End_date = DateTime.Today.Date.AddDays(3);
                                surveyCre.proj_id = Convert.ToInt32(ddlproj);
                                surveyCre.Dep_id = Convert.ToInt32(ddldep);
                                entities.surveytbls.Add(surveyCre);
                                entities.SaveChanges();
                                ids = surveyCre.sur_id;
                                entities.SaveChanges();

                                //surveyCre.role_id = 1;
                                //surveyCre.Start_date = DateTime.Today.Date;
                                //surveyCre.End_date = DateTime.Today.Date.AddDays(3);
                                //surveyCre.proj_id = 1;
                                //surveyCre.Dep_id = 1;
                                //entities.surveytbls.Add(surveyCre);
                                //entities.SaveChanges();
                                //ids = surveyCre.sur_id;
                                
                                if (ids != 0)
                                {
                                    surveyquestion surveyq = new surveyquestion();
                                    {
                                        // var surcreid = (from q in entities.surveytbls select q.sur_id).FirstOrDefault();

                                        surveyq.sur_id = ids;
                                        surveyq.q_id = Convert.ToInt32(item.Value);
                                        entities.surveyquestions.Add(surveyq);
                                        entities.SaveChanges();
                                        // id = surveyq.sq_id;
                                    }

                                }
                            }
                        }
                        catch (Exception ex)
                        {

                           
                        }
                        
                        
                        // ViewBag.Message += string.Format("{0}\\n", item.Text);
                    }
                }
               
              
            }
            

            return RedirectToAction("Index", "GenerateSurvey");
        }


            // GET: GenerateSurvey/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        private static List<SelectListItem> Getdepartment()
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {

                List<SelectListItem> departmentList = (from p in entities.departmenttbls.AsEnumerable()
                                                     select new SelectListItem
                                                     {
                                                         Text = p.dep_name.ToString(),
                                                         Value = p.dep_id.ToString()
                                                     }).ToList();


                //Add Default Item at First Position.
                departmentList.Insert(0, new SelectListItem { Text = "--Select Department--", Value = "0" });
                return departmentList;
            }
        }

        private static List<SelectListItem> Getproject()
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {

                List<SelectListItem> projectList = (from p in entities.projecttbls.AsEnumerable()
                                                       select new SelectListItem
                                                       {
                                                           Text = p.pro_name.ToString(),
                                                           Value = p.pro_id.ToString()
                                                       }).ToList();


                //Add Default Item at First Position.
                projectList.Insert(0, new SelectListItem { Text = "--Select Project--", Value = "0" });
                return projectList;
            }


        }

        private static List<SelectListItem> Getrole()
        {
            using (HapinessSurveyEntities entities = new HapinessSurveyEntities())
            {

                List<SelectListItem> roleList = (from p in entities.roletbls.AsEnumerable()
                                                       select new SelectListItem
                                                       {
                                                           Text = p.role_name.ToString(),
                                                           Value = p.role_id.ToString()
                                                       }).ToList();


                //Add Default Item at First Position.
                roleList.Insert(0, new SelectListItem { Text = "--Select Role--", Value = "0" });
                return roleList;
            }


        }
    }
}
