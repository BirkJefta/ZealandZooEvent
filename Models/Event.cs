using System;
using System.ComponentModel.DataAnnotations;

namespace ZealandZooEvent.Models
{
    public class Event
    {
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        public int Id { get; set; }

        [Display(Name = "Price")]
        
        [Range(0,100000,ErrorMessage ="Value must be above {1}")]
        public double? Price { get; set; }

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Event name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Date is required")]
        [Range(typeof(DateTime),"1/1/2024","10/1/2100",ErrorMessage ="Value must be between {1} and {2}")]

        public DateTime? Time { get; set; }
        [Required(ErrorMessage = "Image Url is required")]
        [Url(ErrorMessage = "Invalid Url Format")]
        public string PictureUrl { get; set; }



    }
}
