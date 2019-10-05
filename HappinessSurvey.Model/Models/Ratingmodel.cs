using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappinessSurvey.Model.ViewModels
{
    public class Ratingmodel
    {
        public Guid id { get; set; }
        public string ques { get; set; }
        public int rate { get; set; }
        public string comment { get; set; }
    }
}
