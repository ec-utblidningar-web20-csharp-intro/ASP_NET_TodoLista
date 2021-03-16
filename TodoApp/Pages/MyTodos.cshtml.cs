using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoApp.Pages
{
    public class MyTodosModel : PageModel
    {
        public List<Models.Todo> Todos;
        public MyTodosModel()
        {
            Todos = new List<Models.Todo>()
            {
                new Models.Todo() { Action = "Köpa mjölk" },
                new Models.Todo() { Action = "Vattna blommorna", IsDone=true },
                new Models.Todo() { Action = "Gå ut med hunden", IsDone=true },
                new Models.Todo() { Action = "Skriva inlämningsrapporten" },
            };
        }
        // Ha en referens till en ToDo lista
        public void OnGet()
        {
        }
    }
}
