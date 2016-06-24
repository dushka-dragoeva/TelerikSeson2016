namespace AnimalHeirarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Utilities.Validators;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;

        public Animal(int age, string name, SexType sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                this.age = value.ValidateNumber(0, 20);
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
                this.name = value.ValidateName(2, 20);
            }
        }

        public SexType Sex { get; private set; }

        public static double CalculateAverageAge(IEnumerable<Animal> animals)
        {
            return animals.Average(a => a.Age);
        }

        public abstract void MakeSound();
    }
}
