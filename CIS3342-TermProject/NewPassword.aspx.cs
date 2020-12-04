using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class NewPassword : System.Web.UI.Page
    {
        LoginService loginService = new LoginService();
        Utilities utils = new Utilities();


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
                   // currently do nothing
                }
                else
                {
                    lblGeneral_Error.Text = "The link is expired.";
                }
            }

        }

        private bool ValidatePassword()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                lblNewPassword_Error.Text = "Password cannot be empty.";
                result = false;
            }
            else
            {
                if (!utils.IsValidPassword(txtNewPassword.Text))
                {
                    lblNewPassword_Error.Text = "Password requirements:  must be eight characters or longer, "
                        + "must contain at least 1 lowercase alphabetical character, "
                        + "must contain at least 1 uppercase alphabetical character, "
                        + "must contain at least 1 numeric character, "
                        + "must contain at least one special character.";
                    result = false;
                }
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                lblConfirmPassword_Error.Text = "Password is not match.";
                result = false;
            }
            return result;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // clear error message
            ClearMessages();
            string key = Request.QueryString["key"];
            UserConfirm userConfirm = loginService.GetVerifiedUser(key);
            if (ValidatePassword()) {
                // update password to database
                string enscriptedPassword = utils.EncryptSensitiveInfo(txtNewPassword.Text.Trim());
                loginService.UpdateUserPassword(userConfirm.UserID, enscriptedPassword);
                // redirect to login
                Response.Redirect("Login.aspx");
            }
        }

        private void ClearMessages()
        {
            lblNewPassword_Error.Text = "";
            lblGeneral_Error.Text = "";
            lblConfirmPassword_Error.Text = "";

        }
    }
}