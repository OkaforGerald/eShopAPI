using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SharedAPI.Data_Transfer
{
    public record ProductModifyingDto
    {
        [Required(ErrorMessage ="Name Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Brand Required")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Price Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity Required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Category Required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Image Required")]
        public IFormFile? Image { get; set; }
    }
}
