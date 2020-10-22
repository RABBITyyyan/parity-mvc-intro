using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassRegistrationSystem.Models
{
    /*The ClassTaken class represents the class that the student has already taken. */
    public class ClassTaken
    {
        public int ClassTakenID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}