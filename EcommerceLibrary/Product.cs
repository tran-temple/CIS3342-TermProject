using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Product
    {
        //properties
        private int productID;
        private int categoryID;
        private string productName;
        private string description;
        private double productPrice;
        private int productQuantity;
        private string imageURL;

        public Product()
        {

        }

        // Encapsulate fields
        public int ProductID { get => productID; set => productID = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Description { get => description; set => description = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }
        public int ProductQuantity { get => productQuantity; set => productQuantity = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
    }
}
