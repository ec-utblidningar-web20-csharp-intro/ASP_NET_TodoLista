using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Todo> Todos { get; set; }

        public void Seed()
        {
            this.Todos.RemoveRange(this.Todos);

            this.Todos.AddRange(new List<Models.Todo>() {
                    new Models.Todo(){ Action="Vattna blommorna"},
                    new Models.Todo(){ Action="Vattna elefanten", IsDone=true},
                    new Models.Todo(){ Action="Gå med hunden"},
                });

            this.SaveChanges();
        }
    }
}
