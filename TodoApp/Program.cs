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
            SeedDb(host);
            host.Run();
        }

        static void SeedDb(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Data.TodoDbContext>();

                context.Todos.RemoveRange(context.Todos);

                context.Todos.AddRange(new List<Models.Todo>() {
                    new Models.Todo(){ Action="Vattna blommorna"},
                    new Models.Todo(){ Action="Vattna elefanten"},
                    new Models.Todo(){ Action="G� med hunden"},
                });

                context.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
