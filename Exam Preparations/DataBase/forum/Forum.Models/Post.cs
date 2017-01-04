using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Post
    {
        public Post()
        {
            this.CreateOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreateOn { get; set; }

        public int CatrgotyId { get; set; }

        public virtual Category Category { get; set; }

        public string Content { get; set; }

        public ICollection

    }
}