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
    
    public partial class projecttbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public projecttbl()
        {
            this.teamtbls = new HashSet<teamtbl>();
            this.surveytbls = new HashSet<surveytbl>();
        }
    
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public int pro_status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teamtbl> teamtbls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<surveytbl> surveytbls { get; set; }
    }
}
