using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Review
    {
        //properties
        private int reviewID;
        private int userID;
        private int productID;
        private int rating;
        private string comments;
        private DateTime reviewDate;

        public Review()
        {

        }

        // Encapsulate fields
        public int ReviewID { get => reviewID; set => reviewID = value; }
        public int UserID { get => userID; set => userID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public int Rating { get => rating; set => rating = value; }
        public string Comments { get => comments; set => comments = value; }
        public DateTime ReviewDate { get => reviewDate; set => reviewDate = value; }
    }
}
