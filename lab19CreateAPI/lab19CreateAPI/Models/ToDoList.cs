using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab19CreateAPI.Models
{
    public class ToDoList : DbContext
    {
        public ToDoList(DbContextOptions<ToDoList> options) : base(options)
        {

        }

        public DbSet<ToDo> Todos { get; set; }
    }
}
