using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Students
{
    public class StudentProfileModel : PageModel
    {
        IStudentRepository _studentRepository;
        IRepository _repo;
        [BindProperty]
        public List<Event> Events { get; set; }

        [BindProperty]
        public Student student {get; set; }
        public StudentProfileModel(IStudentRepository studentRepository, IRepository repo) {
            _studentRepository = studentRepository;
            _repo = repo;
            student = studentRepository.LoggedInStudent();
            Events = new List<Event>();
        }
        public IActionResult OnGet()
        {
            Events = _studentRepository.GetListOfJoinedEvents(student);
            return Page();
        }
        


    }
}
