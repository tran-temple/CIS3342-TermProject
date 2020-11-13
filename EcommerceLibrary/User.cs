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
        private string firstname;
        private string lastname;
        private string userType;

        public User()
        {

        }

        // Encapsulate fields
        public int UserID { get => userID; set => userID = value; }
        public string Username { get => username; set => username = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string UserType { get => userType; set => userType = value; }
    }
}
