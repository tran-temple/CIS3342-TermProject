using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EcommerceLibrary;
using System.Collections;

using System.Data.SqlClient;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for OrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderService : System.Web.Services.WebService
    {

      
        [WebMethod]
        public DataSet GetHistory(int userid2)
        {
           
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            
            //   string userid2 = Session["userid"].ToString();
            //  int userID2 = int.Parse(userid2);


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPurchaseHistory";
            objCommand.Parameters.AddWithValue("@UserID", userid2);

            DataSet myDS2 = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS2;
        }




    }
}
