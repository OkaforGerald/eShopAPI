using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Request_Features
{
    public class ProductParameters : RequestParameters
    {
        public uint minPrice { get; set; } = 0;

        public uint maxPrice { get; set; } = uint.MaxValue;

        public string? searchTerm { get; set; } = "";
    }
}
