using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data_Transfer
{
    public record AuthenticateUserDto
    {
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [Required]
        public string? email { get; set; }

        [Required(ErrorMessage = "Please provide a password")]
        public string? password { get; set; }
    }
}
