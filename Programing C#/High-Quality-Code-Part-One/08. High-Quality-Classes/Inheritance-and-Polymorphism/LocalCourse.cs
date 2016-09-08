using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    internal class LocalCourse : Course
    {
        private const string InvalidLabNameExceptionMessage = "Lab name cannot be null or empty.";
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName)
            : base(name, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : this(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append($"; Lab = {this.Lab}");
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}