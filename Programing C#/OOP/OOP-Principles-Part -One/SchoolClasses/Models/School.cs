namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using Utilities;

    public class School
    {
        private string name;
        private List<Class> classes = new List<Class>();

        public School(string name, List<Class> classes)
        {
            this.Name = name;
            this.Classes.AddRange(classes);
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

        public List<Class> Classes
        {
            get
            {
                if (classes == null || classes.Count < 0)
                {
                    throw new ArgumentNullException(
                        nameof(this.classes),
                        $"{this.classes}" + Constants.EmptyColection);
                }

                return this.classes;
            }

            private set
            {
                if (classes == null || classes.Count < 0)
                {
                    throw new ArgumentNullException(
                        nameof(this.classes),
                        $"{this.classes}" + Constants.EmptyColection);
                }

                this.classes.AddRange(value);
            }
        }

        public void AddClass(Class newClass)
        {
            this.classes.Add(newClass);
        }

        public void RemoveDiscipline(Class lastClass)
        {
            this.classes.Remove(lastClass);
        }

        public override string ToString()
        {
            return $"{this.name}{this.classes}";
        }
    }
}
