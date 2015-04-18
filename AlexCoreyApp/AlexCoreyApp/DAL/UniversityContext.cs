using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AlexCoreyApp.Models;

namespace AlexCoreyApp.DAL
{
    public class UniversityContext :DbContext
    {

        public UniversityContext() : base("UniversityContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
<<<<<<< HEAD

        public System.Data.Entity.DbSet<AlexCoreyApp.Models.Cart> Carts { get; set; }        
=======
>>>>>>> origin/master
    }
}