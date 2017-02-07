using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoListBbContext:DbContext
    {
        public virtual IDbSet<ToDo> ToDos { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }
    }
}