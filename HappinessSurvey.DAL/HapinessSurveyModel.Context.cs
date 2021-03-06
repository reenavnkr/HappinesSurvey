﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HapinessSurveyEntities : DbContext
    {
        public HapinessSurveyEntities()
            : base("name=HapinessSurveyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<questiontbl> questiontbls { get; set; }
        public virtual DbSet<roletbl> roletbls { get; set; }
        public virtual DbSet<surveyquestion> surveyquestions { get; set; }
        public virtual DbSet<projecttbl> projecttbls { get; set; }
        public virtual DbSet<UserTbl> UserTbls { get; set; }
        public virtual DbSet<departmenttbl> departmenttbls { get; set; }
        public virtual DbSet<surveytbl> surveytbls { get; set; }
        public virtual DbSet<userSurvey> userSurveys { get; set; }
        public virtual DbSet<Submitsurvey> Submitsurveys { get; set; }
        public virtual DbSet<teamtbl> teamtbls { get; set; }
    
        public virtual ObjectResult<GetQuestionByUserId> GetQuestionByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetQuestionByUserId>("GetQuestionByUserId", userIdParameter);
        }
    }
}
