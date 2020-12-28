using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_Service.Models;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.ViewModels
{
    public class StoreViewModel
    {
        public IEnumerable<Item> Items { get; set; }
    }

    public class CartViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public OrderCart Cart { get; set; }
        public double CartTotal { get; set; }
    }

    public class NewItemViewModel
    {
        public Item Item { get; set; }
    }

    public class CheckoutViewModel
    {
        public OrderCart Cart { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public double CartTotal { get; set; }
        public ApplicationUser CurrentUser { get; set; }
    }
}