using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EntityFramework.Triggers;
using AlexCoreyApp.DAL;

namespace AlexCoreyApp.Models
{
    public class Course : ITriggerable
    {
        public int ID { get; set; }

        [Required]
        public int ProfessorID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Range(1, 4)]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Course()
        {
            this.Triggers().Updated += entry =>
                {
                    UpdateStudentRecords(entry.Entity.ID);
                };
        }

        public static void UpdateStudentRecords(int courseID)
        {
            using(UniversityContext db = new UniversityContext())
            {
                var students = db.Enrollments
                    .Where(e => e.CourseID == courseID && e.Grade.HasValue)
                    .Select(e => e.Student)
                    .ToList();

                students.ForEach(s =>
                    {
                        var enrollments = s.Enrollments
                            .Where(e => e.Grade.HasValue)
                            .ToList();

                        s.Credits = enrollments
                            .Sum(e => e.Course.Credits);
                            
                        if (s.Credits > 0)
                        {
                            s.GPA = enrollments
                                .Select(e => new { GradePoints = (int)Enum.Parse(typeof(Points), e.Grade.Value.ToString()) * e.Course.Credits })
                                .Sum(p => (decimal)p.GradePoints) / s.Credits;
                        }
                        else
                            s.GPA = 4.00M;
                    });

                db.SaveChanges();
            }
        }
    }
}