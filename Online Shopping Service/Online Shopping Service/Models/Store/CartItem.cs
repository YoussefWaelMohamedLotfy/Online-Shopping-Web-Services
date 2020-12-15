using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class CartItem
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public virtual Item Item { get; set; }

        public int Count { get; set; }

        public OrderCart Cart { get; set; }
    }
}