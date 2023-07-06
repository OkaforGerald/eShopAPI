using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Request_Features
{
    public class ProductParameters : RequestParameters
    {
        public string? searchTerm { get; set; } = "";
    }
}
