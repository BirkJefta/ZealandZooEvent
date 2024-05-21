using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;
using System;
using ZealandZooEvent.Interfaces;
using System.ComponentModel;
using ZealandZooEvent.Services;

namespace ZealandZooEvent.Pages.Students
{
    public class RegisterModel : PageModel
    {

        [BindProperty] public Student Student { get; set; }

        private IStudentRepository _studentRepository;

        public RegisterModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void OnGet()
        {
            // Add any logic needed on GET request
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _studentRepository.AddStudent(Student);
            return RedirectToPage("/Student/Login");
        }
        
    }
}