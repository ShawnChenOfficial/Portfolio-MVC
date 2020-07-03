using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Model
{
    public class Message
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Lastname:")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Gender:")]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Company Name:")]
        public string Company { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Company Region:")]
        public string CompanyRegion { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Company Location:")]
        public string CompanyLocation { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Your Email Address:")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Your Mobile Number:")]
        public string Mobile { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comments:")]
        public string ExtraComment { get; set; }
    }
}
