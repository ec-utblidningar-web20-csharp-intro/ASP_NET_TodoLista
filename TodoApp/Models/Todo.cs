using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Todo
    {
        public int ID { get; set; }
        public string Action { get; set; }
        public bool IsDone { get; set; }
    }
}
