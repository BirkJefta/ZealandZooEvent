using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Events
{
    public class ViewEventModel : PageModel
    {
        IRepository repo;
        private IStudentRepository _studentRepository;
        [BindProperty]
        public Event Event { get; set; }
        public ViewEventModel(IRepository repository, IStudentRepository studentRepository)
        {
            repo = repository;
            _studentRepository = studentRepository;
        }
        public IActionResult OnGet(Guid id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }
    }
}
