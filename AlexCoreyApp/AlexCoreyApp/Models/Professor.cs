using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityFramework.Triggers;
using AlexCoreyApp.DAL;

namespace AlexCoreyApp.Models
{
    public class Professor : ITriggerable
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Professor()
        {
            this.Triggers().Deleting += entry =>
            {
                using (UniversityContext db = new UniversityContext())
                {
                    db.Courses
                        .Where(e => e.ProfessorID == entry.Entity.ID)
                        .ToList()
                        .ForEach(e =>
                        {
                            db.Courses.Remove(e);
                        });

                    db.SaveChanges();
                }
            };
        }
    }
}