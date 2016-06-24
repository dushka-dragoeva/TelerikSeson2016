namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class SchoolClassesTests
    {
        public static void Run()
        {
            Student aniPetrova = new Student("Ani", " Petrova", 1);
            Student gerogiMalinov = new Student("Gerogi", " Malinov", 2);
            Student hristoVasilev = new Student("Hristo ", "Vasilev", 3);

            List<Student> studentsInClassA = new List<Student>();
            studentsInClassA.Add(aniPetrova);
            studentsInClassA.Add(gerogiMalinov);
            studentsInClassA.Add(hristoVasilev);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("School Classes Tests");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var student in studentsInClassA)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            Discipline math = new Discipline("Math", 10, 10);
            Discipline language = new Discipline("Language", 20, 10);
            Discipline art = new Discipline("Art", 5, 10);

            Teacher petarPetrov = new Teacher("Petar", " Petrov");
            petarPetrov.AddDiscipline(math);
            petarPetrov.AddDiscipline(language);

            Teacher peshoPeshov = new Teacher("Pesho", "Peshov");
            peshoPeshov.AddDiscipline(art);

            List<Teacher> teachersForAClass = new List<Teacher>() { petarPetrov, peshoPeshov };

            Class classA = new Class("5A");
            classA.AddTeacher(petarPetrov);
            classA.AddTeacher(peshoPeshov);
            Console.WriteLine(classA.ToString() + "\n" + string.Join(", ", classA.Teachers));
            Console.WriteLine();

            // classA.AddComment("Hello");  /// uncoment to Thro exception
            classA.AddComment("Welcome! This is our first class.");
            classA.AddComment("This is our last class! Good Bye!");
        }
    }
}
