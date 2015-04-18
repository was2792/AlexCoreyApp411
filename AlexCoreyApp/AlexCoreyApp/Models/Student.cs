using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexCoreyApp.Models
{

    public enum Major
    {
        Business, Art, Humanities, Biology, Mathmatics, Writing, Music, Engineering
    }

    public class Student
    {
        public int ID { get; set; }

        public int ProfessorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal GPA { get; set; }

        public int Credits { get; set; }

        public Major Major { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}