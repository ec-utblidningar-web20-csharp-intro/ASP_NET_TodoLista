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

        public MyTodosModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;

            Todos = new List<Models.Todo>()
            {
                new Models.Todo() { Action = "K�pa mj�lk" },
                new Models.Todo() { Action = "Vattna blommorna", IsDone=true },
                new Models.Todo() { Action = "G� ut med hunden", IsDone=true },
                new Models.Todo() { Action = "Skriva inl�mningsrapporten" },
            };
        }
        public void OnGet()
        {
            _logger.LogInformation("Nu fick vi en GET request");
        }
        public void OnPost()
        {
            _logger.LogInformation("Nu fick vi en POST request");

            Todos.Add(NewTodo);
        }
    }
}
