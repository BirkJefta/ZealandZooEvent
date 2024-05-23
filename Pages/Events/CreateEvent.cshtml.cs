using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Events;

public class CreateEvent : PageModel
{
    private IRepository repo;

    [BindProperty] public Event Event { get; set; }

    public CreateEvent(IRepository repository)
    {
        repo = repository;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        repo.AddEvent(Event);
        return RedirectToPage("/Events/AdminPage");
    } 
}
