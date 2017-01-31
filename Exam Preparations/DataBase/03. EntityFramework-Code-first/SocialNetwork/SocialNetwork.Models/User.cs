using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class User
    {
        private ICollection<Message> messages;
        private ICollection<Image> images;
        private ICollection<Post> posts;
        
        public User()
        {
            this.Messages = new HashSet<Message>();
            this.Images = new HashSet<Image>();
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(4)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }
    }
}
