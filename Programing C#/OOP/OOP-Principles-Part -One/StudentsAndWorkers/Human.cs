namespace StudentsAndWorkers
{
    using Utilities.Validators;

    internal abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstNme, string lastName)
        {
            this.FirstName = firstNme;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.firstName = value.ValidateName(2, 36, "First name");
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.lastName = value.ValidateName(2, 36, "Last name");
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName,-15}{this.LastName,-10}";
        }
    }
}
