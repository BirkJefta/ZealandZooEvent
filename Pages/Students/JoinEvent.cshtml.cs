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
            string result = _studentRepository.AddToAttendEvent(id);
            switch (result)
            {
                case "Success":
                    TempData["Message"] = "Event has been added.";
                    break;
                case "AlreadyAdded":
                    TempData["Message"] = "Event is already added.";
                    break;
                case "Failed":
                    TempData["Message"] = "Failed to add event.";
                    break;
                default:
                    TempData["Message"] = "unknown error. try again";
                    break;
            }
            string referringUrl = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referringUrl);
        }
    }
}
