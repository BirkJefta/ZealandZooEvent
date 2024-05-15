using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Events
{
    public class EditEventModel : PageModel
    {
        private FakeEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }
        public EditEventModel() 
        { 
            repo = FakeEventRepository.Instance;
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
