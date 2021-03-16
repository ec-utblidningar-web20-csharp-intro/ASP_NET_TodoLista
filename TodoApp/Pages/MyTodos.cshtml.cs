using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace TodoApp.Pages
{
    public class MyTodosModel : PageModel
    {
        public List<Models.Todo> Todos { get; set; }

        [BindProperty]
        public Models.Todo NewTodo { get; set; }

        private readonly ILogger<ErrorModel> _logger;
        private readonly Data.TodoDbContext _context;

        public MyTodosModel(ILogger<ErrorModel> logger,
            Data.TodoDbContext context)
        {
            _context = context;
            _logger = logger;

            Todos = _context.Todos.ToList();
        }
        public void OnGet()
        {
            _logger.LogInformation("Nu fick vi en GET request");
        }
        public void OnPost()
        {
            _logger.LogInformation("Nu fick vi en POST request");

            Todos.Add(NewTodo);
            _context.Todos.Add(NewTodo);
            _context.SaveChanges();
        }
    }
}
