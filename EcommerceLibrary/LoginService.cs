using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLibrary
{
    public class LoginService
    {
        DBConnect objDB = new DBConnect();

        // Get user by username
        public User GetUserByUsername(string username)
        {
            User user = new User();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUserByUsername";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theUsername", username);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 20;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (resultDS.Tables.Count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    user.UserID = int.Parse(row["UserID"].ToString());
                    user.Username = row["Username"].ToString();
                    user.Password = row["Password"].ToString();
                    user.Firstname = row["FirstName"].ToString();
                    user.Lastname = row["LastName"].ToString();
                    user.UserType = row["UserType"].ToString();
                }
            }
            return user;
        }

        //Get the list of questions
        public DataSet GetQuestions()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetQuestions";

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Insert user
        public int InsertUser(User user)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_InsertUser";
           
            //set value for input parameter
            objCommand.Parameters.AddWithValue("@theUsername", user.Username);
            objCommand.Parameters.AddWithValue("@thePassword", user.Password);
            objCommand.Parameters.AddWithValue("@theFirstname", user.Firstname);
            objCommand.Parameters.AddWithValue("@theLastname", user.Lastname);
            objCommand.Parameters.AddWithValue("@theEmail", user.Email);
            objCommand.Parameters.AddWithValue("@theUsertype", user.UserType);
            objCommand.Parameters.AddWithValue("@theStreet", user.Street);
            objCommand.Parameters.AddWithValue("@theCity", user.City);
            objCommand.Parameters.AddWithValue("@theState", user.State);
            objCommand.Parameters.AddWithValue("@theZipcode", user.Zipcode);
            objCommand.Parameters.AddWithValue("@thePhone", user.Phone);
            objCommand.Parameters.AddWithValue("@theQuestion1", user.QuestionID1);
            objCommand.Parameters.AddWithValue("@theAnswer1", user.Answer1);
            objCommand.Parameters.AddWithValue("@theQuestion2", user.QuestionID2);
            objCommand.Parameters.AddWithValue("@theAnswer2", user.Answer2);
            objCommand.Parameters.AddWithValue("@theQuestion3", user.QuestionID3);
            objCommand.Parameters.AddWithValue("@theAnswer3", user.Answer3);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}
