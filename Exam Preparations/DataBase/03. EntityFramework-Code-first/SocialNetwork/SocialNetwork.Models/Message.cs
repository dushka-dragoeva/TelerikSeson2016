using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int FriendshipID { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        [MaxLength(20000)]
        public string Content { get; set; }

        [Index]
        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }

        [NotMapped]
        public bool Seen
        {
            get { return this.SeenOn.HasValue; }
        }
    }
}
