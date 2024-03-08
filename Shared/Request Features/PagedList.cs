using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPI.Request_Features
{
    public class PagedList<T> : List<T>
    {
        public Metadata Metadata { get; set; }

        public PagedList(IEnumerable<T> items, int count, int PageNumber, int PageSize)
        {
            Metadata = new Metadata
            {
                CurrentPage = PageNumber,
                PageSize = PageSize,
                TotalCount = count,
                TotalPages = (int) Math.Ceiling(count / (double) PageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> items, int pageNumber, int pageSize)
        {
            int count = items.Count();

            var pagedItems = items.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(pagedItems, count, pageNumber, pageSize);
        }
    }
}