using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_Service.Core.Repositories;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.Persistence.Repositories
{
    public class ItemsRepository : Repository<Item>, IItemsRepository
    {
        public ItemsRepository(ApplicationDbContext context) : base(context)
        {
        }


        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}