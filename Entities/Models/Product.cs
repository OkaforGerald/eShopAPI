using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Brand { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid StoreId { get; set; }
        public Store? Store { get; set;}

    }
}
