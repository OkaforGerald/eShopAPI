using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart : EntityBase
    {
        public string? userId { get; set; }
        public User? user { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
