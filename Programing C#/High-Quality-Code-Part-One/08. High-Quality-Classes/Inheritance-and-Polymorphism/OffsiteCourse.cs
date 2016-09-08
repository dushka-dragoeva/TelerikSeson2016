using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    internal class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string name, string teacherName)
            : base(name, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students)
            : base(name, teacherName, students)
        {
            this.Town = null;
        }

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            : this(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town { get; set; }
                
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append($"; Town = {this.Town}");
                result.Append(this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
