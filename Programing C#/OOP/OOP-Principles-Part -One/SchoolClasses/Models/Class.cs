namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Utilities.Validators;

    public class Class
    {
        private string textIndentifier;
        private List<Teacher> teachers = new List<Teacher>();

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Constants.InvalidName);
                }
                else
                {
                    this.textIndentifier = value.ValidateName(2,30,"Class");
                }
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            private set
            {
                {
                    if (value == null || value.Count < 1)
                    {

                        throw new ArgumentNullException(
                            nameof(this.teachers),
                            $"{this.Teachers}" + Constants.EmptyColection);
                    }
                    else
                    {
                        this.teachers.AddRange(value);
                    }
                }
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.teachers.Remove(teacher);
        }
    }
}
