﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IOrderProductRepository
    {
        void CreateOrderProduct(OrderProducts orderProduct);

        void DeleteOrderProduct(OrderProducts orderProduct);
    }
}
