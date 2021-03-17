using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Data.TodoDbContext>();

                Models.Todo rec = null;

                // [C]reate
                // lägga till record
                rec = new Models.Todo() { Action = "hej", IsDone = false };
                context.Todos.Add(rec);
                context.SaveChanges();

                // [R]ead
                // läsa av records
                List<Models.Todo> recs = context.Todos.ToList();
                foreach (var record in recs)
                {
                    Console.WriteLine(record.Action);
                }

                // [U]pdate
                // uppdatera record
                rec = context.Todos.FirstOrDefault();
                rec.IsDone = true;
                context.Todos.Update(rec);
                context.SaveChanges();

                // [D]elete
                // radera record
                rec = context.Todos.Where(r => r.IsDone == true).FirstOrDefault();
                context.Todos.Remove(rec);
                context.SaveChanges();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
