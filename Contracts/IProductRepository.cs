﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProducts(Guid StoreId, ProductParameters parameters, bool trackChanges);

        Task<Product> GetProductById(Guid StoreId,  Guid ProductId, bool trackChanges);
    }
}
