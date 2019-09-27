using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappinessSurvey.BAL.Interface;
using HappinessSurvey.Model.Models;
using HappinessSurvey.Model.ViewModels;
using HappinessSurvey.DAL;
using System.Data.Entity;
using System.Web;

namespace HappinessSurvey.BAL.Implementation
{
    public class Login : ILogin 
    {
        public int isuservalue;
        public int isUserAvailable(Loginmodel Objlogin)
        {
           //user avaliable return user id
            //  bool isusermatch = false;
            try
            {
                using (var entity = new HapinessSurveyEntities())
                {
                     var obj = entity.UserTbls.Where(a => a.user_mail.Equals(Objlogin.user_mail) && a.user_Pass.Equals(Objlogin.user_pass)).FirstOrDefault();
                    if (obj !=null)
                    {
                        isuservalue = obj.user_id;

                        //  isusermatch = true;        
                    }
                    else
                    {
                        isuservalue = 0; 
                      //  isusermatch = false;
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
           // return isusermatch;
            return isuservalue;
        }

        public int isUserRoleID(Loginmodel Objlogin )
        {
            //get Roll iD for controller dashboard
            var role = 0; var roleid = 0;
            try {
                using(var entity = new HapinessSurveyEntities())
                    {
                teamtbl teamobj = new teamtbl();
                 role = (int)entity.teamtbls.Where(a => a.user_id.Equals(isuservalue)).LongCount();
                if (role == 1)
                {
                     roleid = entity.teamtbls.Where(a => a.user_id.Equals(isuservalue)).Select(a => a.role_id).FirstOrDefault();

                     //if assign any one role.
                }
                else if (role == 0)
                {
                     roleid = 0;
                    //if not assign any role
                }
                else if (role == 2)
                {
                        //if teamlead and teammember role
                        // var roleid1 = entity.teamtbls.Where(a => a.user_id.Equals(isuservalue)).Select(a => a.role_id).ToList();
                        //  roleid = roleid1.Min();
                        roleid = 6;
                       // roleid = entity.teamtbls.Where(a => a.user_id.Equals(isuservalue)).Select(a => a.role_id).Min();
                }
             }
            }
            catch(Exception ex)
            {

            }
            return roleid;
        }

        public  UserDisplayViewModel isdetail(int isuservalue)
        {
             
           // List<UserDisplayViewModel> UD = new List<UserDisplayViewModel>();
            UserDisplayViewModel userdep = new UserDisplayViewModel();
            try
            {
                using (var entity = new HapinessSurveyEntities())
                {
                   

                    var UDlist = (from u in entity.UserTbls
                                  join d in entity.departmenttbls
                                  on u.Dep_id equals d.dep_id
                                  where u.user_id == isuservalue
                                  select new
                                  {
                                      u.user_name,
                                      d.dep_name
                                  }).ToList();

                    foreach(var listud in UDlist)
                    {
                       
                        userdep.user_name = listud.user_name;
                        userdep.dep_name = listud.dep_name;
                        //UD.Add(userdep);
                    }
                }

            }
            catch(Exception ex)
            {

            }
            return userdep;
        }
    }
}
