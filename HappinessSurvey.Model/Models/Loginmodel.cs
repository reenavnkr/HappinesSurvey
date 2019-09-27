using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HappinessSurvey.Model.Models
{
   public  class Loginmodel
    {
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [Required(ErrorMessage = "Please enter the Email")]
        public string user_mail { get; set; }

        [Required(ErrorMessage = "Please enter the Password")]
        public string user_pass { get; set; }


    }
}
