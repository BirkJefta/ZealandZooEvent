using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Events;



public class DeleteEvent : PageModel
{
    IRepository repo;

    [BindProperty]
    public Event Event { get; set; }
    public DeleteEvent(IRepository repository)
    {
        repo = repository;
    }
    public IActionResult OnGet(int id)
    {
        Event = repo.GetEvent(id);
        return Page();
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        repo.DeleteEvent(Event);
        return RedirectToPage("Index");
    }
}