using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;
using ZealandZooEvent.Services;
namespace ZealandZooEvent.Pages.Events;

public class DeleteEvent : PageModel
{
    
    private IRepository repo;

    [BindProperty] public Event Event { get; set; }

    public DeleteEvent(IRepository repository)
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
        repo.RemoveEvent(Event);
        return RedirectToPage("Index");
    } 

    
}