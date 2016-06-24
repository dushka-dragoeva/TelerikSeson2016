
namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Contracts;

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

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Constants.InvalidName);
                }
                else
                {
                    this.name = value;
                }
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
                if (value <= 0)
                {
                    throw new ArgumentException(Constants.InvaliNumber);
                }
                else
                {
                    this.lecturesNumber = value;
                }
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
                if (value <= 0)
                {
                    throw new ArgumentException(Constants.InvaliNumber);
                }
                else
                {
                    this.exersicesNumber = value;
                }
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return $"{this.name} - {this.lecturesNumber}, {this.exersicesNumber}";
        }
    }
}
