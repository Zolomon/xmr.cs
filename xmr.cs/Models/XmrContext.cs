using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace xmr.cs.Models
{
    public class XmrContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public XmrContext() : base("name=XmrContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
        
        public System.Data.Entity.DbSet<xmr.cs.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<xmr.cs.Models.Exam> Exams { get; set; }

        public System.Data.Entity.DbSet<xmr.cs.Models.Problem> Problems { get; set; }

        public System.Data.Entity.DbSet<xmr.cs.Models.Answer> Answers { get; set; }

        public System.Data.Entity.DbSet<xmr.cs.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<xmr.cs.Models.Tag> Tags { get; set; }

        public System.Data.Entity.DbSet<xmr.cs.Models.TagLink> TagLinks { get; set; }
    
    }
}
