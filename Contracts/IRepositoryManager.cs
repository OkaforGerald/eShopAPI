﻿using System;
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

        Task Save();
    }
}
