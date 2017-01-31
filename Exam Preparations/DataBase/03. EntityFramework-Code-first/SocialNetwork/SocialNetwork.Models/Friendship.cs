using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.Messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("FirstUser")]
        public int FirstUserId { get; set; }

        public virtual User FirstUser { get; set; }

        [ForeignKey("SecondUser")]
        public int SecondUserId { get; set; }

        public virtual User SecondUser { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? FriendsSience { get; set; }

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
    }
}
