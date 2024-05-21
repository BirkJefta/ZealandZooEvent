using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Interfaces;
using ZealandZooEvent.Models;

namespace ZealandZooEvent.Pages.Students
{
    public class LoginModel : PageModel
    {
        [BindProperty] public Student Student { get; set; }
        public string ErrorMessage { get; set; }

        private IStudentRepository _studentRepository;

        public LoginModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (IsValidUser(Student.Email, Student.Password))
            {
                // User is valid, redirect to a different page
                return RedirectToPage("/Index");
            }
            else
            {
                // User is invalid, show error message
                ErrorMessage = "Invalid username or password";
                return Page();
            }
        }

        private bool IsValidUser(string username, string password)
        {
            bool isvalid = false;
            foreach (var v in _studentRepository.GetAllStudents())
            {
                if (v.Email == username && v.Password == password) 
                {
                    isvalid=true;
                }
            }
            return isvalid;
             


        }
    }
}