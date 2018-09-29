using System;
using System.Collections.Generic;

namespace MyWebApp.Models
{
    public class Order
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
