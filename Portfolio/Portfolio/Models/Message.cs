using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your lastname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Gender:")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Your Email Address:")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Your Mobile Number (if possible):")]
        public string Mobile { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comments:")]
        public string ExtraComment { get; set; }
    }
}
