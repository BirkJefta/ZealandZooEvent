using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Events
{
    public class IndexModel : PageModel
    {
        IRepository repo;

        public List<Event> Events { get; private set; }
        [BindProperty]public string FilterCriteria { get; set; }

        public IndexModel(IRepository repository)
        {
            repo = repository;
        }
        public void OnGet()
        {
            Events = repo.GetAllEvents();
        }
        public void OnPost()
        {
            if(!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }
            else
            {
                Events = repo.GetAllEvents();
            }
        }
    }
}
