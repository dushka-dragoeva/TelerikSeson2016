namespace AnimalHeirarchy.Models
{
    using System;
    using Contracts;

    internal class Cat : Animal, ISound
    {
        public Cat(int age, string name, SexType sex)
            : base(age, name, sex)
        {
        }
        
        public override void MakeSound()
        {
            Console.WriteLine("Meow! Meow! Meow!"); 
        }
    }
}
