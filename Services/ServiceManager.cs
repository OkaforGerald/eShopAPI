using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _service;
        private readonly Lazy<IProductService> _prodService;

        public ServiceManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _service = new Lazy<IStoreService>(new StoreService(mapper, repositoryManager));
            _prodService = new Lazy<IProductService>(new ProductService(mapper, repositoryManager));
        }

        public IStoreService stores => _service.Value;

        public IProductService products => _prodService.Value;
    }
}
