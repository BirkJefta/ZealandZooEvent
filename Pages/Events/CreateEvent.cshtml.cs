using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Events;

public class CreateEvent : PageModel
{
    private FakeEventRepository repo;

    [BindProperty] public Event Event { get; set; }

    public CreateEvent()
    {
        repo = new FakeEventRepository();
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        repo.AddEvent(Event);
        return RedirectToPage("Index");
    } 
}