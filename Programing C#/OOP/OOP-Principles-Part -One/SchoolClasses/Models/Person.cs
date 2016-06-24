namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Contracts;

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Constants.InvalidName);
                }
                else
                {
                    this.firstName = value;
                }
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Constants.InvalidName);
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string FullName
        {
            get
            {
                return this.ToString();
            }
        }

        public IList<String> Comments
        {
            get
            {
                if (this.comments.Count < 0)
                {
                    Console.WriteLine(Constants.NoComents);
                }
                return this.comments;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName}";
        }
    }
}

