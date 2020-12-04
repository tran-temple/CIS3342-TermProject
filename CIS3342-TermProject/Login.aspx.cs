using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class Login : System.Web.UI.Page
    {        
        LoginService loginService = new LoginService();
        Utilities utils = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Read user info login from cookie
            if (!IsPostBack && Request.Cookies["LoginCookie"] != null)
            {
                HttpCookie myCookie = Request.Cookies["LoginCookie"];
                txtUsername.Text = myCookie.Values["Username"];
                //Decrypt the encrypted password
                String encryptedPassword = myCookie.Values["Password"];
                String plainTextPassword = utils.Decrypt(encryptedPassword);
                txtPassword.Text = plainTextPassword;
            }
            txtPassword.TextMode = TextBoxMode.Password;
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
                lblGeneral_Error.Text = "";
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (!ValidateUserLogin())
                {
                    lblGeneral_Error.Text = "Login failed!";
                    return;
                }
                User objUser = GetUserLogin(username);
                Session["userid"] = objUser.UserID;
                Session["username"] = objUser.Username;
                Session["usertype"] = objUser.UserType;

                // Write username and encrypted password to a cookie
                if (chkRememberMe.Checked)
                {
                    string encryptedPassword = utils.Encrypt(password);
                    HttpCookie myCookie = new HttpCookie("LoginCookie");
                    myCookie.Values["Username"] = username;
                    myCookie.Values["Password"] = encryptedPassword;
                    myCookie.Expires = new DateTime(2022, 1, 1);
                    Response.Cookies.Add(myCookie);
                }                

                Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
        }

        //Get user login info by username
        private User GetUserLogin(string username)
        {
            User objUser = loginService.GetUserByUsername(username);
            return objUser;
        }

        private void ClearTextbox()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void ClearErrorMessage()
        {            
            lblGeneral_Error.Text = "";
            lblUserName_Error.Text = "";
            lblPassword_Error.Text = "";
        }

        //Valid user login
        private bool ValidateUserLogin()
        {
            ClearErrorMessage();
            bool result = true;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            User objUser = new User();

            //Verify input username
            if (String.IsNullOrWhiteSpace(username))
            {
                lblUserName_Error.Text = "Please input username!";
                result = false;
            }
            //Verify input password
            if (String.IsNullOrWhiteSpace(password))
            {
                lblPassword_Error.Text = "Please input Password!";
                result = false;
            }
            //Verify valid of username and password
            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                objUser = loginService.GetUserByUsername(username);
                if (String.IsNullOrWhiteSpace(objUser.Username))
                {
                    lblUserName_Error.Text = "Username non-existed!";                 
                    result = false;
                }
                else
                {
                    string encryptedPassword = utils.EncryptSensitiveInfo(password);
                    if (!String.Equals(encryptedPassword, objUser.Password))
                    {
                        lblPassword_Error.Text = "Wrong Password!";
                        result = false;
                    }
                    else
                    {
                        if (objUser.Status == 0)
                        {
                            lblActive_Error.Text = "You have not actived account yet. Please go to your email to verify account!";
                            result = false;
                        }
                    }
                }                
            }            
            
            return result;
        }

        protected void btnForgetPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}