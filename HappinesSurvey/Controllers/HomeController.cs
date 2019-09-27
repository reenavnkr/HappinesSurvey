using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            return View("Login");
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

        public ActionResult Dashboard(UserDisplayViewModel userD)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["isuserId"]);
                ILogin _ud = new Login();

                UserDisplayViewModel model = new UserDisplayViewModel();
                model = _ud.isdetail(id);

                if (Session["isuserId"] != null)
                {
                    int Roleid = (int)Session["RoleID"];
                    if (Roleid == 1)
                    {
                        // return RedirectToAction("","")
                        return View("AdminDashboard",model);
                    }
                    else if (Roleid == 2)
                    {

                    }
                    else if (Roleid == 3)
                    {

                    }
                    else if (Roleid == 4)
                    {

                    }
                    else if (Roleid == 5)
                    {

                    }
                    else if (Roleid == 0)
                    {
                        //not found
                    }
                    else if (Roleid == 6)
                    {
                        //here also check TL have TM access ?
                        //Roleid 4 and 5
                    }

                }
            }
                return RedirectToAction("Login");
          
        }

        //public ActionResult getDestail(UserDisplayViewModel userD)
        //{
        
        //        return RedirectToAction("Dashboard");
        //    }
        //    return RedirectToAction("Login");
        //}

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

      
    }
}