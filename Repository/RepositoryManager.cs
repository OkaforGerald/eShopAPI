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

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            storeRepository = new Lazy<IStoreRepository>(new StoreRepository(repositoryContext));
            productRepository = new Lazy<IProductRepository>(new ProductRepository(repositoryContext));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IStoreRepository stores => storeRepository.Value;

        public IProductRepository products => productRepository.Value;
    }
}
