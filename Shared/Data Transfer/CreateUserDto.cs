using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public record CreateUserDto
    {
        [Required(ErrorMessage ="First Name Required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string? LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+\d{4}@student\.babcock\.edu\.ng$", ErrorMessage ="Please input a valid babcock Email Address")]
        [EmailAddress(ErrorMessage ="Please Provide a Valid Email Address")]
        [Required]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string? ConfirmPassword { get; set; }

        public ICollection<string>? Roles { get; set; } = new List<string>()
        {
            "User"
        };
    }
}
