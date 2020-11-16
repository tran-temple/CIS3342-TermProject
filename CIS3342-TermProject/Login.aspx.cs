using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        User objUser;
        Utilities utilities = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVisit_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["usertype"] = Constant.GUEST;

            Response.Redirect("HomePage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // main process after created procedure and have data user
                /*GetUserLogin(txtUsername.Text);
                lblGeneral_Error.Text = "";
                if (string.IsNullOrWhiteSpace(objUser.Username))
                {
                    lblGeneral_Error.Text = "Login failed! Please input a valid username!";
                    return;
                }
                Session["userid"] = objUser.UserID;
                Session["username"] = objUser.Username;
                Session["usertype"] = objUser.UserType;*/

                //testing nav bar with default owner
               // Session["userid"] = 7;
                //Session["username"] = "test_1";
                //Session["usertype"] = Constant.OWNER;

                //testing nav bar with default registered customer
                Session["userid"] = 7;
                Session["username"] = "test_2";
                Session["usertype"] = Constant.CUSTOMER;

                Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
        }

        private void GetUserLogin(string username)
        {
            objUser = utilities.GetUserByUsername(username);
        }
    }
}