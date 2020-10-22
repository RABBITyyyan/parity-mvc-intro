# Course Registration System

This Course Registration System is an ASP.NET MVC application that uses Entity Framework 6 and SQL Server LocalDB. for data access.

## Use Cases

The home page shows an admin view of a list of students with their name, gender, and major. 

By clicking the Edit button, the page directs the user to the edit view. In the edit view, the user can edit the student's information and register class by selecting the checkboxes on the left of the Available Classes table. If a checkbox is initially selected, it means that the student is currently enrolled in that class. When the user is done making changes, the user would click the Register button and all the changes will be made. 

By clicking the Details button, the page directs the user to the details view. The details view displays the name, gender, major, enrolled classes and classes the student has already taken. 

## Database Design - Data Model

Student: ID (primary key), Name, Gender, Major, Enrollments, ClassesTaken
Course: CourseID (primary key), Title, Credits, Department, Professor
ClassTaken: ClassTakenID (primary key), CourseID, StudentID, Course, Student

The CourseID in Course references CourseID in ClassTaken.
The ID in Student references StudentID in ClassTaken.

There's a one-to-many relationship between Student and Course entities, and there's a one-to-many relationship between Student and Enrollment Course.