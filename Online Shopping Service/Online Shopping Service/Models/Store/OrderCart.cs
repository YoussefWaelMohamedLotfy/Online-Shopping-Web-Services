using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class OrderCart
    {
        public OrderCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartID { get; set; }

        public double Total { get; set; }

        public string PaymentMethod { get; set; }
        
        public string UserEmail { get; set; }

        public bool IsCheckedOut { get; set; }

        public DateTime? PurchaseDate { get; set; }
        
        public DateTime? ArrivalDate { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}