using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using SharedAPI.Data_Transfer;

namespace Repository
{
    public class OrderProductRepository : RepositoryBase<OrderProducts>, IOrderProductRepository
    {
        public OrderProductRepository(RepositoryContext context) : base(context)
        {
            
        }

        public void CreateOrderProduct(OrderProducts orderProduct)
        {
            Create(orderProduct);
        }

        public void DeleteOrderProduct(OrderProducts orderProduct)
        {
            Delete(orderProduct);
        }
    }
}
