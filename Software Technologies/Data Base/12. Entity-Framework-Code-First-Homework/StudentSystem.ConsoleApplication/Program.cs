using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using System.Data.Entity;

namespace StudentSystem.ConsoleApplication
{
    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntities, Configuration>());

            var dbContext = new StudentSystemEntities();

            using (dbContext)
            {
                Importer.AddCourses(50, dbContext);
                Importer.AddStudents(150, dbContext);
                Importer.AddHomeworks(450, dbContext);

                var studentsInLiWuCurs = Searcher.GetAllStudenstByCourseName("LiWU", dbContext);

                foreach (var student in studentsInLiWuCurs)
                {
                    System.Console.WriteLine($"{student.FacultyNumber} --> {student.FirstName} {student.LastName}");
                }
            }
        }
    }
}