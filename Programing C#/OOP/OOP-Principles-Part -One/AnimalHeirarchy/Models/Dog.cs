namespace AnimalHeirarchy.Models
{
    using System;
    using Contracts;

    internal class Dog : Animal, ISound
    {
        public Dog(int age, string name, SexType sex)
            : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Baw! Baw! Baw!");
        }
    }
}
