//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HappinessSurvey.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class surveytbl
    {
        public int sur_id { get; set; }
        public int q_id { get; set; }
        public int rating { get; set; }
        public string comments { get; set; }
        public System.DateTime Start_date { get; set; }
        public System.DateTime End_date { get; set; }
        public int user_id { get; set; }
        public int Dep_id { get; set; }
    
        public virtual departmenttbl departmenttbl { get; set; }
        public virtual questiontbl questiontbl { get; set; }
        public virtual UserTbl UserTbl { get; set; }
    }
}