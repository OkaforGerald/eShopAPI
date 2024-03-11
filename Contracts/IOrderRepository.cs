using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using SharedAPI.Request_Features;

namespace Contracts
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        void DeleteOrder(Order order);

        Task<List<Order>> GetOrdersForUserStore(Guid StoreId, bool trackChanges);

        Task<List<Order>> GetOrdersByUser(string username, bool trackChanges);
    }
}
