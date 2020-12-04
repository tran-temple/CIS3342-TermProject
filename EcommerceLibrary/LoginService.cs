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
            User user = null;

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
                user = new User();
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    user.UserID = int.Parse(row["UserID"].ToString());
                    user.Username = row["Username"].ToString();
                    user.Password = row["Password"].ToString();
                    user.Firstname = row["FirstName"].ToString();
                    user.Lastname = row["LastName"].ToString();
                    user.UserType = row["UserType"].ToString();
                    user.Email = row["Email"].ToString();
                    user.QuestionID1 = int.Parse(row["QuestionID_1"].ToString());
                    user.QuestionID2 = int.Parse(row["QuestionID_2"].ToString());
                    user.QuestionID3 = int.Parse(row["QuestionID_3"].ToString());
                    user.Answer1 = row["Answer_1"].ToString();
                    user.Answer2 = row["Answer_2"].ToString();
                    user.Answer3 = row["Answer_3"].ToString();
                    user.Street = row["Street"].ToString();
                    user.City = row["City"].ToString();
                    user.State = row["State"].ToString();
                    user.Zipcode = row["Zipcode"].ToString();
                    user.Status = int.Parse(row["Status"].ToString());
                    string subcriptionId = row["SubscriptionID"].ToString();
                    if (!string.IsNullOrWhiteSpace(subcriptionId))
                    {
                        user.SubscriptionID = int.Parse(row["SubscriptionID"].ToString());
                    }
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

        public Question GetQuestionByID(int id)
        {
            Question question = null;
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetQuestionByID";

            objCommand.Parameters.AddWithValue("@theID", id);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (resultDS.Tables.Count > 0)
            {
                question = new Question();
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    question.QuestionID = int.Parse(row["QuestionID"].ToString());
                    question.QuestionDescription = row["QuestionDescription"].ToString();

                }
            }

            return question;
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

        //Update user status
        public int UpdateUserStatus(int userID, int status)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateUserStatus";

            //set value for input parameter
            objCommand.Parameters.AddWithValue("@theID", userID);
            objCommand.Parameters.AddWithValue("@theStatus", status);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        // Update user password
        public int UpdateUserPassword(int userID, String password)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateUserPassword";

            //set value for input parameter
            objCommand.Parameters.AddWithValue("@theID", userID);
            objCommand.Parameters.AddWithValue("@thePassword", password);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Insert verified user
        public int InsertVerifiedUser(int userID, string userKey)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_InsertVerifiedUser";

            //set value for input parameter
            objCommand.Parameters.AddWithValue("@theID", userID);
            objCommand.Parameters.AddWithValue("@theKey", userKey);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Delete verified user
        public int DeleteVerifiedUser(String userKey)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteVerifiedUser";

            //set value for input parameter
            objCommand.Parameters.AddWithValue("@theKey", userKey);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Get verified user
        public UserConfirm GetVerifiedUser(string userKey)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetVerifiedUser";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theKey", userKey);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.VarChar;
            inputParam.Size = 60;
            objCommand.Parameters.Add(inputParam);
            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);

            UserConfirm userConfirm = null;

            if (resultDS.Tables.Count > 0)
            {
                userConfirm = new UserConfirm();
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    userConfirm.UserID = int.Parse(row["UserID"].ToString());
                    userConfirm.Key = row["UserKey"].ToString();
         
                }
            }
            return userConfirm;
        }
    }
}
