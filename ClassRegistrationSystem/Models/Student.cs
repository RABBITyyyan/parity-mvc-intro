using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClassRegistrationSystem.Models
{
    /*The Student class represents a Student entity. */
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Major { get; set; }
        public virtual ICollection<Course> Enrollments { get; set; }
        public virtual ICollection<ClassTaken> ClassesTaken { get; set; }

    }
}