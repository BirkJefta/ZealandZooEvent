using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ZealandZooEvent.Pages.Events {
    public class OpeningHoursModel : PageModel {
        
        private readonly ILogger<OpeningHoursModel> _logger;
        

        public OpeningHoursModel(ILogger<OpeningHoursModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
