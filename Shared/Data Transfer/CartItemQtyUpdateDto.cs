using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public class CartItemQtyUpdateDto
    {
        public Guid CartItemId { get; set; }
        public int Qty { get; set; }
    }
}
