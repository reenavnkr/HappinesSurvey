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
    
    public partial class teamtbl
    {
        public int team_id { get; set; }
        public Nullable<int> dep_id { get; set; }
        public int pro_id { get; set; }
        public int user_id { get; set; }
        public int role_id { get; set; }
    
        public virtual projecttbl projecttbl { get; set; }
        public virtual roletbl roletbl { get; set; }
        public virtual UserTbl UserTbl { get; set; }
        public virtual departmenttbl departmenttbl { get; set; }
    }
}
