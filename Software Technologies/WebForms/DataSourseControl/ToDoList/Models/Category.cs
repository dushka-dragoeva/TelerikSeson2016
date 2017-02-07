using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Category
    {
        private ICollection<ToDo> toDos;

        public Category()
        {
            this.Messages = new HashSet<ToDo>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<ToDo> Messages
        {
            get
            {
                return this.toDos;
            }

            set
            {
                this.toDos = value;
            }
        }
    }
}