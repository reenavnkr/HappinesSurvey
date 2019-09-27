using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappinessSurvey.Model.ViewModels;

namespace HappinessSurvey.BAL.Interface
{
    interface IUserdisplay
    {
        UserDisplayViewModel displauser(UserDisplayViewModel udvm);

    }
}
