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
            string username = txtUsername.Text;
            User user = loginService.GetUserByUsername(username);
            int questionID = int.Parse(hidQuestionId.Value);
            string userAnswer = "";
            if (user != null)
            {
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
            }
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
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblGeneral_Error.Text = "The answer is not match!";
            }
        }

        protected void btnUserName_Click(object sender, EventArgs e)
        {
            // clear error messages before processing forgot password
            ClearErroMessages();
            string username = txtUsername.Text;
            User user = loginService.GetUserByUsername(username);
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                lblGeneral_Error.Text = "Username is not existed in the system.";
            }
            else
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
        }

        private void ClearErroMessages()
        {
            lblGeneral_Error.Text = "";
            lblAnswer_Error.Text = "";
        }
    }
}