using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class Order
    {
        // Auto-implemented properties
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; }
        public List<Item> Items { get; set; }
    }
}