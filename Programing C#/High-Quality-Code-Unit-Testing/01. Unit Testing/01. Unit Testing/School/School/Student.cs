using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.Empty == value)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            set
            {
                if (value <= 10000 || value >= 99999)
                {
                    throw new IndexOutOfRangeException("The unique number should be between 10000 and 999999");
                }
                this.uniqueNumber = value;
            }
        }

        public bool JoinCourse(Course course)
        {
            course.AddStudentToCourse(this);
            return true;
        }

        public bool LeaveCourse(Course course)
        {
            course.RemoveStudentFromCourse(this);
            return true;
        }

    }
}
