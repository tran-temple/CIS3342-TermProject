using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Constant
    {
        public const string CUSTOMER = "Customer";
        public const string OWNER = "Owner";
        public const string GUEST = "Visitor";

        public const double FREE_SHIPPING_STANDARD = 50.0; //Free shipping $50 up
        public const double TAX = 0.0; //This is a sweet chocolate store (free tax)
        public const double SHIPPING_FEE = 4.99; //Shipping fee: $4.99 for all orders < $50
    }
}
