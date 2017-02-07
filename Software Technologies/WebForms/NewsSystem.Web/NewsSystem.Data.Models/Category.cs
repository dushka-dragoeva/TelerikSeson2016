using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsSystem.Data.Models
{
    public class Category
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }

      //  Column 'Name' in table 'dbo.Categories' is of a type that is invalid for use as a key column in an index."}
        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get
            {
                return this.articles;
            }

            set
            {
                this.articles = value;
            }
        }
    }
}
