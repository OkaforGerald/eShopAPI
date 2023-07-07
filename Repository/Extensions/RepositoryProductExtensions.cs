using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Extensions
{
    public static class RepositoryProductExtensions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrEmpty(orderBy))
            {
                return query.OrderBy(e => e.CreatedAt);
            }

            var conditions = orderBy.Split(',');
            var properties = typeof(Product).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach(string condition in conditions)
            {
                var prop = condition.Trim().Split(' ');

                if(properties.FirstOrDefault(x => x.Name.Equals(prop[0].Trim(), StringComparison.InvariantCultureIgnoreCase)) != null)
                {
                    var direction = prop[1].Equals("asc") ? "Ascending" : "Descending";

                    sb.Append($"{prop[0].Trim()} {direction},");
                }
                
            }
            var sortQuery = sb.ToString().TrimEnd(',');

            return query.OrderBy(sortQuery);
        } 
    }
}
