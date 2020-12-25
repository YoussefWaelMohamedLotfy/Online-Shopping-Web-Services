using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.ViewModels
{
    public class StoreViewModel
    {
        public List<Item> Items { get; set; }
    }

    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
    }
}