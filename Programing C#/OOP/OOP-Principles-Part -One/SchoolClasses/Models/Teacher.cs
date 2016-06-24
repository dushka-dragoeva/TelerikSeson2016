namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Common;

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
                return this.disciplines;
            }

            private set
            {
                if (disciplines == null)
                {
                    throw new ArgumentNullException(
                        nameof(this.Disciplines), 
                        $"{this.Disciplines}" + Constants.EmptyColection);
                }

                this.disciplines.AddRange(value);
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline dicipline)
        {
            this.disciplines.Remove(dicipline);
        }
    }
}
