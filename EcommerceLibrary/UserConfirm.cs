using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class UserConfirm
    {
        private int userID;
        private string key;

        public UserConfirm()
        {

        }

        public int UserID { get => userID; set => userID = value; }
        public string Key { get => key; set => key = value; }
    }
}
