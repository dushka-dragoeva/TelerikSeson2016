namespace SchoolClasses.Models
{
    using System.Collections.Generic;
    using Utilities.Validators;

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
                this.name = value.ValidateName(2, 30, "School");
            }
        }

        public List<Class> Classes
        {
            get
            {
                return this.classes.ValidateIsNotNullOrEmpty("Classes");
            }

            private set
            {
                this.classes.AddRange(value.ValidateIsNotNullOrEmpty("Classes"));
            }
        }

        public void AddClass(Class newClass)
        {
            this.Classes.Add(newClass);
        }

        public void RemoveClass(Class lastClass)
        {
            this.Classes.Remove(lastClass);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Classes}";
        }
    }
}
