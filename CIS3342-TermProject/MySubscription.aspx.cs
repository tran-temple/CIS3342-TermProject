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
            //prevent bypass
            if (Session["usertype"] != null && Session["usertype"].ToString() == Constant.CUSTOMER)
            {
                //do nothing
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                string userid2 = Session["userid"].ToString();
                int userID2 = int.Parse(userid2);


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_CheckSubscriptionExists";
                objCommand.Parameters.AddWithValue("@UserID", userID2);

                DataSet myDS2 = objDB.GetDataSetUsingCmdObj(objCommand);


                if (myDS2.Tables[0].Rows.Count == 0)
                {
                    panelHasSubscription.Visible = false;
                    panelNoSubscription.Visible = true;

                }

                else {

                    objCommand.Parameters.Clear();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_CheckSubscription";
                    objCommand.Parameters.AddWithValue("@UserID", userID2);

                    DataSet myDS3 = objDB.GetDataSetUsingCmdObj(objCommand);


                    if (myDS3.Tables[0].Rows.Count > 0)
                    {
                        panelHasSubscription.Visible = false;
                        panelNoSubscription.Visible = true;

                    }

                    else
                    {




                        objCommand.Parameters.Clear();
                        string subID;
                        panelHasSubscription.Visible = false;
                        panelNoSubscription.Visible = false;
                        string userid = Session["userid"].ToString();
                        int userID = int.Parse(userid);

                        // Get username from session storage
                        //  Check DB to see if they have a subscription ID under that username
                        // If yes display existing subscription panel
                        // If no display " You have no subscriptions, you can browse our subscriptions here" 
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_GetSubscriptionByUserID";
                        objCommand.Parameters.AddWithValue("@UserID", userID);

                        DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);


                        if (myDS.Tables[0].Rows.Count > 0)
                        {
                            subID = ((myDS.Tables[0].Rows[0]["SubscriptionID"]).ToString());

                            string subName = ((myDS.Tables[0].Rows[0]["SubscriptionName"]).ToString());
                            string subDescription = ((myDS.Tables[0].Rows[0]["SubscriptionDescription"]).ToString());
                            string subImage = ((myDS.Tables[0].Rows[0]["SubscriptionImage"]).ToString());
                            string subPrice = ((myDS.Tables[0].Rows[0]["SubscriptionPrice"]).ToString());
                            string subBillingTime = ((myDS.Tables[0].Rows[0]["SubscriptionBillingTime"]).ToString());
                            string dbUserID = ((myDS.Tables[0].Rows[0]["UserID"]).ToString());



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
                            DataSet myDS4 = objDB.GetDataSetUsingCmdObj(objCommand);
                            ddlSubscriptionTypes.DataSource = myDS4;
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

            }



            }
        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {

                ddlSubscriptionTypes.DataBind();
                int newID = int.Parse(ddlSubscriptionTypes.SelectedValue);
                string userid = Session["userid"].ToString();
                objCommand.Parameters.Clear();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpgradeDowngrade";

                objCommand.Parameters.AddWithValue("@SubscriptionID", newID);
                objCommand.Parameters.AddWithValue("@UserID", userid);
                objDB.DoUpdateUsingCmdObj(objCommand);


                ddlSubscriptionTypes.DataBind();

                Response.Redirect("MySubscription.aspx");


            
        }
            

        

        protected void btnYesCancel_Click(Object sender, EventArgs e)
        {
          
                objCommand.Parameters.Clear();
                string userid = Session["userid"].ToString();

                int userID = int.Parse(userid);


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_CancelSubscription";
                objCommand.Parameters.AddWithValue("@UserID", userID);

                objDB.DoUpdateUsingCmdObj(objCommand);

                  panelHasSubscription.Visible = false;
            panelNoSubscription.Visible = true;
                
            }
            
        }
    }
