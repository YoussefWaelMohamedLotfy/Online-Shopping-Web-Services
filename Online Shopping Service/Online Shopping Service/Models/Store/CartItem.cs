using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class CartItem
    {
        public Item Item { get; set; }

        public int Count { get; set; }
    }
}