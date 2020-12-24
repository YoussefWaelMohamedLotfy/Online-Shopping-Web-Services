using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Shopping_Service.Models.Store;

namespace Online_Shopping_Service.DTOs
{
    public class OrderCartDto
    {
        public int ID { get; set; }

        public double Total { get; set; }

        public string PaymentMethod { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }
}