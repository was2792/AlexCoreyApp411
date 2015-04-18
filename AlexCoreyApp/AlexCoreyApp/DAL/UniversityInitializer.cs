using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AlexCoreyApp.Models;

namespace AlexCoreyApp.DAL
{
    public class UniversityInitializer : DropCreateDatabaseAlways<UniversityContext> //System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Student', RESEED, 1000000);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Professor', RESEED, 1000000);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Course', RESEED, 1000);");

            var students = new List<Student>
            {
                new Student{FirstName="Alex",LastName="Shelton",Major=Major.Business,ProfessorID=2792,Credits=3,GPA=4.0m}
            };

            students.ForEach(a => context.Students.Add(a));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseID=1234,Title="Web Development",Credits=3, Description="This is the best class I have ever taken!"}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
<<<<<<< HEAD
                new Course{ProfessorID=1000000, Title="Web Development", Credits=3}
=======
                new Enrollment{StudentID=1673351,CourseID=1234,Grade=Grade.A}
>>>>>>> origin/master
            };

            enrollments.ForEach(a => context.Enrollments.Add(a));
            context.SaveChanges();

            var professors = new List<Professor>
            {
<<<<<<< HEAD
                new Enrollment{StudentID=1000000,CourseID=1000}
=======
                new Professor{FirstName="Wesley",LastName="Reisz"}
>>>>>>> origin/master
            };

            professors.ForEach(a => context.Professors.Add(a));
            context.SaveChanges();

        }
    }
}