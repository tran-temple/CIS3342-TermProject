using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    List<CartItem> cart = (List<CartItem>)Session["Cart"];
                    lvShoppingBag.DataSource = cart;
                    lvShoppingBag.DataBind();
                }
                else
                {
                    lblGeneral_Error.Text = "You have not added any item in the shopping cart!";
                }
            }

        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }
    }
}