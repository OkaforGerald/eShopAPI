using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Store : EntityBase
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Url { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
