using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AlexCoreyApp.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [DisplayName("Professor Name")]
        public int ProfessorID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Credits { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
<<<<<<< HEAD

        public Course()
        {
            this.Triggers().Updated += entry =>
                {
                    using (UniversityContext db = new UniversityContext())
                    {
                        db.Enrollments
                            .Where(e => e.CourseID == entry.Entity.ID && e.Grade.HasValue)
                            .Select(e => e.Student)
                            .ToList()
                            .ForEach(s => Enrollment.UpdateStudentRecord(s.ID)); 
                    }
                };

            this.Triggers().Deleting += entry =>
            {
                using (UniversityContext db = new UniversityContext())
                {
                    db.Enrollments
                        .Where(e => e.CourseID == entry.Entity.ID)
                        .ToList()
                        .ForEach(e =>
                        {
                            db.Enrollments.Remove(e);
                        });

                    db.SaveChanges();
                }
            };
        }
=======
>>>>>>> origin/master
    }
}