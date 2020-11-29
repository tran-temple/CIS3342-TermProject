using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Order
    {
        //properties
        private int orderID;
        private int userID;
        private string shippingAddress;
        private double orderTotal;
        private DateTime orderDate;
        private string paymentMethod;

        public Order()
        {

        }

        // Encapsulate fields
        public int OrderID { get => orderID; set => orderID = value; }
        public int UserID { get => userID; set => userID = value; }
        public string ShippingAddress { get => shippingAddress; set => shippingAddress = value; }
        public double OrderTotal { get => orderTotal; set => orderTotal = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
    }
}
