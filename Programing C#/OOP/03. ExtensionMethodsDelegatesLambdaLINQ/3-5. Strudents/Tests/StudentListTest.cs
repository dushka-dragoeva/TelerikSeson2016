namespace Students.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extentions;
    using Models;

    public class StudentListTest
    {
        public static void Run()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Angel", "Georgiev", 22, "896506", "042 456 321", "a.georgiev@dir.bg", new Group(2, "FMI")));
            students[0].AddMarks(4.0, 6.0);
            students.Add(new Student("Gosho", "Dinev", 23, "789607", "02 456 322", "g.dinev@abv.bg", new Group(2, "Mathematics")));
            students[1].AddMarks(4, 3, 5);
            students.Add(new Student("Ani", "Petrova", 34, "7896106", "0887 456 323", "a.petrova@abv.bg", new Group(2, "Biolagy")));
            students[2].AddMarks(2, 3, 5);
            students.Add(new Student("Pesho", "Ivanov", 21, "896205", "056 456 324", "p.ivanov@abv.bg", new Group(3, "FMI")));
            students[3].AddMarks(4, 6);
            students.Add(new Student("Dragan", "Georgiev", 32, "654106", "02 456 325", "d.georgiev@adir.bg", new Group(3, "FMI")));
            students[4].AddMarks(4, 4, 3, 5, 3);
            students.Add(new Student("Ivan", "Peevski", 33, "964107", "02 456 333", "i.peevski@abv.bg", new Group(2, "Mathematics")));
            students[5].AddMarks(6);
            students.Add(new Student("Peter", "Dimitrov", 20, "654108", "0887 456 334", "p.dimitrov@abv.bg", new Group(6, "FMI")));
            students[6].AddMarks(4, 6, 3, 3, 2);
            students.Add(new Student("Rosen", "Popov", 20, "789109", "0887 456 335", "r.popov@abv.bg", new Group(2, "Mathematics")));
            students[7].AddMarks(3);
            students.Add(new Student("Desi", "Georgieva", 19, "954206", "0887 456 316", "d.georgieva@dir.bg", new Group(2, "FMI")));
            students[8].AddMarks(6, 6, 5, 4, 6, 4);
            students.Add(new Student("Maria", "Mileva", 18, "652105", "02 456 356", "m.mileva@abv.bg", new Group(1, "Biolagy")));
            students[9].AddMarks(6, 6, 6, 6);

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("09. Students in group 2 - LINQ query, оrdered by FirstName");
            StudentCollection.Print(StudentCollection.FindStudentsFromGivenGroup(students, 2));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("10. Students in group 2 - LINQ extension methods, оrdered by FirstName");
            StudentCollection.Print(StudentCollection.FindStudentsFromGGivenGroupUsingLambda(students, 2));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("11. Students with emails in abv.bg");
            StudentCollection.Print(StudentCollection.FindSudentsWithSGivenEmailDomain(students, "abv.bg"));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("12. Students with phones in Sofia");
            StudentCollection.Print(StudentCollection.FindSudentsWithSGivenphoneAreaCode(students, "02 "));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("13. Students with at least one 6");
            StudentCollection.PrintSelected(StudentCollection.FindSudentsWithSGivenMark(students, 6.0));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("14. Students with exaactlly 2 marks");
            StudentCollection.Print(StudentCollection.FindStudentsWithGivenMarksCount(students, 2));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("16. Students in \"Mamthematics department\"");
            var selected = StudentCollection.FindStudentsFromGivenDepartment(students, "Mathematics");
            StudentCollection.Print(selected);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("15. Marks of students enrolled 2006");
            Console.ForegroundColor = ConsoleColor.White;
            var marks = StudentCollection.FindStudentsEnrolled2006(students);
            Console.WriteLine(string.Join("\n", marks));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("18. Grouped by Group number LINQ");
            var groupedStidents = StudentCollection.GroupedByGroupNumberLinq(students).ToList();
            StudentCollection.PrintGrouping(groupedStidents);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("19. Grouped by Group number Extention Methods");
            groupedStidents = StudentCollection.GroupedByGroupNumberLambda(students).ToList();
            StudentCollection.PrintGrouping(groupedStidents);
        }
    }
}
