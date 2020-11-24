using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class OrderItem
    {
        //properties
        private int itemID;
        private int orderID;
        private int productID;
        private double itemPrice;
        private int itemQuantity;

        public OrderItem()
        {

        }

        // Encapsulate fields
        public int ItemID { get => itemID; set => itemID = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public double ItemPrice { get => itemPrice; set => itemPrice = value; }
        public int ItemQuantity { get => itemQuantity; set => itemQuantity = value; }
    }
}
