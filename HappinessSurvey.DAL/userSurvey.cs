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
    
    public partial class userSurvey
    {
        public int userservey_id { get; set; }
        public int sur_id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> ss_id { get; set; }
        public bool Active { get; set; }
    
        public virtual surveytbl surveytbl { get; set; }
        public virtual UserTbl UserTbl { get; set; }
    }
}