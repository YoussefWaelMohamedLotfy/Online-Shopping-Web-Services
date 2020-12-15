using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class OrderCart
    {
        public int ID { get; set; }

        public int Total { get; set; }

        public string PaymentMethod { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}