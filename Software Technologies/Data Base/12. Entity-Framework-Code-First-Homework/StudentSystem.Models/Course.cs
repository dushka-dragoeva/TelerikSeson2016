using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<CourseMaterial> materials;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Materials = new HashSet<CourseMaterial>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [MaxLength(2000)]
        public string Description { get; set; }

        public virtual ICollection<CourseMaterial> Materials
        {
            get { return this.materials; }

            set { this.materials = value; }
        }
        public virtual ICollection<Student> Students
        {
            get { return this.students; }

            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }

            set { this.homeworks = value; }
        }
    }
}