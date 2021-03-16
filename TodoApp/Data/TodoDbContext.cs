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
            this.Database.EnsureCreated();

            // Look for any todos.
            if (this.Todos.Any())
            {
                return;   // DB has been seeded
            }

            Todos.AddRange(new List<Models.Todo>()
            {
                new Models.Todo() { Action = "Köpa mjölk" },
                new Models.Todo() { Action = "Vattna blommorna", IsDone=true },
                new Models.Todo() { Action = "Gå ut med hunden", IsDone=true },
                new Models.Todo() { Action = "Skriva inlämningsrapporten" },
            });

            this.SaveChanges();
        }
    }
}
