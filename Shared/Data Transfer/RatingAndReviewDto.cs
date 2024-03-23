using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Data_Transfer
{
    public class RatingAndReviewDto
    {
        public decimal Rating { get; set; }

        public string? Review { get; set; }
    }
}
