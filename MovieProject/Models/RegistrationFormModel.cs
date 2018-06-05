using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Models
{
    public class RegistrationFormModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Username")]
        [MinLength(2, ErrorMessage = "Username is at least 8 symbols")]
        [MaxLength(20, ErrorMessage = "Username is max 50 symbols")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "First name is at least 2 symbols")]
        [MaxLength(20, ErrorMessage = "First name is max 20 symbols")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last name is at least 2 symbols")]
        [MaxLength(20, ErrorMessage = "Last name is max 20 symbols")]
        public string LastName { get; set; }       
           
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        [Remote("ValidateEmail", "Home",ErrorMessage = "This email is already used! Try another email!")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Password must be between 1 and 20 characters!")]
        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}