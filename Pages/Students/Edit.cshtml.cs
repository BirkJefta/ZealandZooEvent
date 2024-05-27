using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public EditModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public Student Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _studentRepository.UpdateStudent(Student);
            
            TempData["Message"] = "Ændringerne er blevet gemt.";
            return RedirectToPage("/Students/StudentProfile");
        }
    }
}