using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZealandZooEvent.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage ="Must enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Must enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telephone { get; set; }

        public bool isAdmin { get; set; }
        public List<int>IdJoinedEvents { get; set; } = new List<int>();
    }
}
