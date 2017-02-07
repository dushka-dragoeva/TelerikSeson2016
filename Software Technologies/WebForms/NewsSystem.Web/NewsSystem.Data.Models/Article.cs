using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsSystem.Data.Models
{
   /* The ForeignKeyAttribute on property 'Category' on type 'NewsSystem.Data.Models.Article' 
    is not valid.The foreign key name 'ArticleId' was not found on the dependent type 'NewsSystem.Data.Models.Article'.
        The Name value should be a comma separated list of foreign key property names."}*/
    public class Article
    {
        private ICollection<Like> likes;

        public Article()
        {
            this.likes = new HashSet<Like>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
            }
        }
    }
}