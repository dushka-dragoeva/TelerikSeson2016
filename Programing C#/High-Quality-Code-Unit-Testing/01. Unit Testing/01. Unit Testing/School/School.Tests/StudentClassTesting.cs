using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class StudentClassTesting
    {
        [TestMethod]
        public void TestStudentClassPropertiesAndConstructor_WhenMakingInstanceOfStudent()
        {
            // Arange
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            var expectedName = "Ivan";
            var expectedUniqueNumber = 12345;

            // Act and Assert
            Assert.AreEqual(expectedName, student.Name);
            Assert.AreEqual(expectedUniqueNumber, student.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingArgumentExceptionOnPropertyName_WhenThePropertyIsEmpty()
        {
            var name = string.Empty;
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestingIndexOutOfRangeExceptionOnPropertyUniqueNumber_WhenThePropertyIsNotValid()
        {
            var name = "Ivan";
            var uniqueNumber = 1235;
            var student = new Student(name, uniqueNumber);
        }

        [TestMethod]
        public void JoinCourse_ShouldAddStudentToGivenCourseCorrectly()
        {
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            var course = new Course();
            student.JoinCourse(course);
            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void LeaveCourse_ShouldRemoveStudent_WhenHeDecidesToLeave()
        {
            var name = "Ivan";
            var uniqueNumber = 12345;
            var student = new Student(name, uniqueNumber);
            var course = new Course();
            student.JoinCourse(course);
            student.LeaveCourse(course);
            Assert.AreEqual(0, course.Students.Count);
        }
    }
}
