using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private IList<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }
        public IList<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudentToCourse(Student student)
        {
            if (Students.Count > 30)
            {
                throw new ArgumentOutOfRangeException("In the course cannot have more than 30 students");
            }
            this.Students.Add(student);
        }

        public void RemoveStudentFromCourse(Student student)
        {
            this.Students.Remove(student);
        }
    }
}
