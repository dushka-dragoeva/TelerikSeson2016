using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int UserId { get; set; }

        public virtual User User {get; set ;}
    }
}
