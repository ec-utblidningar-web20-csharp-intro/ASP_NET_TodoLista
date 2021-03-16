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

        // detta är en PageHandler för http GET requests
        public void OnGet()
        {
        }

        // detta är en PageHandler för http OPTION requests
        public void OnOption()
        {

        }
    }
}
