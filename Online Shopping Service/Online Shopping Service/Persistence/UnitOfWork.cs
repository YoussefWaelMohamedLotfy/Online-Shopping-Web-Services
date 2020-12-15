using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_Service.Core;

namespace Online_Shopping_Service.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly PlutoContext _context;

        //public UnitOfWork(PlutoContext context)
        //{
        //    _context = context;
        //}

        public int Complete()
        {
            throw new NotImplementedException();
            //return _context.SaveChanges();
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}