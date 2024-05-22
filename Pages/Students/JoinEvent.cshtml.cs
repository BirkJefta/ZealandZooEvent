using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;

using ZealandZooEvent.Interfaces;
namespace ZealandZooEvent.Pages.Students
{
    public class JoinEventModel : PageModel
    {

        private readonly IStudentRepository _studentRepository;

        public JoinEventModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult OnGet(int id)
        {
            _studentRepository.AddToAttendEvent(id);
            TempData["Message"] = "Event has been added.";
            return RedirectToPage("/Events/ViewEvent", new { id = id });
        }
    }
}
