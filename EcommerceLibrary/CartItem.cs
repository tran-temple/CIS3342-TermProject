using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public  class CartItem
    {
        private int productID;
        private string productName;
        private double productPrice;
        private int quantity;
        private string imageURL;
        private string type;

        public CartItem()
        {

        }

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }

        public string Type { get => type; set => type = value; }
    }
}
