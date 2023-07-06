using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data_Transfer
{
    public record ProductsDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public string? Description { get; init; }

        public string? Brand { get; init; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; init; }

        public int Quantity { get; init; }
    }
}
