using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace School.Tests
{
    [TestClass]
    public class SchoolClassTesting
    {
        [TestMethod]
        public void AddCourseToSchool_ShouldAddCourse_WhenAddGivenCourseToSchool()
        {
            // Arrange
            var school = new School();
            var course = new Course();

            // Act
            school.AddCourseToSchool(course);

            // Assert
            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void RemoveCourseFromSchool_ShouldRemoveCourse_WhenRemoveGivenCourseFromSchool()
        {
            // Arrange
            var school = new School();
            var course = new Course();

            // Act
            school.AddCourseToSchool(course);
            school.RemoveCourseFromSchool(course);

            // Assert
            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        public void AddStudentToSchool_ShouldAddStudent_WhenAddGivenStudentToSchool()
        {
            // Arrange
            var school = new School();
            var student = new Student("Stanko", 12352);

            // Act 
            school.AddStudentToSchool(student);

            //Assert
            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        public void RemoveStudentFromSchool_ShouldRemoveStudent_WhenRemoveGivenStudentFromSchool()
        {
            // Arrange
            var school = new School();
            var student = new Student("Stanko",12352);

            // Act
            school.AddStudentToSchool(student);
            school.RemoveStudentFromSchool(student);

            // Assert
            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        public void CheckingTheSetersOnPropertyStudents_WhenSetsNewStudent()
        {
            // Arrange
            var school = new School();
            var studentsList = new List<Student>();

            // Act
            studentsList.Add(new Student("Stanko", 12352));
            school.Students = new List<Student>(studentsList);

            // Assert
            Assert.AreEqual(1, school.Students.Count);
        }

        [TestMethod]
        public void CheckingTheSetersOnPropertyCourses_WhenSetsNewCourse()
        {
            // Arrange
            var school = new School();
            var courseList = new List<Course>();

            // Act
            courseList.Add(new Course());
            school.Courses = new List<Course>(courseList);

            // Assert
            Assert.AreEqual(1, school.Courses.Count);
        }
    }
}
