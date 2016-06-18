namespace Students.Tests
{
    using System;
    using Extentions;
    using Models;

    public class StudentArrayTest
    {
        public static void Run()
        {
            var students = new Student[]
            {
                new Student("Pesho", "Petrov", 15),
                new Student("Pesho", "Kostov", 22),
                new Student("John", "Smith", 25),
                new Student("Reny", "Adamescu", 20),
                new Student("Fred", "Gogov", 23),
                new Student("Gosho", "Popov", 29)
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("03. First name is before last name");
            students.FindFirstBeforeLastName().Print();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("04. Students in age range 18 - 24");
            students.FindStudentsInAgeRange().Print();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("05. Sorted decending with Lambda");
            students.SortStudentsUsingLambda().Print();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("05. Sorted decending with LINQ");
            students.SortStudentsUsingLinq().Print();
        }
    }
}
