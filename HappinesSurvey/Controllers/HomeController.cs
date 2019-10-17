using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HappinessSurvey.DAL;
using HappinessSurvey.BAL.Interface;
using HappinessSurvey.BAL.Implementation;
using HappinessSurvey.Model.Models;
using HappinessSurvey.Model.ViewModels;


namespace HappinesSurvey.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Login()
        {

            if (Session["RoleID"] != null)
            {
                int id = Convert.ToInt32(Session["RoleID"]);
                if (id == 0)
                {
                    ViewBag.NoRole = "Role is not defined - contact to admin";
                }
            }
            return View();
           
        }
        // Post: Home
       [HttpPost]
        public ActionResult Login(Loginmodel objlogin)
        {
            if (ModelState.IsValid)
            {
                ILogin _login = new Login();
                Session["isuserId"] = _login.isUserAvailable(objlogin);//user id from login interface
                Session["RoleID"] = _login.isUserRoleID(objlogin); //role id from login interface
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["isuserId"]);
                ILogin _ud = new Login();
                Loginmodel objlogin = new Loginmodel();
                UserDisplayViewModel model = new UserDisplayViewModel();
                model = _ud.isdetail(id);
                TempData["dep_name"] = model.dep_name;
                TempData["user_name"] = model.user_name;

                if(Session["isuserId"] != null)
                {
                    int Roleid = (int)Session["RoleID"];
                    if (Roleid == 1)
                    { //admin
                      // return RedirectToAction("","")
                        return View("AdminDashboard");
                    }
                    else if (Roleid == 2)
                    {//Senior manager
                        return View("SeniorDashboard");
                     }
                    else if (Roleid == 3)
                    { //manager
                        return View("ManagerDashboard");
                    }
                    else if (Roleid == 4)
                    { //team leader
                        return View("teamladerDashboard");
                    }
                    else if (Roleid == 5)
                    { //team mamber
                        return View("TeammemberDashboard");
                       
                    }
                    else if (Roleid == 0)
                    {
                        //user.."name" role not define
                        return RedirectToAction("Login");
                    }
                    else if (Roleid == 6)
                    {
                        //here also check TL have TM access ?
                        //Roleid 4 and 5
                        return View("TMTLDashboard");

                    }

                }
            }
                return RedirectToAction("Login");
          
        }


        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ForgetPass()
        {
            return View("ForgetPass");

        }

        [HttpPost]
            public ActionResult ForgetPass(FormCollection form)
        {
            using(HapinessSurveyEntities db = new HapinessSurveyEntities())
            {
                try
                {
                    string ml = Request.Form["EmailID"].ToString();
                    var pas = (from m in db.UserTbls where m.user_mail == ml select m.user_Pass).FirstOrDefault();

                    EmailOperation.SendEmail(ml, "Forget Password", "Happiness Password is = " + pas);
                    ViewBag.messge = "mail sended";
                }
                catch(Exception ex)
                {
                    return View("ForgetPass");
                }
                return View("Login");
            }

          
        }
        //public ActionResult ModelLayout(UserDisplayViewModel user)
        //{

        //    return View();
        //}

    }
}