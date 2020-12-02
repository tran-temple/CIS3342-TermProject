using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceLibrary
{
    public class Question
    {
        private int questionID;
        private string questionDescription;

        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionDescription { get => questionDescription; set => questionDescription = value; }
    }
}
