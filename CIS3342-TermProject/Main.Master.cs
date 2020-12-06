using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usertype"] != null)
            {
                if (Session["usertype"].ToString() != Constant.GUEST)
                {
                    lblUsername.Visible = true;
                    btnSignOut.Visible = true;
                    lblUsername.Text = "Logged in as " + Session["username"] + Session["userid"];
                }
                else
                {
                    btnSignUp.Visible = true;
                }
                SetMenu();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Registration.aspx");
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        private void SetMenu()
        {
            switch (Session["usertype"])
            {
                case Constant.CUSTOMER:
                    btnMyCart.Visible = true;
                    btnPurchaseHistory.Visible = true;
                    btnMySub.Visible = true;
                    break;
                case Constant.OWNER:
                    btnAddProduct.Visible = true;
                    btnModifySubscription.Visible = true;
                    break;
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductPage.aspx?action=add");
        }

        protected void btnMyCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }
        protected void btnMySub_Click (object sender, EventArgs e)
        {
            Response.Redirect("MySubscription.aspx");
        }

       protected void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseHistory.aspx");
        }

        protected void btnModifySubscription_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSubscription.aspx");
        }
    }
}