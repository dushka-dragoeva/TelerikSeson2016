namespace Students.Models
{
    using System.Collections.Generic;
    using Utilities;

    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string facultyNumber;
        private string phoneNumber;
        private string email;
        private List<double> marks;
        private Group group;
        private int? groupNumber;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(
            string firstName,
            string lastName,
            int age,
            string facultiNumber,
            string phoneNumber,
            string email,
            Group group)
            : this(firstName, lastName, age)
        {
            this.marks = new List<double>();
            this.CourseGroup = group;
            this.FacultyNumber = facultiNumber;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.GroupNumber = group.GroupNumber;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                Validator.CheckName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                Validator.CheckName(value);
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                Validator.CheckAge(value);
                this.age = value;
            }
        }

        public List<double> Marks
        {
            get
            {
                return new List<double>(this.marks);
            }
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                this.facultyNumber = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                Validator.CheckPhone(value);
                this.phoneNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                Validator.CheckEmail(value);
                this.email = value;
            }
        }

        public int? GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                this.groupNumber = value;
            }
        }

        public Group CourseGroup
        {
            get
            {
                return this.group;
            }

            private set
            {
                this.group = value;
            }
        }

        public string FullName
        {
            get
            {
                return $"{this.firstName} { this.lastName}";
            }
        }

        public void AddMark(double mark)
        {
            this.marks.Add(mark);
        }

        public void AddMarks(params double[] marks)
        {
            this.marks.AddRange(marks);
        }

        public override string ToString()
        {
            return $"{this.FirstName}\t{this.LastName,-12}{this.Email,-20}{ this.PhoneNumber,-15}{ this.CourseGroup}";
        }
    }
}
