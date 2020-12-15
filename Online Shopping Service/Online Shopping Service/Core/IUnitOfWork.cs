using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Service.Core
{
    public interface IUnitOfWork
    {


        int Complete();
    }
}
