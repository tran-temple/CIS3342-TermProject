using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLibrary
{
    public class Utilities
    {
        DBConnect objDB = new DBConnect();

        //Get the list of Products
        public DataSet GetReviews()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetProducts";

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get the list of Reviews of a product
        public DataSet GetReviewsByRestID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetReviewsByProductID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        // Get user by username
        public User GetUserByUsername(string username)
        {
            User user = new User();

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetUserByUsername";

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
                    user.Firstname = row["FirstName"].ToString();
                    user.Lastname = row["LastName"].ToString();
                    user.UserType = row["UserType"].ToString();
                }
            }
            return user;
        }
    }
}
