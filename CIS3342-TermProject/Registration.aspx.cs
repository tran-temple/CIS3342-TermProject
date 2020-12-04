using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        LoginService loginService = new LoginService();
        Utilities utils = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowQuestionsList();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                User objUser = CreateUserObject();
                if (ValidateUserObject(objUser))
                {
                    // encode the password
                    string encryptPassword = utils.EncryptSensitiveInfo(txtPassword.Text);
                    objUser.Password = encryptPassword;
                    // write user to database
                    int ret = loginService.InsertUser(objUser);

                    if (ret == 1)
                    {
                        User createdUser = loginService.GetUserByUsername(objUser.Username);
                        // insert data to User confirmation
                        string key = utils.CreateKey(createdUser.Username);
                        loginService.InsertVerifiedUser(createdUser.UserID, key);
                        // send confirmation email to user     
                        string host = HttpContext.Current.Request.Url.Host;
                        int port = HttpContext.Current.Request.Url.Port;
                        string confirmUrl = utils.CreateConfirmUrl(host, port, key);
                        string subject = "RH Chocolate Store: Activate";
                        string information = "Please click on the link to verify your email and activate your account! ";
                        //string promotion = "Enter coupon code NEW15 for 15% off your first order!";
                        string promotion = "";
                        utils.SendEmail(key, createdUser.Email, subject, confirmUrl, information, promotion);
                        // redirect to login page
                        Response.Redirect("Login.aspx");
                    } 
                    else lblGeneral_Error.Text = "Cannot create user!";                    
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
        }

        private void ClearErrorMessage()
        {
            lblGeneral_Error.Text = "";
            lblUserName_Error.Text = "";
            lblPassword_Error.Text = "";
            lblFirstName_Error.Text = "";
            lblLastName_Error.Text = "";
            lblEmail_Error.Text = "";
            lblUserType_Error.Text = "";
            lblAddress_Error.Text = "";
            lblCity_Error.Text = "";
            lblState_Error.Text = "";
            lblZipcode_Error.Text = "";
            lblPhone_Error.Text = "";
            lblQuestion1_Error.Text = "";
            lblAnswer1_Error.Text = "";
            lblQuestion2_Error.Text = "";
            lblAnswer2_Error.Text = "";
            lblQuestion3_Error.Text = "";
            lblAnswer3_Error.Text = "";
        }

        //Create the user object to use
        private User CreateUserObject()
        {            
            string type = "";

            User user = new User();
            user.Username = txtUsername.Text;
            if (!String.IsNullOrWhiteSpace(txtPassword.Text))
            { 
                user.Password = txtPassword.Text;
            }               
            user.Firstname = txtFirstName.Text;
            user.Lastname = txtLastName.Text;
            user.Email = txtEmail.Text;
            if (rdoCustomer.Checked) type = Constant.CUSTOMER;            
            else if (rdoOwner.Checked) type = Constant.OWNER;            
            user.UserType = type;
            user.Street = txtAddress.Text;
            user.City = txtCity.Text;
            user.State = ddlState.SelectedValue;
            user.Zipcode = txtZipcode.Text;
            user.Phone = txtPhone.Text;
            user.QuestionID1 = int.Parse(ddlQuestion1.SelectedValue);
            user.Answer1 = txtAnswer1.Text;
            user.QuestionID2 = int.Parse(ddlQuestion2.SelectedValue);
            user.Answer2 = txtAnswer2.Text;
            user.QuestionID3 = int.Parse(ddlQuestion3.SelectedValue);
            user.Answer3 = txtAnswer3.Text;

            return user;
        }

        //Valid the input user info
        private bool ValidateUserObject(User user)
        {
            ClearErrorMessage();
            bool result = true;

            //Verify username
            if (String.IsNullOrWhiteSpace(user.Username))
            {
                lblUserName_Error.Text = "Please input username!";
                result = false;
            }
            else
            {
                User objUser = loginService.GetUserByUsername(user.Username);
                if (!string.IsNullOrWhiteSpace(objUser.Username))
                {
                    lblUserName_Error.Text = "Username existed!";
                    result = false;
                }
            }
            //Verify password
            if (String.IsNullOrWhiteSpace(user.Password))
            {
                lblPassword_Error.Text = "Please input Password!";
                result = false;
            }
            else
            {
                if (!utils.IsValidPassword(user.Password))
                {
                    lblPassword_Error.Text = "Password requirements:  must be eight characters or longer, "
                        + "must contain at least 1 lowercase alphabetical character, "
                        + "must contain at least 1 uppercase alphabetical character, "
                        + "must contain at least 1 numeric character, "
                        + "must contain at least one special character.";
                    result = false;
                }
            }
            //Verify name
            if (String.IsNullOrWhiteSpace(user.Firstname))
            {
                lblFirstName_Error.Text = "Please input First Name!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.Lastname))
            {
                lblLastName_Error.Text = "Please input Last Name!";
                result = false;
            }
            //Verify email address
            if (String.IsNullOrWhiteSpace(user.Email))
            {
                lblEmail_Error.Text = "Please input Email!";
                result = false;
            }
            else
            {
                if (!utils.IsValidEmail(user.Email))
                {
                    lblEmail_Error.Text = "Please input a valid email address!";
                    result = false;
                }
            }
            //Verify usertype
            if (String.IsNullOrWhiteSpace(user.UserType))
            {
                lblUserType_Error.Text = "Please select User Type!";
                result = false;
            }
            //Verify selecting security questions and answers
            if (user.QuestionID1.Equals(-1))
            {
                lblQuestion1_Error.Text = "Please select Question 1!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.Answer1))
            {
                lblAnswer1_Error.Text = "Please input Answer 1!";
                result = false;
            }
            if (user.QuestionID2.Equals(-1))
            {
                lblQuestion2_Error.Text = "Please select Question 2!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.Answer2))
            {
                lblAnswer2_Error.Text = "Please input Answer 2!";
                result = false;
            }
            if (user.QuestionID3.Equals(-1))
            {
                lblQuestion3_Error.Text = "Please select Question 3!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.Answer3))
            {
                lblAnswer3_Error.Text = "Please input Answer 3!";
                result = false;
            }
            //Verify full address
            if (String.IsNullOrWhiteSpace(user.Street))
            {
                lblAddress_Error.Text = "Please input Address!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.City))
            {
                lblCity_Error.Text = "Please input City!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.State))
            {
                lblState_Error.Text = "Please select State!";
                result = false;
            }
            if (String.IsNullOrWhiteSpace(user.Zipcode))
            {
                lblZipcode_Error.Text = "Please input Zipcode!";
                result = false;
            }
            else
            {
                if (!utils.IsValidZipCode(user.Zipcode))
                {
                    lblZipcode_Error.Text = "Please input valid Zipcode!";
                    result = false;
                }
            }
            //Verify phone if has input
            if (String.IsNullOrWhiteSpace(user.Phone))
            {
                lblPhone_Error.Text = "Please input Phone!";
                result = false;
            }
            else
            {
                if (!utils.IsValidPhone(user.Phone))
                {
                    lblPhone_Error.Text = "Please input valid Phone: xxx-xxx-xxxx!";
                    result = false;
                }
            }
            return result;
        }

        //Show the list of questions
        private void ShowQuestionsList()
        {
            DataSet ds = loginService.GetQuestions();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ddlQuestion1.Items.Add(new ListItem() { Text = row["QuestionDescription"].ToString(), Value = row["QuestionID"].ToString() });
                    ddlQuestion2.Items.Add(new ListItem() { Text = row["QuestionDescription"].ToString(), Value = row["QuestionID"].ToString() });
                    ddlQuestion3.Items.Add(new ListItem() { Text = row["QuestionDescription"].ToString(), Value = row["QuestionID"].ToString() });
                }
            }
        }

        
    }
}