namespace SchoolClasses.Models
{
    using System.Collections.Generic;
    using Contracts;
    using Utilities.Validators;

    public class Teacher : Person, IComment
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string firstName, string lastName, params Discipline[] disiplines)
            : base(firstName, lastName)
        {
            this.Disciplines.AddRange(disiplines);
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines.ValidateIsNotNullOrEmpty("Disciplines");
            }

            private set
            {
                this.disciplines.AddRange(value.ValidateIsNotNullOrEmpty("Disciplines"));
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline dicipline)
        {
            this.Disciplines.Remove(dicipline);
        }
    }
}
