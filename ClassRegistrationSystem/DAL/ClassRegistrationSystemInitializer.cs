using ClassRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassRegistrationSystem.DAL
{
    public class ClassRegistrationSystemInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ClassRegistrationSystemContext>
    {
        protected override void Seed(ClassRegistrationSystemContext context)
        {
            var students = new List<Student>
            {
            new Student{Name="Dean Wormald",Gender="male",Major="Computer Science"},
            new Student{Name="Ashley Luna",Gender="female",Major="Economics"},
            new Student{Name="Callum Santiago",Gender="male",Major="Mathematics"},
            new Student{Name="Eesa Quinn",Gender="female",Major="Physics"},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();


            var courses = new List<Course>
            {
            new Course{CourseID=1, Title="Programming Fundamentals", Credits=3, Department="Computer Science", Professor="Anaiya Hawkins"},
            new Course{CourseID=2, Title="Computer Systems", Credits=5, Department="Computer Science", Professor="Lacie Mackenzie"},
            new Course{CourseID=3, Title="Databases", Credits=3, Department="Computer Science", Professor="Aneesa Curry"},
            new Course{CourseID=4, Title="Web Programming", Credits=5, Department="Computer Science", Professor="Monica Hassan"},
            new Course{CourseID=5, Title="Operating Systems", Credits=5, Department="Computer Science", Professor="Usman Crowther"},
            new Course{CourseID=6, Title="Data Structures", Credits=5, Department="Computer Science", Professor="Jaydon West"},
            new Course{CourseID=7, Title="Algorithms", Credits=5, Department="Computer Science", Professor="Carlo Merrill"},
            new Course{CourseID=8, Title="Discrete Mathematics", Credits=5, Department="Computer Science", Professor="Margie Choi"},


            new Course{CourseID=9, Title="Microeconomics", Credits=5, Department="Economics", Professor="Sabiha Mendoza"},
            new Course{CourseID=10, Title="Macroeconomics", Credits=5, Department="Economics", Professor="Lesley Mcghee"},
            new Course{CourseID=11, Title="Public Economics", Credits=3, Department="Economics", Professor="Madelyn Rodriquez"},
            new Course{CourseID=12, Title="Globalization", Credits=5, Department="Economics", Professor="Fabian Vaughn"},
            new Course{CourseID=13, Title="Econometrics", Credits=5, Department="Economics", Professor="Fabian Vaughn"},
            new Course{CourseID=14, Title="Economic Behavior and Psychology", Credits=5, Department="Economics", Professor="Fabian Vaughn"},
            new Course{CourseID=15, Title="Economic Analysis of Labor Markets", Credits=5, Department="Economics", Professor="Fabian Vaughn"},
            new Course{CourseID=16, Title="Law and Economics", Credits=5, Department="Economics", Professor="Fabian Vaughn"},


            new Course{CourseID=17, Title="Calculus", Credits=5, Department="Mathematics", Professor="Georgina Parks"},
            new Course{CourseID=18, Title="Differential Equations", Credits=5, Department="Mathematics", Professor="Reanne Hughes"},
            new Course{CourseID=19, Title="Linear Algebra", Credits=5, Department="Mathematics", Professor="Ayisha Tanner"},
            new Course{CourseID=20, Title="Abstract Algebra", Credits=5, Department="Mathematics", Professor="Cassian Shannon"},
            new Course{CourseID=21, Title="Complex Analysis", Credits=5, Department="Mathematics", Professor="Azeem Warner"},
            new Course{CourseID=22, Title="Trigonometry", Credits=5, Department="Mathematics", Professor="Farah Rodriguez"},
            new Course{CourseID=23, Title="Theory of Computation", Credits=5, Department="Mathematics", Professor="Karen Salgado"},
            new Course{CourseID=24, Title="Topology", Credits=5, Department="Mathematics", Professor="Howard Pierce"},


            new Course{CourseID=25, Title="Statistical Mechanics", Credits=5, Department="Physics", Professor="Melina Sherman"},
            new Course{CourseID=26, Title="Astronomy", Credits=5, Department="Physics", Professor="Honey Oconnell"},
            new Course{CourseID=27, Title="Astrophysics and Cosmology", Credits=5, Department="Physics", Professor="Shantelle Hills"},
            new Course{CourseID=28, Title="Introduction to Relativity and Quantum Physics", Credits=5, Department="Physics", Professor="Dale Hogan"},
            new Course{CourseID=29, Title="Advanced Classical Mechanics", Credits=5, Department="Physics", Professor="Mikaeel Robbins"},
            new Course{CourseID=30, Title="Experiments in Modern Physics", Credits=3, Department="Physics", Professor="Clinton Lawson"},
            new Course{CourseID=31, Title="Analytical Mechanics", Credits=5, Department="Physics", Professor="Rhydian Erickson"},
            new Course{CourseID=32, Title="Electricity and Magnetism", Credits=5, Department="Physics", Professor="Arif John"},

            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var classesTaken = new List<ClassTaken>
            {
                new ClassTaken{ StudentID=1, CourseID=1},
                new ClassTaken{ StudentID=1, CourseID=2},
                new ClassTaken{ StudentID=2, CourseID=9},
                new ClassTaken{ StudentID=2, CourseID=10},
                new ClassTaken{ StudentID=3, CourseID=17},
                new ClassTaken{ StudentID=3, CourseID=18},
                new ClassTaken{ StudentID=4, CourseID=21},
                new ClassTaken{ StudentID=4, CourseID=22},
            };
            classesTaken.ForEach(s => context.ClassesTaken.Add(s));
            context.SaveChanges();
        }
    }
}