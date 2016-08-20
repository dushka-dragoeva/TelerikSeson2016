﻿namespace School.Tests.Models
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School.Contracts;
    using School.Models;

    [TestClass]
    public class StudentTests
    {
        private ICourse testInputCourse;
        private IStudent testInputStudent;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void JoinCourse_shouldThrow_ifPassedCourseObjectIsNull()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            this.testInputCourse = null;

            this.testInputStudent.JoinCourse(this.testInputCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void JoinCourse_shouldThrow_ifPassedCourseHasCapacityFull()
        {
            var testInputCourseName = "test course";
            var testInputCourseMaximumCapacity = 1;
            this.testInputCourse = new Course(testInputCourseName, testInputCourseMaximumCapacity);

            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            this.testInputStudent.JoinCourse(testInputCourse);

            var secondStudentName = "test student 2";
            var secondStudentId = 10004;
            this.testInputStudent = new Student(secondStudentName, secondStudentId);

            this.testInputStudent.JoinCourse(testInputCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void JoinCourse_shouldThrow_ifTheStudentCallerIsAlreadySignedUpForThePassedCourse()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            var testInputCourseName = "test course";
            var testInputCourseMaximumCapacity = 30;
            this.testInputCourse = new Course(testInputCourseName, testInputCourseMaximumCapacity);

            this.testInputStudent.JoinCourse(this.testInputCourse);
            this.testInputStudent.JoinCourse(this.testInputCourse);
        }

        [TestMethod]
        public void JoinCourse_shouldReturnTrue_ifStudentAndCourseAreBothValid()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            var testInputCourseName = "test course";
            var testInputCourseMaximumCapacity = 30;
            this.testInputCourse = new Course(testInputCourseName, testInputCourseMaximumCapacity);

            var actual = this.testInputStudent.JoinCourse(this.testInputCourse);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = false)]
        public void LeaveCourse_shouldThrow_ifPassedCourseObjectIsNull()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            this.testInputCourse = null;

            this.testInputStudent.LeaveCourse(testInputCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void LeaveCourse_shouldThrow_ifThisStudentIsNotOnTheListOfStudentsForThePassedCourse()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            var testInputCourseName = "test course";
            var testInputCourseMaximumCapacity = 30;
            this.testInputCourse = new Course(testInputCourseName, testInputCourseMaximumCapacity);

            this.testInputStudent.LeaveCourse(this.testInputCourse);
        }

        [TestMethod]
        public void LeaveCourse_shouldReturnTrue_ififStudentAndCourseAreBothValid()
        {
            var testInputStudentName = "test student";
            var testInputStudentId = 10000;
            this.testInputStudent = new Student(testInputStudentName, testInputStudentId);

            var testInputCourseName = "test course";
            var testInputCourseMaximumCapacity = 30;
            this.testInputCourse = new Course(testInputCourseName, testInputCourseMaximumCapacity);

            this.testInputStudent.JoinCourse(this.testInputCourse);
            var actual = this.testInputStudent.LeaveCourse(this.testInputCourse);

            Assert.IsTrue(actual);
        }
    }
}
