using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Students
{
    public class StudentProfileModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public StudentProfileModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public Student student { get; set; }

        [BindProperty]
        public List<Event> Events { get; set; }

        public IActionResult OnGet()
        {
            // Hent den indloggede student
            student = _studentRepository.LoggedInStudent();

            // Altid initialiser Events som en ny liste, hvis den ikke allerede er initialiseret
            if (Events == null)
            {
                Events = new List<Event>();
            }

            // Hent listen over tilmeldte events for den indloggede student
            if (student != null)
            {
                Events = _studentRepository.GetListOfJoinedEvents(student);
            }
            else
            {
                TempData["ErrorMessage"] = "Fejl: Ingen indloggede student blev fundet";
                return RedirectToPage("/Error"); // Antagelse: Du har en fejlside oprettet under /Pages/Error.cshtml
            }

            // Tjek om der er en TempData-meddelelse og send den til visning på siden
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"].ToString();
            }

            return Page();
        }
    }
}