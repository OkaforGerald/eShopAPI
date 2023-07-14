using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data_Transfer
{
    public record CreateUserDto
    {
        [Required(ErrorMessage ="First Name Required")]
        public string? FirstName { get; init; }

        [Required(ErrorMessage = "Last Name Required")]
        public string? LastName { get; init; }

        [EmailAddress(ErrorMessage ="Please Provide a Valid Email Address")]
        [Required]
        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }

        [Required]
        public string? Password { get; init; }

        [NotMapped]
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        public string? ConfirmPassword { get; init; }

        public ICollection<string>? Roles { get; init; } = new List<string>()
        {
            "User"
        };
    }
}
