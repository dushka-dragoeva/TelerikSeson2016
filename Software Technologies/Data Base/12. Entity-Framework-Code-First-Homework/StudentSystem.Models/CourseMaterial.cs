using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class CourseMaterial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public static string Name { get; set; }

        [DataType(DataType.Url)]
        [MinLength(4)]
        [MaxLength(200)]
        public string Url { get; set; }

        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
    }
}
