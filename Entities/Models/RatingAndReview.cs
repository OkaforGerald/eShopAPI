using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RatingAndReview : EntityBase
    {
        public Guid ProductId { get; set; }

        public string userId { get; set; }

        [Range(0, 6)]
        public decimal Rating { get; set; }

        public string? Review { get; set; }
    }
}
