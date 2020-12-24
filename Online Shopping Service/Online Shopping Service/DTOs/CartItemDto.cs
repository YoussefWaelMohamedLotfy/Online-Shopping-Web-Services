using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.DTOs
{
    public class CartItemDto
    {
        public int ID { get; set; }

        public int ItemID { get; set; }

        public string UserEmail { get; set; }

        public int Count { get; set; }

        public bool IsCheckedOut { get; set; }

        public int CartID { get; set; }
    }
}