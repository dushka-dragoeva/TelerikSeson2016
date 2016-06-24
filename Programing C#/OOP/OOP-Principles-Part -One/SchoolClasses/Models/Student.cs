namespace SchoolClasses.Models
{
    using Contracts;
    using Utilities.Validators;

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
                this.uniqNumber = value.ValidateNumber(1, int.MaxValue);
            }
        }
    }
}
