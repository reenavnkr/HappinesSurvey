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
    
    public partial class UserTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserTbl()
        {
            this.Submitsurveys = new HashSet<Submitsurvey>();
            this.teamtbls = new HashSet<teamtbl>();
        }
    
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_mail { get; set; }
        public string user_Pass { get; set; }
        public int Dep_id { get; set; }
    
        public virtual departmenttbl departmenttbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Submitsurvey> Submitsurveys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teamtbl> teamtbls { get; set; }
    }
}
