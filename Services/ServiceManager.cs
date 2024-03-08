using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _service;
        private readonly Lazy<IProductService> _prodService;
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICartService> _cartService;

        public ServiceManager(IMapper mapper, IRepositoryManager repositoryManager, UserManager<User> userManager,IConfiguration configuration)
        {
            _service = new Lazy<IStoreService>(new StoreService(mapper, repositoryManager, userManager));
            _prodService = new Lazy<IProductService>(new ProductService(mapper, repositoryManager, userManager));
            _authService = new Lazy<IAuthService>(new AuthService(userManager, mapper, configuration));
            _categoryService = new Lazy<ICategoryService>(new CategoryService(repositoryManager, mapper));
            _cartService = new Lazy<ICartService>(new CartService(repositoryManager, mapper, userManager));
        }

        public IStoreService stores => _service.Value;

        public IProductService products => _prodService.Value;

        public IAuthService auth => _authService.Value;

        public ICategoryService category => _categoryService.Value;

        public ICartService cart => _cartService.Value;
    }
}
