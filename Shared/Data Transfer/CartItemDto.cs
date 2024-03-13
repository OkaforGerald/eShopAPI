using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace SharedAPI.Data_Transfer
{
    public class CartItemDto
    {
        public OrderProducsDto Product { get; set; }

        public int QuantityInCart { get; set; }
    }
}
