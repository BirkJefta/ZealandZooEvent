using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;

namespace ZealandZooEvent.Pages.Students
{
    public class JoinEventModel : PageModel
    {
        private IStudentRepository _studentRepository;
        JoinEventModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult OnGet(int id)
        {
            TempData["Message"] = "Event has been added.";
            _studentRepository.AddToAttendEvent(id);
            return Page();
        }
    }
}
