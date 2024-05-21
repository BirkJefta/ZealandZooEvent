using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRepository _repository;

        [BindProperty]
        public List<Event> Events { get; set; }


        public IndexModel(ILogger<IndexModel> logger, IRepository repository)
        {
            _repository = repository;
            _logger = logger;
            
        }

        public void OnGet()
        {
            Events = _repository.GetAllEvents();
        }
    }
}
