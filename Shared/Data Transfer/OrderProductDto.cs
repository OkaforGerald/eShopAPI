using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SharedAPI.Data_Transfer
{
    public class OrderProductDto
    {
        public Guid Id { get; set; }

        public string SellerName {  get; set; }

        public string SellerLocation { get; set; }

        public string SellerPhone { get; set; }

        public string Buyer {  get; set; }

        public string BuyerNumber { get; set; }

        public string OrderSummary { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Price { get; set; }
    }
}
