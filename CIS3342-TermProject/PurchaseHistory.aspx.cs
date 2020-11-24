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
        OrderSvc.OrderService pxy = new OrderSvc.OrderService();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Test Webservice
            gvHistory.DataSource = pxy.HelloWorld();

            gvHistory.DataBind();
        }
    }
}
