using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        private ICollection<Course> courses;
        private ICollection<Student> students;

        public School()
        {
            this.courses = new List<Course>();
            this.students = new List<Student>();
        }
        public ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public void AddStudentToSchool(Student student)
        {
            this.Students.Add(student);
        }

        public void RemoveStudentFromSchool(Student student)
        {
            this.Students.Remove(student);
        }

        public void AddCourseToSchool(Course course)
        {
            this.Courses.Add(course);
        }

        public void RemoveCourseFromSchool(Course course)
        {
            this.Courses.Remove(course);
        }
        
    }
}
