using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data_Transfer
{
    public record StoresDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public string? Email { get; init; }

        public string? PhoneNumber { get; init; }

        public string? Url { get; init; }

        public string? FullAddress { get; init; }
    }
}
