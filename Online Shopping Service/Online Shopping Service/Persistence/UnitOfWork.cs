using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_Service.Core;
using Online_Shopping_Service.Core.Repositories;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Persistence.Repositories;

namespace Online_Shopping_Service.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Repositories
        public IItemsRepository Items { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Items = new ItemsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}