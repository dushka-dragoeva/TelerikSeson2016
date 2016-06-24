namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities.Extentions;

    public static class StudentsAndWorkersTest
    {
        public static void Run()
        {
            var students = new List<Student>();
            students.Add(new Student("Svetla", "Draganova", 3));
            students.Add(new Student("Georgi", "Ivanov", 9));
            students.Add(new Student("Ivan", "Petrov", 3));
            students.Add(new Student("Chavdar", "Kamenov", 10));
            students.Add(new Student("Ivan", "Kozhuharov", 10));
            students.Add(new Student("Georgi", "Stoyanov", 1));
            students.Add(new Student("Ivan", "Kovachev", 6));
            students.Add(new Student("Stefan", "Petrov", 6));
            students.Add(new Student("Martin", "Atanasov", 1));
            students.Add(new Student("Vera", "Govedarova", 2));

            var orderedStudents = students.OrderBy(st => st.Grade).ToList();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Students And Workers Test");
            Console.WriteLine("*Students Ordered by Grade");
            Console.ForegroundColor = ConsoleColor.White;
            orderedStudents.PrintCollection();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Simeon", "Petrov", 993, 12));
            workers.Add(new Worker("Severin", "Lakov", 809, 11));
            workers.Add(new Worker("Kliment", "Evgeniev", 384, 4));
            workers.Add(new Worker("Aleks", "Simeonov", 828, 5));
            workers.Add(new Worker("Teodor", "Hristov", 675, 4));
            workers.Add(new Worker("Andrey", "Sotirov", 688, 8));
            workers.Add(new Worker("Elena", "Viktorova", 589, 8));
            workers.Add(new Worker("Zafir", "Kaloyanov", 904, 10));
            workers.Add(new Worker("Plamen", "Antonov", 947, 8));
            workers.Add(new Worker("Fabian", "Kornelov", 970, 12));

            var sortedWorkers = workers
                .OrderByDescending(w => w.CalculateMoneyPerHour())
                .ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Workers Ordered by Money per Hour");
            Console.ForegroundColor = ConsoleColor.White;
            sortedWorkers.PrintCollection();

            var people = new List<Human>();
            people.AddRange(students);
            people.AddRange(workers);

            var sortedPeople = people.OrderBy(p => p.FirstName).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*All Ordered by First Name.");
            Console.ForegroundColor = ConsoleColor.White;
            sortedPeople.PrintCollection();

            var o = students[0] as object;
            var h = students[0] as Human;
            Console.WriteLine(h.ToString());

            /// uncoment to throw Exception. 
            ///  students.Add(new Student("Maria", "p",3));
            Console.WriteLine();
        }
    }
}
