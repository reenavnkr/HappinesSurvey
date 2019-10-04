using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HappinessSurvey.Model.Models
{
    public class Questionmodel
    {

        [Key] public int q_id { get; set; }

        [Required(ErrorMessage = "Enter question")]
        public string questions { get; set; }
    }


}
