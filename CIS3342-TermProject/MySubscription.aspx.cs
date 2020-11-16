using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;
using System.Data;
using System.Data.SqlClient;


namespace CIS3342_TermProject
{
    public partial class MySubscription : System.Web.UI.Page
    {

        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
    

        protected void Page_Load(object sender, EventArgs e)
        {

            string subID;
            panelHasSubscription.Visible = false;
            panelNoSubscription.Visible = false;
             string userid = Session["userid"].ToString();

         
            // Get username from session storage
            //  Check DB to see if they have a subscription ID under that username
            // If yes display existing subscription panel
            // If no display " You have no subscriptions, you can browse our subscriptions here" 
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSubscriptionByUserID";

            SqlParameter inputParameter = new SqlParameter("@UserID", userid);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(inputParameter);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
           
            if (myDS.Tables[0].Rows.Count > 0)
            {

                subID = ((myDS.Tables[0].Rows[0]["SubscriptionID"]).ToString());
                
                string subName = ((myDS.Tables[0].Rows[0]["SubscriptionName"]).ToString());
                string subDescription = ((myDS.Tables[0].Rows[0]["SubscriptionDescription"]).ToString());
                string subImage = ((myDS.Tables[0].Rows[0]["SubscriptionImage"]).ToString());
                string subPrice = ((myDS.Tables[0].Rows[0]["SubscriptionPrice"]).ToString());
                string subBillingTime = ((myDS.Tables[0].Rows[0]["SubscriptionBillingTime"]).ToString());

                imgSubscription.ImageUrl = subImage;
                lblSubscriptionName.Text = subName;
                lblSubscriptionDescription.Text = subDescription;
                lblSubscriptionPrice.Text = subPrice;
                lblSubscriptionBillingTime.Text = subBillingTime;
                panelHasSubscription.Visible = true;


                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUpgradeOptions";
              
                objCommand.Parameters.AddWithValue("@SubscriptionID", subID);
                DataSet myDS3 = objDB.GetDataSetUsingCmdObj(objCommand);
                ddlSubscriptionTypes.DataSource = myDS3;
                ddlSubscriptionTypes.DataTextField = "SubscriptionName";
                ddlSubscriptionTypes.DataValueField = "SubscriptionID";
                ddlSubscriptionTypes.DataBind();
            }

            else
            {
                panelHasSubscription.Visible = false;
                panelNoSubscription.Visible = true;
            }



        }

        protected void btnCancelSubscription_Click(object sender, EventArgs e)
        {
            // Popup "Are you sure you would like you cancel your current subscription?"
            // If yes {
            // Set subscription type in DB to None
            // "Your subscription has been successfully cancelled"
            // Remove image of subscription
            // Set label to " No subscription exists" 

        }

        protected void btnUpgradeSubscription_Click(object sender, EventArgs e)
        {

            // Popup "Are you sure you would like you cancel your current subscription?"
            // If yes {
            // Set subscription type in DB to upgraded subscription
            // "Your subscription has been successfully cancelled"
            // Remove image of subscription
            // Set label to new subcription type

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            int newID = int.Parse(ddlSubscriptionTypes.SelectedValue);
            string userid = Session["userid"].ToString();
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpgradeDowngrade";

            objCommand.Parameters.AddWithValue("@SubscriptionID", newID);
            objCommand.Parameters.AddWithValue("@UserID", userid);
            objDB.DoUpdateUsingCmdObj(objCommand);

            Response.Redirect("MySubscription.aspx");


        }
            

        

        protected void btnYesCancel_Click(Object sender, EventArgs e)
        {

           objCommand.Parameters.Clear();
            string userid = Session["userid"].ToString();
            int cancelled = 0;
         
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CancelSub";
            objCommand.Parameters.AddWithValue("@UserID", userid);
            objCommand.Parameters.AddWithValue("@Cancelled", cancelled);
            objDB.DoUpdateUsingCmdObj(objCommand);
            
             //   panelHasSubscription.Visible = false;
                Response.Redirect("MySubscription.aspx");

            }
        }
    }
