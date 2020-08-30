using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class StudentModel
    {
        [Display(Name = "Student ID")]
        [Range(100000, 999999, ErrorMessage = "You need to enter a valid Student ID")]
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to give your First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give your Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "You need to give a valid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirmed Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "The Confirmed Email and Email must match!")]
        public string ConfirmedEmail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You need to provide a long enough password!")]
        public string Password { get; set; }

        [Display(Name = "Confirmed Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Confirmed Password and Password do not match!")]
        public string ConfirmedPassword { get; set; }
    }
}