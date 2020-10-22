using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClassRegistrationSystem.DAL;
using ClassRegistrationSystem.Models;

/* Student Controller */
namespace ClassRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        private ClassRegistrationSystemContext db = new ClassRegistrationSystemContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        /* The action method for the Details view uses the Find method to retrieve a single Student entity. */
        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        /* The action method for the Edit view retrieves and let the user edit a single Student entity. 
         * The code adds eager loading for the Courses navigation property and 
         * calls the new PopulateAvailableCourseData method to provide information for the check box array.*/
        // GET: Student/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student studentToUpdate = db.Students.Find(id);
            PopulateAvailableCourseData(studentToUpdate);
            if (studentToUpdate == null)
            {
                return HttpNotFound();
            }
            return View(studentToUpdate);
        }

        /* This method will be executed when the user clicks Register. 
         * The method calls the UpdateStudentCourses method to add all the courses that the user selects into the enrollment list.*/
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student studentToUpdate = db.Students.Find(id);

            if (TryUpdateModel(studentToUpdate, "", new string[] { "ID", "Name", "Gender", "Major" }))
            {
                try
                {
                    UpdateStudentCourses(selectedCourses, studentToUpdate);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    //Log the error
                    ModelState.AddModelError("", "Unable to save changes. Try again.");
                }
            }
            PopulateAvailableCourseData(studentToUpdate);
            return View(studentToUpdate);
        }

        /* The UpdateStudentCourses method to add all the courses that the user selects into the enrollment list.*/
        private void UpdateStudentCourses(string[] selectedCourses, Student studentToUpdate)
        {
            if (selectedCourses == null)
            {
                studentToUpdate.Enrollments = new List<Course>();
                db.SaveChanges();
                return;
            }
            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var studentCourses = new HashSet<int>
                (studentToUpdate.Enrollments.Select(c => c.CourseID));

            foreach (var course in db.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!studentCourses.Contains(course.CourseID))
                    {
                        studentToUpdate.Enrollments.Add(course);
                    }
                }
                else
                {
                    if (studentCourses.Contains(course.CourseID))
                    {
                        studentToUpdate.Enrollments.Remove(course);
                    }
                }
            }
        }

        /* The PopulateAvailableCourseData method defines Enrollments as the courses that the student is currently taking,
         * and Courses as a list of courses in the database.*/
        private void PopulateAvailableCourseData(Student student)
        {
            var allCourses = db.Courses;
            var studentEnrollments = new HashSet<int>(student.Enrollments.Select(c => c.CourseID));
            var studentTakenClasses = new HashSet<int>(student.ClassesTaken.Select(c => c.CourseID));
            var studentMajor = student.Major;
            var viewModel = new List<Course>();
            var enrollments = new HashSet<int>();
            foreach (var course in allCourses)
            {
                if (!studentTakenClasses.Contains(course.CourseID) && course.Department == studentMajor)
                {
                    viewModel.Add(new Course
                    {
                        CourseID = course.CourseID,
                        Title = course.Title,
                        Credits = course.Credits,
                        Department = course.Department,
                        Professor = course.Professor
                    });
                    if (studentEnrollments.Contains(course.CourseID))
                    {
                        enrollments.Add(course.CourseID);
                    }
                }

            }
            ViewBag.Enrollments = enrollments;
            ViewBag.Courses = viewModel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
