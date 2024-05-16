using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Events
{
    public class ViewEventModel : PageModel
    {
        IRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public ViewEventModel(IRepository repository)
        {
            repo = repository;
        }
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }

    }
}
