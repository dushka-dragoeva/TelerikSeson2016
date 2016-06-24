namespace SchoolClasses
{
    using System.Collections.Generic;
    using Contracts;
    using Utilities.Validators;

    public class Discipline : IComment
    {
        private string name;
        private int lecturesNumber;
        private int exersicesNumber;
        private List<string> comments = new List<string>();

        public Discipline(string name, int lecturesNumber, int exersicesNumber)
        {
            this.Name = name;
            this.LecturesNumber = lecturesNumber;
            this.ExersicesNumber = exersicesNumber;
        }

        public IList<string> Comments
        {
            get
            {
                return this.comments.ValidateIsNotNullOrEmpty("Comments");
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value.ValidateName(2, 100);
            }
        }

        public int LecturesNumber
        {
            get
            {
                return this.lecturesNumber;
            }

            private set
            {
                this.lecturesNumber = value.ValidateNumber(1, int.MaxValue);
            }
        }

        public int ExersicesNumber
        {
            get
            {
                return this.exersicesNumber;
            }

            private set
            {
                this.exersicesNumber = value.ValidateNumber(1, int.MaxValue);
            }
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.LecturesNumber}, {this.ExersicesNumber}";
        }
    }
}
