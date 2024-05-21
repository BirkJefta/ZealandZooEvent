using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Students
{
    public class StudentProfileModel : PageModel
    {
        IStudentRepository _studentRepository;
        [BindProperty]
        public Student student {get; set; }
        public StudentProfileModel(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
            student = studentRepository.LoggedInStudent();
        }
        public void OnGet()
        {

        }
    }
}
