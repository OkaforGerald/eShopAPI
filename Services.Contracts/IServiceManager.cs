using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IStoreService stores { get; }

        ICategoryService category { get; }

        IProductService products { get; }

        IAuthService auth { get; }

        ICartService cart { get; }

        IRatingService rating { get; }
    }
}
