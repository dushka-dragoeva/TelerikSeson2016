namespace SchoolClasses.Models
{
    using System;
    using Common;
    using Contracts;

    public class Student : Person, IComment
    {
        private int uniqNumber;

        public Student(string firstName, string lastName, int uniqNumber)
            : base(firstName, lastName)
        {
            this.UniqNumber = uniqNumber;
        }

        public int UniqNumber
        {
            get
            {
                return this.uniqNumber;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Constants.InvalidName);
                }
                else
                {
                    this.uniqNumber = value;
                }
            }
        }
    }
}
