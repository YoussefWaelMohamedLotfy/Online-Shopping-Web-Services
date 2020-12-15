using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class Card
    {
        public string CardNumber { get; set; }

        public string Name { get; set; }

        public int CVV { get; set; }

        public float CurrentBalance { get; set; }
    }
}