using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class User
    {
        //properties
        private int userID;
        private string username;
        private string password;
        private string firstname;
        private string lastname;
        private string userType;
        private string email;
        private string street;
        private string city;
        private string state;
        private string zipcode;
        private string phone;
        private int questionID1;
        private string answer1;
        private int questionID2;
        private string answer2;
        private int questionID3;
        private string answer3;
        private int subscriptionID;
        private int status;

        public User()
        {

        }

        // Encapsulate fields
        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string UserType { get => userType; set => userType = value; }
        public string Email { get => email; set => email = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string Phone { get => phone; set => phone = value; }
        public int QuestionID1 { get => questionID1; set => questionID1 = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public int QuestionID2 { get => questionID2; set => questionID2 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public int QuestionID3 { get => questionID3; set => questionID3 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public int SubscriptionID { get => subscriptionID; set => subscriptionID = value; }
        public int Status { get => status; set => status = value; }
    }
}
