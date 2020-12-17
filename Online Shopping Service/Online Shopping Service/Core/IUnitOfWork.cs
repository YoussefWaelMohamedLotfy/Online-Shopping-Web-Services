using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Shopping_Service.Core.Repositories;

namespace Online_Shopping_Service.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IItemsRepository Items { get; }


        int Complete();
    }
}
