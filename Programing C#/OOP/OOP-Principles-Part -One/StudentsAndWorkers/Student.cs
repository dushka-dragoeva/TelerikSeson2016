namespace StudentsAndWorkers
{
    using Utilities.Validators;

    internal class Student : Human
    {
        private int grade;

        public Student(string firstNme, string lastName, int grade)
            : base(firstNme, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                this.grade = value.ValidateIntegerRange(1, 12);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(this.grade)} {this.grade}";
        }
    }
}
