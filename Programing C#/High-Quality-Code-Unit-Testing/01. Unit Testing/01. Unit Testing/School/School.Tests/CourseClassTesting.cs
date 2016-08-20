using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class CourseClassTesting
    {
        [TestMethod]
        public void AddStudentToCourse_ShouldAddStudentToCourseCorrectly()
        {
            // Arrange
            var peshoStudent = new Student("Pesho",54342);
            var course = new Course();

            // Act
            course.AddStudentToCourse(peshoStudent);

            // Assert
            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void RemoveStudentFromCourse_ShouldRemoveStudentFromCoursCorrectly()
        {
            // Arrange
            var peshoStudent = new Student("Pesho", 54342);
            var course = new Course();

            // Act
            course.AddStudentToCourse(peshoStudent);
            course.RemoveStudentFromCourse(peshoStudent);

            // Assert
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveStudentFromCourse_ShouldThrowException_WhenAddMoreThanThirtyStudents()
        {
            // Arrange and Act
            var peshoStudent = new Student("Pesho", 54342);
            var course = new Course();
            for (int i = 0; i <= 33; i++)
            {
                course.AddStudentToCourse(peshoStudent);
            }
        }
    }
}
