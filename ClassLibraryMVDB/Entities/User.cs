using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectDB.Entities
{
    public class User
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 20 characters!")]
        [Required(ErrorMessage = "UserName is needed!")]
        public string UserName { get; set; }


        [StringLength(20, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 20 characters!")]
        [Required(ErrorMessage = "First name is needed!")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 20 characters!")]
        [Required(ErrorMessage = "Last name is needed!")]
        public string LastName { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Field must be between 5 and 20 characters!")]
        [Required(ErrorMessage = "Email is needed!")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Field must be between 1 and 50 characters!")]
        [Required(ErrorMessage = "Password is needed!")]
        public string Password { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Phone number is needed!")]
        public string PhoneNumber { get; set; }
        
        [StringLength(50, ErrorMessage = "Filling this field is optional.")]
        public string Address { get; set; }
    }
}
