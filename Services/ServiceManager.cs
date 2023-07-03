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

        public ServiceManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _service = new Lazy<IStoreService>(new StoreService(mapper, repositoryManager));
        }

        public IStoreService stores => _service.Value;
    }
}
