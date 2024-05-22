using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;

namespace ZealandZooEvent.Pages.Students
{
    public class StudentLogOutModel : PageModel
    {
        private IStudentRepository _studentRepository;

        public StudentLogOutModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult OnGet()
        {
            TempData["Message"] = "You have been successfully logged out.";
            _studentRepository.LogOut();
            return RedirectToPage("/Index");
        }
    }
}
