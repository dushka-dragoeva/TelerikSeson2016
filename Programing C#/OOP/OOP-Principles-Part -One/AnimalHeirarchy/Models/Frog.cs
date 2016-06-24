namespace AnimalHeirarchy.Models
{
    using System;
    using Contracts;

    internal class Frog : Animal, ISound
    {
        public Frog(int age, string name, SexType sex)
            : base(age, name, sex)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Kwa! Kwa! Kwa!");
        }
    }
}
