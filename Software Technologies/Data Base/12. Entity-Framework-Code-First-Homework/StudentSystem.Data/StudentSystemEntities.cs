using StudentSystem.Models;
using System.Data.Entity;

namespace StudentSystem.Data
{
    public class StudentSystemEntities : DbContext
    {
        public StudentSystemEntities() : base("StudentSystem")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<CourseMaterial> CourseMaterials { get; set; }
    }
}
