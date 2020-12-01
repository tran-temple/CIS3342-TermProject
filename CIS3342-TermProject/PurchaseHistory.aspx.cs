using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Net;
using EcommerceLibrary;

using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{

    public partial class PurchaseHistory : System.Web.UI.Page
    {
        public int userid2;


        OrderSvc.OrderService pxy = new OrderSvc.OrderService();

        protected void Page_Load(object sender, EventArgs e)
        {

            string userid = Session["userid"].ToString();
            userid2 = int.Parse(userid);




            lblHeading.Text = "Purchase History for:  " + Session["username"].ToString();

            if (pxy.GetHistory(userid2).Tables[0].Rows.Count > 0)
            {
                gvHistory.DataSource = pxy.GetHistory(userid2);
                gvHistory.DataBind();

            }

            else
            {
                lblDisplay.Text = "Sorry " + Session["username"].ToString() + " you have no purchase history.";

            }
        }

    }
}
    

