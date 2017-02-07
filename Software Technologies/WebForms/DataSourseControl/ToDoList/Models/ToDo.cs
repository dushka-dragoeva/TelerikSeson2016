using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public virtual Category CategoryId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(2000)]
        public string Body { get; set; }

        public DateTime? LastChange { get; set; }
    }
}