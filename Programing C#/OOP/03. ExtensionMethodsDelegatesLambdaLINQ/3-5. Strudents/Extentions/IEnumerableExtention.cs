namespace Students.Extentions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal static class IEnumerableExtention
    {
        internal static IEnumerable<T> SortStudentsUsingLinq<T>(
            this IEnumerable<T> students) where T : Student
        {
            var result = from student in students
                         orderby student.FirstName descending,
                         student.LastName descending
                         select student;

            return result;
        }

        internal static IEnumerable<T> SortStudentsUsingLambda<T>(
            this IEnumerable<T> students) where T : Student
        {
            return students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);
        }

        internal static IEnumerable<T> FindStudentsInAgeRange<T>(
                this IEnumerable<T> students,
                int minAge = 18,
                int maxAge = 24) where T : Student
        {
            var result =
                from student in students
                where student.Age >= minAge && student.Age < maxAge
                select student;

            return result;
        }

        internal static IEnumerable<T> FindFirstBeforeLastName<T>(
            this IEnumerable<T> students) where T : Student
        {
            var result =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            return result;
        }

        internal static IEnumerable<T> FindStudentsFromGivenGroup<T>(
            this IEnumerable<T> allStudents,
            int groupNumber)
            where T : Student
        {
            var result = from student in allStudents
                         where student.GroupNumber == 2
                         orderby student.FirstName
                         select student;

            return result;
        }

        internal static IEnumerable<T> FindStudentsFromGGivenGroupUsingLambda<T>(
            this IEnumerable<T> allStudents,
            int groupNumber)
            where T : Student
        {
            return allStudents
                .Where(st => st.GroupNumber == 2)
                .OrderBy(st => st.FirstName);
        }

        internal static IEnumerable<T> FindSudentsWithSGivenEmailDomain<T>(
            this IEnumerable<T> allStudents,
            string domain)
            where T : Student
        {
            return allStudents.Where(st => st.Email.Contains(domain));
        }

        internal static IEnumerable<T> FindSudentsWithSGivenphoneAreaCode<T>(
            this IEnumerable<T> allStudents,
            string phoneCode)
                   where T : Student
        {
            return allStudents.Where(st => st.PhoneNumber.StartsWith(phoneCode));
        }

        internal static object[] FindSudentsWithSGivenMark<T>(
            this IEnumerable<T> allStudents,
            double mark)
            where T : Student
        {
            var selectedStudents = allStudents.Where(st => st.Marks.Any(m => m.CompareTo(mark) == 0))
             .Select(st => (new
             {
                 FullName = st.FullName,
                 Marks = string.Join(" ", st.Marks)
             }))
            .ToArray();

            return selectedStudents;
        }

        internal static IEnumerable<T> FindStudentsWithGivenMarksCount<T>(
            this IEnumerable<T> allStudents,
            int count)
              where T : Student
        {
            return allStudents.Where(st => st.Marks.Count == count);
        }

        internal static string[] FindStudentsEnrolled2006<T>(this IEnumerable<T> allStudents)
             where T : Student
        {
            return allStudents
                .Where(st => st.FacultyNumber.Substring(4, 2) == "06")
                .Select(st => string.Join(" ", st.Marks))
                .ToArray();
        }

        internal static IEnumerable<T> FindStudentsFromGivenDepartment<T>(
            this IEnumerable<T> allStudents,
            string departament)
             where T : Student
        {
            var selected = from student in allStudents
                           where student.CourseGroup.DepartmentName == departament
                           select student;
            return selected;
        }

        internal static IEnumerable<IGrouping<int?, T>> GroupedByGroupNumberLinq<T>(this IEnumerable<T> allStudents)
            where T : Student
        {
            var groups = from student in allStudents
                         group student by student.GroupNumber into grupa
                         orderby grupa.Key
                         select grupa;

            return groups.ToList();
        }

        internal static IEnumerable<IGrouping<int?, T>> GroupedByGroupNumberLambda<T>(
            this IEnumerable<T> allStudents)
              where T : Student
        {
            return allStudents
                .OrderBy(st => st.GroupNumber)
                .GroupBy(st => st.GroupNumber)
                .ToList();
        }

        internal static void PrintGrouping<T>(this IEnumerable<IGrouping<int?, T>> colection)
              where T : Student
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var group in colection)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Group {group.Key}");
                Console.ForegroundColor = ConsoleColor.White;
                group
                .ToList()
               .ForEach(y => Console.WriteLine($"{y.FullName}"));
            }
        }

        internal static void Print<T>(this IEnumerable<T> students) where T : Student
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        internal static void PrintSelected(this object[] selectedStudents)
        {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in selectedStudents)
            {
                Console.WriteLine(item);
            }
        }
    }
}
