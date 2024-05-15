using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Events
{
    public class EditEventModel : PageModel
    {
        private FakeEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }
        public EditEventModel() 
        { 
            repo = new FakeEventRepository();
        }
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid )
            {
                return Page();
            }
            repo.UpdateEvent(Event);
            return RedirectToPage("Index");
        }
    }
}
