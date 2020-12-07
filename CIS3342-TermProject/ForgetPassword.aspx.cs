using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        LoginService loginService = new LoginService();
        Utilities utils = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // clear error messages before processing forgot password
            ClearErrorMessages();
            string username = txtUsername.Text;
            if (!String.IsNullOrWhiteSpace(username))
            {
                User user = loginService.GetUserByUsername(username);                
                string userAnswer = "";

                if (user != null)
                {
                    //Get user's sercurity answer to compare
                    GenerateSecurityQuestion(user);
                    if (!String.IsNullOrWhiteSpace(hidQuestionId.Value))
                    {
                        int questionID = int.Parse(hidQuestionId.Value);
                        if (user.QuestionID1 == questionID)
                        {
                            userAnswer = user.Answer1;
                        }
                        else if (user.QuestionID2 == questionID)
                        {
                            userAnswer = user.Answer2;
                        }
                        else if (user.QuestionID3 == questionID)
                        {
                            userAnswer = user.Answer3;
                        }
                        if (String.IsNullOrWhiteSpace(txtAnswer.Text))
                        {
                            lblAnswer_Error.Text = "Please input your security answer!";
                        }
                        else
                        {
                            //Compare user's answer
                            if (userAnswer == txtAnswer.Text)
                            {
                                string key = utils.CreateKey(user.Username);
                                // delete the verify user 
                                loginService.DeleteVerifiedUser(key);
                                // insert data to User confirmation
                                loginService.InsertVerifiedUser(user.UserID, key);
                                // send confirmation email to user     
                                string host = HttpContext.Current.Request.Url.Host;
                                int port = HttpContext.Current.Request.Url.Port;
                                string resetPasswordUrl = utils.CreateNewtPasswordUrl(host, port, key);
                                string subject = "RH Chocolate Store: Forget Password";
                                string information = "Please click on the link to reset your password! ";
                                string promotion = "";
                                utils.SendEmail(key, user.Email, subject, resetPasswordUrl, information, promotion);
                                // redirect to login page
                                //Response.Redirect("Login.aspx");
                                // show message
                                lblGeneral_Error.Text = "It is approved. Please go to your email and click on the link to reset your password!";
                            }
                            else
                            {
                                lblGeneral_Error.Text = "The answer is not match!";
                            }
                        }                        
                    }                    
                }
                else
                {
                    lblGeneral_Error.Text = "Username is not existed in the system.";
                }
            }
            else
            {
                lblUserName_Error.Text = "Please input your username!";
            }
        }

        protected void btnUserName_Click(object sender, EventArgs e)
        {
            // clear error messages before processing forgot password
            ClearErrorMessages();
            string username = txtUsername.Text;
            
            if (string.IsNullOrWhiteSpace(username))
            {
                lblUserName_Error.Text = "Please input your username!";
            }
            else
            {
                User user = loginService.GetUserByUsername(username);
                if (user != null)
                {
                    GenerateSecurityQuestion(user);
                }
                else
                {
                    lblGeneral_Error.Text = "Username is not existed in the system.";
                }
            }
        }

        //Generate Security Question by user
        private void GenerateSecurityQuestion(User user)
        {
            int[] questionIds = new int[3];
            // random question id
            questionIds[0] = user.QuestionID1;
            questionIds[1] = user.QuestionID2;
            questionIds[2] = user.QuestionID3;
            Random ran = new Random();
            int ranIndex = ran.Next() % 3;
            int ranQuestionId = questionIds[ranIndex];
            // show question for user
            Question question = loginService.GetQuestionByID(ranQuestionId);
            if (question != null && !string.IsNullOrWhiteSpace(question.QuestionDescription))
            {
                lblQuestion.Text = question.QuestionDescription;
                // put question id to the hidden field
                hidQuestionId.Value = ranQuestionId.ToString();
            }
            else
            {
                lblGeneral_Error.Text = "Can not generate the question.";
            }
        }

        private void ClearErrorMessages()
        {
            lblGeneral_Error.Text = "";
            lblUserName_Error.Text = "";
            lblAnswer_Error.Text = "";
        }
    }
}