using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappinessSurvey.Model.Models;
using HappinessSurvey.Model.ViewModels;


namespace HappinessSurvey.BAL.Interface
{
    public interface ILogin
    {
        int isUserAvailable(Loginmodel Objlogin);
        int isUserRoleID(Loginmodel Objlogin);
       UserDisplayViewModel isdetail(int isuservalue);
    
        
    }
}
