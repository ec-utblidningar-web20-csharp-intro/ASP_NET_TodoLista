using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            this._logger = logger;
        }

        public string MyMessage { get; set; }

        // detta är en PageHandler för http GET requests
        public void OnGet()
        {
            MyMessage = "Hej min vän, allt är";
            MyMessage += this.Response.StatusCode;
        }

        // detta är en PageHandler för http OPTION requests
        public void OnOption()
        {

        }
    }
}
