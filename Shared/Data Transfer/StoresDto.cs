using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public record StoresDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }

        public string? Url { get; init; }

        public string? FullAddress { get; init; }

        public string? OwnedBy { get; init; }

        public bool requestedByOwner { get; set; } = false;

        public bool storeOwner { get; set; }
    }
}
