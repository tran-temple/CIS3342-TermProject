using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class ConfirmUser : System.Web.UI.Page
    {
        LoginService loginService = new LoginService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["username"] = "";
                Session["usertype"] = Constant.GUEST;

                string key = Request.QueryString["key"];
                UserConfirm userConfirm = loginService.GetVerifiedUser(key);

                // verify successful
                if (userConfirm != null)
                {
                    loginService.UpdateUserStatus(userConfirm.UserID, 1);
                    lblSuccessMessage.Text = "Your user is confirmed.";
                }
                else
                {
                    lblErrorMessage.Text = "The link is expired.";
                }
                loginService.DeleteVerifiedUser(key);
            }
        }

        protected void btnGoToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}