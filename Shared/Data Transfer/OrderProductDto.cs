using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public class OrderProductDto
    {
        public Guid Id { get; set; }

        public string Buyer {  get; set; }

        public string OrderSummary { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Price { get; set; }
    }
}
