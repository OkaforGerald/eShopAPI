using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class StoreNotFoundException : NotFoundException
    {
        public StoreNotFoundException(Guid Id) : base($"Store with id {Id} does not exist")
        {
            
        }
    }
}
