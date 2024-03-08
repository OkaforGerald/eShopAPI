using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CartItem
    {
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int QuantityInCart { get; set; }
    }
}
