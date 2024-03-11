using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IStoreRepository stores { get; }

        IProductRepository products { get; }

        ICategoryRepository category { get; }

        ICartItemRepository cartItem { get; }

        ICartRepository cart { get; }

        IOrderRepository orders { get; }

        IOrderProductRepository orderProduct { get; }

        Task Save();
    }
}
