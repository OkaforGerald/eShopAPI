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

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            storeRepository = new Lazy<IStoreRepository>(new StoreRepository(repositoryContext));
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public IStoreRepository stores => storeRepository.Value;

    }
}
