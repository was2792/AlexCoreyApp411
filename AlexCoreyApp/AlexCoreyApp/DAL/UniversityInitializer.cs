using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AlexCoreyApp.Models;

namespace AlexCoreyApp.DAL
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstName="Alex", LastName="Shelton", Major=Major.Business}
            };

            students.ForEach(a => context.Students.Add(a));
            context.SaveChanges();

            var professors = new List<Professor>
            {
                new Professor{FirstName="Wesley",LastName="Reisz"}
            };

            professors.ForEach(a => context.Professors.Add(a));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{ProfessorID=1, Title="Web Development", Credits=3}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CourseID=1}
            };

            enrollments.ForEach(a => context.Enrollments.Add(a));
            context.SaveChanges();
        }
    }
}