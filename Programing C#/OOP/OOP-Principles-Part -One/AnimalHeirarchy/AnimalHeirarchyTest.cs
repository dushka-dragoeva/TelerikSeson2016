namespace AnimalHeirarchy
{
    using System;
    using System.Linq;

    using Models;

    public class AnimalHeirarchyTest
    {
        public static void Run()
        {
            Animal[] animals =
            {
                new Dog(3, "Rex", SexType.Male),
                new Dog(2, "Jorko", SexType.Male),
                new Dog(4, "Pepa", SexType.Female),
                new Dog(6, "Pesho", SexType.Male),

                new Frog(2, "Jabko", SexType.Male),
                new Frog(3, "Kikerica", SexType.Female),

                new Cat(7, "Maca", SexType.Female),
                new Tomcat(5, "Tom", SexType.Male),
                new Tomcat(3, "Gosho", SexType.Male),
                new Kitten(2, "Macka", SexType.Female),
                new Kitten(2, "Pepita", SexType.Female),
            };

            var dogs = animals.Where(d => d is Dog);
            var frogs = animals.Where(f => f is Frog);
            var cats = animals.Where(c => c is Cat);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Animal Heirarchy Test");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Dogs'  avarige age is: {Dog.CalculateAverageAge(dogs)}");
            Console.WriteLine($"Frogs' avarige age is: {Frog.CalculateAverageAge(frogs)}");
            Console.WriteLine($"Cats'  avarige age is: {Cat.CalculateAverageAge(cats)} ");
        }
    }
}
