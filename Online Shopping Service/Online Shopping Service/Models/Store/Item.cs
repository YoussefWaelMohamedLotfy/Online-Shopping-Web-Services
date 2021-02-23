using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class Item
    {
        public Item()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        [Display(Name = "Stock Count")]
        public byte RemainingCount { get; set; }

        public DateTime AddedOn { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}