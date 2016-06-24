namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    using Contracts;
    using Utilities;
    using Utilities.Validators;

    public abstract class Person : IComment
    {
        private string firstName;
        private string lastName;
        private List<string> comments = new List<string>();

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.firstName = value.ValidateName(2, 30, Constants.FirstName);
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
                this.lastName = value.ValidateName(2, 30, Constants.LastName);
            }
        }

        public string FullName
        {
            get
            {
                return this.ToString();
            }
        }

        public IList<string> Comments
        {
            get
            {
                return this.comments.ValidateIsNotNullOrEmpty("Comments");
            }
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment.ValidateName(20, 500, "Comment"));
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
