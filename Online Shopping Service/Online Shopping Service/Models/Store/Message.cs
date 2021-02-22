using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping_Service.Models.Store
{
    public class Message
    {
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        public DateTime SendTime { get; set; }

        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Message()
        {
            SendTime = DateTime.Now;
        }
    }
}