using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;
namespace ZealandZooEvent.Pages.Students
{
    public class JoinEventModel : PageModel
    {
        private readonly IRepository repo;
        private readonly IStudentRepository _studentRepository;
        public Event Event { get; set; }
        public JoinEventModel(IRepository repository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            repo = repository;
        }

        public IActionResult OnGet(Guid id)
        {
            string result = _studentRepository.AddToAttendEvent(id);
            Event = repo.GetEvent(id);
            if (Event.CurrentParticipants < Event.MaxParticipants)
            {
                switch (result)
                {
                    case "Success":
                        TempData["Message"] = "Event has been added.";
                        Event.CurrentParticipants++;
                        repo.UpdateEvent(Event);
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
            }
            
            
            string referringUrl = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referringUrl);
        }
    }
}
