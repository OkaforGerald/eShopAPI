using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Request_Features
{
    public class Metadata
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasNext => CurrentPage < TotalPages;

        public bool HasPrevious => CurrentPage > 1;
    }
}
