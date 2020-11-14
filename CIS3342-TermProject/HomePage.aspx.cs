using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;
using System.Data;
using System.Data.SqlClient;

namespace CIS3342_TermProject
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllSubscriptions";
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                DLSubscriptions.DataSource = myDS;
                DLSubscriptions.DataBind();
            }


        }

        protected void dlSubscriptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}