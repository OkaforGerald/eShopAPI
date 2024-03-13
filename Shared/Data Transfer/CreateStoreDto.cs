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
        public string? Name { get; set; }

        //[EmailAddress]
        //public string? Email { get; init; }

        //public string? PhoneNumber { get; init; }

        public string? Url { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Country { get; set; }
    }

}
