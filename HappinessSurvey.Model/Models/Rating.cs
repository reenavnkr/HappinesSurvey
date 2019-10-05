using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HappinessSurvey.Model.Models
{
    class Rating
    {
        public string ques { get; set; }
        public int rate { get; set; }
        public string comment { get; set; }
    }
}
