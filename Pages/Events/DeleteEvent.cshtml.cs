using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Services;
using System;

namespace ZealandZooEvent.Pages.Events;



public class DeleteEvent : PageModel
{
    IRepository repo;
    IStudentRepository studentRepository;

    [BindProperty]
    public Event Event { get; set; }
    public DeleteEvent(IRepository repository, IStudentRepository _studentRepo)
    {
        repo = repository;
        studentRepository = _studentRepo;
    }


    public IActionResult OnGet(Guid id)
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
        studentRepository.DeleteEventFromStudent(Event.Id);
        repo.DeleteEvent(Event);
        return RedirectToPage("/Events/AdminPage");
    }
}