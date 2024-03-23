using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public class ReviewResponseDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ReviewerName { get; set; }

        [Range(0, 6)]
        public decimal Rating { get; set; }

        public string? Review { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

    }
}
