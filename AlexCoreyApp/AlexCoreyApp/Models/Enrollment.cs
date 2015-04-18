using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexCoreyApp.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
<<<<<<< HEAD
        A = 4,
        B = 3,
        C = 2,
        D = 1,
        F = 0
    }

    public class Enrollment : ITriggerable
    {
        //public int ID { get; set; }

        [Key, Column(Order = 0)]
        public int CourseID { get; set; }

        [Key, Column(Order = 1)]
=======
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; }

>>>>>>> origin/master
        public int StudentID { get; set; }

        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}