using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappinessSurvey.BAL.Interface
{
    interface Isendmail
    {
        string SendEmail(string toAddress, string subject, string body);
    }
}
