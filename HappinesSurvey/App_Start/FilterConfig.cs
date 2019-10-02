using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using HappinessSurvey.BAL.Interface;
using HappinessSurvey.BAL.Implementation;
using HappinessSurvey.Model.Models;
using HappinessSurvey.Model.ViewModels;

namespace HappinesSurvey.App_Start
{
    public class FilterConfig : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int id = Convert.ToInt32(filterContext.HttpContext.Session["isuserId"]);
            ILogin _ud = new Login();
            var model = filterContext.Controller.ViewData.Model as UserDisplayViewModel;
            // filterContext.RouteData.Values.Add("Key", "Value");
            model = _ud.isdetail(id);
            Controller controller = filterContext.Controller as Controller;
            controller.TempData["dep_name"] = model.dep_name;
            controller.TempData["user_name"] = model.user_name;

        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           //ilters.Add(new HandleErrorAttribute());
            filters.Add(new FilterConfig());
        }

    }
    
}