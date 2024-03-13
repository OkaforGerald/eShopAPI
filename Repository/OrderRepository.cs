using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public async Task<List<Order>> GetOrdersForUserStore(Guid StoreId, bool trackChanges)
        {
            return await FindByCondition(x => x.StoreId == StoreId, trackChanges)
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUser(string username, bool trackChanges)
        {
            return await FindByCondition(x => x.Buyer == username, trackChanges)
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product)
                .OrderByDescending (x => x.CreatedAt)
                .ToListAsync();
        }
    }
}
