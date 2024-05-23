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
        IRepository repo;

        public List<Event> Events { get; private set; }
        [BindProperty] public string FilterCriteria { get; set; }
        [BindProperty] public DateTime? StartDate { get; set; }
        [BindProperty] public DateTime? EndDate { get; set; }
        [BindProperty] public string SortCriteria { get; set; }

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
            Events = repo.GetAllEvents();

            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }

            if (StartDate.HasValue && EndDate.HasValue)
            {
                Events = Events.Where(e => e.Time.Date >= StartDate.Value.Date && e.Time.Date <= EndDate.Value.Date).ToList();
            }

            if (!string.IsNullOrEmpty(SortCriteria))
            {
                switch (SortCriteria)
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
                }
            }
        }
    }

}
