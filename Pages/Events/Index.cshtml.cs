using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Events
{
    public class IndexModel : PageModel
    {
        private FakeEventRepository repo;

        public List<Event> Events { get; private set; }

        public IndexModel()
        {
            repo = new FakeEventRepository();
        }
        public void OnGet()
        {
            Events = repo.GetAllEvents();
        }
    }
}
