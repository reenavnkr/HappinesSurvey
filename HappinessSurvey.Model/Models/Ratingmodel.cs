using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappinessSurvey.Model.Models
{
    public class Ratingmodel
    {
        public Guid id { get; set; }
        public string ques { get; set; }
        public int rate { get; set; }
        public string comment { get; set; }

        public int sur_id { get; set; }

        public int sq_id { get; set; }


    }
}
