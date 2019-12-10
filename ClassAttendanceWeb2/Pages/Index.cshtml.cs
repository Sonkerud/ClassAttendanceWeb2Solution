using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassAttendanceWeb2.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ClassAttendanceWeb2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IWebHostEnvironment WebHostEnvironment { get; }

        JsonFileStudentService StudentService = new JsonFileStudentService();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
