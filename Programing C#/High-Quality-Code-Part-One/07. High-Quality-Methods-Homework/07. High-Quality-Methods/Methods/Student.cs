using System;
using System.Globalization;

namespace Methods
{
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            var sub = this.OtherInfo.Substring(this.OtherInfo.Length - 10);

            DateTime firstDate =
                DateTime.ParseExact(this.OtherInfo.Substring(this.OtherInfo.Length - 10), "dd.mm.yyyy", CultureInfo.InvariantCulture);
            DateTime secondDate =
                DateTime.ParseExact(other.OtherInfo.Substring(other.OtherInfo.Length - 10), "dd.mm.yyyy", CultureInfo.InvariantCulture);
            return firstDate < secondDate;
        }
    }
}