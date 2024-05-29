using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly IRepository repo;
        public List<Event> Events { get; private set; }
        [BindProperty] public string FilterCriteria { get; set; }
        [BindProperty] public DateTime? StartDate { get; set; }
        [BindProperty] public DateTime? EndDate { get; set; }
        public string CurrentSort { get; set; }

        public IndexModel(IRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(string sortOrder)
        {
            CurrentSort = sortOrder;
            Events = repo.GetAllEvents();

            // Apply filtering by name
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }

            // Apply date range filtering
            if (StartDate.HasValue && EndDate.HasValue)
            {
                Events = Events.Where(e => e.Time.Date >= StartDate.Value.Date && e.Time.Date <= EndDate.Value.Date).ToList();
            }

            // Apply sorting
            switch (sortOrder)
            {
                case "PriceDesc":
                    Events = Events.OrderByDescending(e => e.Price).ToList();
                    break;
                case "PriceAsc":
                    Events = Events.OrderBy(e => e.Price).ToList();
                    break;
                case "DateAsc":
                    Events = Events.OrderBy(e => e.Time).ToList();
                    break;
                case "DateDesc":
                    Events = Events.OrderByDescending(e => e.Time).ToList();
                    break;
                default:
                    break;
            }
            return Page();  
        }

        public void OnPost()
        {
            Events = repo.GetAllEvents();

            // Apply filtering by name
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }

            // Apply date range filtering
            if (StartDate.HasValue && EndDate.HasValue)
            {
                Events = Events.Where(e => e.Time.Date >= StartDate.Value.Date && e.Time.Date <= EndDate.Value.Date).ToList();
            }
        }
    }
}
