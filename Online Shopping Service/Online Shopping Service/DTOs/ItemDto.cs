using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.DTOs
{
    public class ItemDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public byte RemainingCount { get; set; }

        //public virtual CartItem CartItem { get; set; }
    }
}