using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order : EntityBase
    {
        public Guid StoreId { get; set; }

        public string? Buyer { get; set; }

        public ICollection<OrderProducts>? OrderProducts {  get; set; } 

        public decimal OrderPrice { get; set; }

        public decimal OrderQuantity { get; set; }
    }
}
