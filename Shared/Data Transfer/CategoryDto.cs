using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public record CategoryDto
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }
    }
}
