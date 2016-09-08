using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    internal class Course
    {
        private const string InvalidCourseNameExceptionMessage = "Course name cannot be null or empty.";
        private const string InvalidStudentNameExceptionMessage = "Student name cannot be null or empty.";

        private string name;
        private string teacherName;
        private ICollection<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.teacherName = teacherName;
        }

        public Course(string name, string teacher, ICollection<string> students)
            : this(name, teacher)
        {
            this.AddStudents(students);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(InvalidCourseNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }

        public ICollection<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value != null && value.Count > 0)
                {
                    this.AddStudents(value);
                }
                else
                {
                    this.students = new List<string>();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"LocalCourse {{ Name ={this.GetType().Name} ");

            if (this.TeacherName != null)
            {
                result.Append($"; Teacher = {this.TeacherName}");
            }

            result.Append($"; Students = {this.GetStudentsAsString()}");

            return result.ToString();
        }

        private void AddStudents(ICollection<string> students)
        {
            foreach (var student in students)
            {
                if (!string.IsNullOrEmpty(student.Trim()))
                {
                    this.students.Add(student);
                }
                else
                {
                    throw new ArgumentException(InvalidStudentNameExceptionMessage);
                }
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}