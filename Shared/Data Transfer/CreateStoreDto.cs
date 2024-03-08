using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public record CreateStoreDto
    {
        [Required]
        public string? Name { get; init; }

        //[EmailAddress]
        //public string? Email { get; init; }

        //public string? PhoneNumber { get; init; }

        public string? Url { get; init; }

        [Required]
        public string? Address { get; init; }

        [Required]
        public string? Country { get; init; }
    }

}
