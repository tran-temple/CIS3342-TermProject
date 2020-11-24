using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class Item
    {
        // Auto-implemented properties
        public int ItemID { get; set; }
        public int ProductID { get; set; }
        public int ProductName { get; set; }
        public double ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
    }
}