using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZooEvent.Pages.Students
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            // You can add any logic needed on GET request here
        }

        public IActionResult OnPost()
        {
            if (IsValidUser(Username, Password))
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
            // Replace this with your actual user validation logic
            return username == "admin" && password == "password";
        }
    }
}