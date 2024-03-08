using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Request_Features
{
    public class StoreParameters : RequestParameters
    {
        public string? searchTerm { get; set; } = "";
    }
}
