using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.ConsoleApplication
{
   public class Searcher
    {
        public static ICollection<Student> GetAllStudenstByCourseName(string courseName, StudentSystemEntities dbContext)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentNullException("The course name cant not be null or enpty string");
            }

            Course course = dbContext.Courses.Where(c => c.Name == courseName).FirstOrDefault();

            if (course == null)
            {
                throw new ArgumentException(nameof(courseName),$"This {courseName} dont exist");
            }

            var students = course.Students;

            return students;
        }
    }
}
