using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooEvent.Models;
using System;
using ZealandZooEvent.Interfaces;

namespace ZealandZooEvent.Pages.Student
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        private readonly IRepository _studentRepository;

        public RegisterModel(IRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void OnGet()
        {
            // Add any logic needed on GET request
        }

        
    }
}