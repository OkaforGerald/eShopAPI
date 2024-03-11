using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IStoreRepository> storeRepository;
        private readonly Lazy<IProductRepository> productRepository;
        private readonly Lazy<ICategoryRepository> categoryRepository;
        private readonly Lazy<ICartItemRepository> cartItemRepository;
        private readonly Lazy<ICartRepository> cartRepository;
        private readonly Lazy<IOrderRepository> orderRepository;
        private readonly Lazy<IOrderProductRepository> orderProductRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            storeRepository = new Lazy<IStoreRepository>(new StoreRepository(repositoryContext));
            productRepository = new Lazy<IProductRepository>(new ProductRepository(repositoryContext));
            categoryRepository = new Lazy<ICategoryRepository>(new CategoryRepository(repositoryContext));
            cartItemRepository = new Lazy<ICartItemRepository>(new CartItemRepository(repositoryContext));
            cartRepository = new Lazy<ICartRepository>(new CartRepository(repositoryContext));
            orderRepository = new Lazy<IOrderRepository>(new OrderRepository(repositoryContext));
            orderProductRepository = new Lazy<IOrderProductRepository>(new OrderProductRepository(repositoryContext));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IStoreRepository stores => storeRepository.Value;

        public IProductRepository products => productRepository.Value;

        public ICategoryRepository category => categoryRepository.Value;

        public ICartItemRepository cartItem => cartItemRepository.Value;

        public ICartRepository cart => cartRepository.Value;

        public IOrderRepository orders => orderRepository.Value;

        public IOrderProductRepository orderProduct => orderProductRepository.Value;
    }
}
