using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shared.Data_Transfer
{
    public record ProductCreationDto
    {
        [Required(ErrorMessage ="Name Required")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Description Required")]
        public string? Description { get; init; }

        [Required(ErrorMessage = "Brand Required")]
        public string? Brand { get; init; }

        [Required(ErrorMessage = "Price Required")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Quantity Required")]
        public int Quantity { get; init; }

        [Required(ErrorMessage = "Category Required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Image Required")]
        public IFormFile? Image { get; init; }
    }
}
