using StudentSystem.Models;
using System.Linq;

using StudentSystem.Data;
using StudentSystem.Utilities;

namespace StudentSystem.ConsoleApplication
{
    public class Importer
    {
        public static void AddCourses(int coursesCount, StudentSystemEntities dbContext)
        {
            for (int i = 0; i < coursesCount; i++)
            {
                var course = new Course();
                course.Name = RandomGenerator.GenerateString(2, 150);
                dbContext.Courses.Add(course);
            }

            dbContext.SaveChanges();
        }

        public static void AddStudents(int studentsCount, StudentSystemEntities dbContext)
        {
            for (int i = 0; i < studentsCount; i++)
            {
                var student = new Student();
                student.FirstName = RandomGenerator.GenerateString(1, 50);
                student.LastName = RandomGenerator.GenerateString(1, 50);
                student.FacultyNumber = RandomGenerator.GenerateNumberAsString(10, 10);
                var courses = dbContext.Courses.ToList();
                int courseIndex = RandomGenerator.GenerateIntenger(0, courses.Count - 1);
                var course = courses[courseIndex];
                student.Courses.Add(course);

                dbContext.Students.Add(student);
            }

            dbContext.SaveChanges();
        }

        public static void AddHomeworks(int homeworksCount, StudentSystemEntities dbContext)
        {
            var coursesIds = dbContext.Courses
                                 .Select(c => c.Id)
                                 .ToList();
            int coursesIdsCount = coursesIds.Count;

            var studentsIds = dbContext.Students
                                   .Select(s => s.Id)
                                   .ToList();

            int studentIdsCount = studentsIds.Count;

            for (int i = 0; i < homeworksCount; i++)
            {
                var hw = new Homework();
                hw.Content = RandomGenerator.GenerateString(1, 2000);
                hw.TimeSent = RandomGenerator.GenarateDateInPast();

                int courseIndex = RandomGenerator.GenerateIntenger(0, coursesIdsCount - 1);
                hw.CourseId = coursesIds[courseIndex];

                int studentIndex = RandomGenerator.GenerateIntenger(0, studentIdsCount - 1);
                hw.StudentId = studentsIds[studentIndex];

                dbContext.Homeworks.Add(hw);
            }

            dbContext.SaveChanges();
        }
    }
}
