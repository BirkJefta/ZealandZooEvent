using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Events
{
    public class AdminPageModel : PageModel
    {
        IRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public List<Event> Events { get; private set; }
        [BindProperty] public string FilterCriteria { get; set;}
        public AdminPageModel(IRepository repository) 
        {
            repo= repository;
        }
        public void OnGet()
        {
            Events = repo.GetAllEvents();
        }
        public void OnPost()
        {
            if (!string.IsNullOrEmpty(FilterCriteria))
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
