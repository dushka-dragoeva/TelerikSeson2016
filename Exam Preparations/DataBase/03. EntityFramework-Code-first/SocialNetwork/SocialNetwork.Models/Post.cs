using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
   public class Post
    {
        private ICollection<User> taggedUsers;

        public Post()
        {
            this.TaggedUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20000)]
        public string Content { get; set; }

        public DateTime PostenOn { get; set; }

        public virtual ICollection<User> TaggedUsers
        {
            get
            {
                return this.taggedUsers;
            }

            set
            {
                this.taggedUsers = value;
            }
        }
    }

}
