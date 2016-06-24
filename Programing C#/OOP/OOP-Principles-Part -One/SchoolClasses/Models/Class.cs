namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Validators;

    public class Class : IComment
    {
        private string textIndentifier;
        private List<Teacher> teachers = new List<Teacher>();
        private List<string> comments = new List<string>();

        public Class(string textIndentifier, params Teacher[] teachers)
        {
            this.TextIndentifier = textIndentifier;
            this.Teachers.AddRange(teachers);
        }

        public string TextIndentifier
        {
            get
            {
                return this.textIndentifier;
            }

            private set
            {
                this.textIndentifier = value.ValidateName(2, 30, "Class");
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers.ValidateIsNotNullOrEmpty("Teachers");
            }

            private set
            {
                this.teachers.AddRange(value.ValidateIsNotNullOrEmpty("Teachers"));
            }
        }

        public IList<string> Comments
        {
            get
            {
                return this.comments.ValidateIsNotNullOrEmpty("Comments");
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.Teachers.Remove(teacher);
        }

        public override string ToString()
        {
            return this.TextIndentifier;
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment.ValidateName(20, 500, "Comment"));
        }
    }
}
