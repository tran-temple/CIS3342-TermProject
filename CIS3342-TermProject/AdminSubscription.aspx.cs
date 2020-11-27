using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EcommerceLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CIS3342_TermProject
{
    public partial class AdminSubscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // make sure the user is an ADMIN and not a member.
            // get user type from session obj
            // if user type == amdin { 
            // else {  " you do not have access to this page"
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAllSubscriptions";
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                gvSubscriptions.DataSource = myDS;
                String[] names = new string[1];
                names[0] = "SubscriptionID";
                gvSubscriptions.DataKeyNames = names;
                gvSubscriptions.DataBind();
            }

        }



        protected void gvSubscriptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvSubscriptions_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvSubscriptions.EditIndex = e.NewEditIndex;
            gvSubscriptions.DataBind();

        }

        protected void gvSubscriptions_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

            int rowIndex = e.RowIndex;
            string selectedSubID = gvSubscriptions.DataKeys[rowIndex].Value.ToString();
            string newImage;
            FileUpload FileUpload2 = (FileUpload)gvSubscriptions.Rows[e.RowIndex].FindControl("FileUploadControl2");
            if (FileUpload2.HasFile)
            {

                string filename2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                FileUpload2.SaveAs(Server.MapPath("~/") + filename2);

                Object file = (Server.MapPath("~/ ") + filename2);
                BinaryFormatter serializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream();
                serializer.Serialize(memStream, file);
                byte[] byteArray;
                byteArray = memStream.ToArray();
                lblError.Text = byteArray.ToString();
                newImage = FileUpload2.PostedFile.FileName.ToString();
            }


            else
            {
                newImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png";
            }



            // use previous user image if new image is not changed    



            TextBox TboxSubscriptionName;
            TboxSubscriptionName = (TextBox)gvSubscriptions.Rows[rowIndex].Cells[3].Controls[0];


            if (TboxSubscriptionName.Text == "")
            {
                lblError.Text = "Please enter a valid subscription name..";
            }
            else if (TboxSubscriptionName.Text != "")
            {
                lblError.Text = "";
            }

            TextBox TboxSubscriptionPrice;
            TboxSubscriptionPrice = (TextBox)gvSubscriptions.Rows[rowIndex].Cells[4].Controls[0];

            if (TboxSubscriptionPrice.Text == "")
            {
                lblError.Text = " Please enter a valid subscription price..";

            }

            else if (TboxSubscriptionPrice.Text != "")
            {
                lblError.Text = "";
            }

            TextBox TboxSubscriptionBillingTime;
            TboxSubscriptionBillingTime = (TextBox)gvSubscriptions.Rows[rowIndex].Cells[5].Controls[0];

            if (TboxSubscriptionBillingTime.Text == "")
            {
                lblError.Text = " Please enter a valid billing time";


            }

            else if (TboxSubscriptionBillingTime.Text != "")
            {
                lblError.Text = "";
            }

            TextBox TboxSubscriptionDescription;
            TboxSubscriptionDescription = (TextBox)gvSubscriptions.Rows[rowIndex].Cells[6].Controls[0];

            if (TboxSubscriptionDescription.Text == "")
            {
                lblError.Text = " Please enter a valid subscription description";


            }

            else if (TboxSubscriptionDescription.Text != "")
            {
                lblError.Text = "";
            }

            if (lblError.Text == "")
            {

                string newName = TboxSubscriptionName.Text;
                string newDescription = TboxSubscriptionDescription.Text;
                string newPrice = TboxSubscriptionPrice.Text;
                string newBilling = TboxSubscriptionBillingTime.Text;



                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_EditSubscription";
                objCommand.Parameters.AddWithValue("@SubscriptionID", selectedSubID);
                objCommand.Parameters.AddWithValue("@NewName", newName);
                objCommand.Parameters.AddWithValue("@NewDescription", newDescription);
                objCommand.Parameters.AddWithValue("@NewPrice", newPrice);
                objCommand.Parameters.AddWithValue("@NewBilling", newBilling);
                objCommand.Parameters.AddWithValue("@NewImage", newImage);


                objDB.DoUpdateUsingCmdObj(objCommand);

                gvSubscriptions.EditIndex = -1;
                gvSubscriptions.DataBind();
                Response.Redirect("AdminSubscription.aspx");

            }

            else
            {
                lblError.Text = "Please enter valid info";
            }
        }


        protected void gvSubscriptions_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string selectedSubID = gvSubscriptions.DataKeys[rowIndex].Value.ToString();

            if (e.CommandName == "Select")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteSubscription";

                objCommand.Parameters.AddWithValue("@SubscriptionID", selectedSubID);

                objDB.DoUpdateUsingCmdObj(objCommand);
                gvSubscriptions.DataBind();
                Response.Write("<script>alert('The subscription with subscription id" + selectedSubID + " has succesfully been deleted.')</script>");
                Response.Redirect("AdminSubscription.aspx");

            }
        }








        protected void gvSubscriptions_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvSubscriptions.EditIndex = -1;
            gvSubscriptions.DataBind();

        }



        protected void btnAdd_Click(Object sender, EventArgs e)
        {


            // Add validation here
            if (txtNewSubscriptionName.Text == "" || txtNewSubscriptionDescription.Text == "" || txtNewSubscriptionPrice.Text == "")
            {
                Response.Write("<script>alert('One or more fields were left blank. Please enter all fields and try again')</script>");
                lblFormError.Text = " One or more fields were left blank. Please enter all fields and try again.";

            }


            else if (lblFormError.Text == "")
            {
                string NewSubscriptionImage = ImageUploadUC.uploadedImage;
                string NewSubscriptionName = txtNewSubscriptionName.Text;
                string NewSubscriptionDescription = txtNewSubscriptionDescription.Text;
                string NewSubscriptionPrice = txtNewSubscriptionPrice.Text;
                string NewSubscriptionBillingTime = ddlBilling.SelectedValue;


                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Parameters.Clear();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddNewSubscription";

                objCommand.Parameters.AddWithValue("@NewSubscriptionImage", NewSubscriptionImage);
                objCommand.Parameters.AddWithValue("@NewSubscriptionName", NewSubscriptionName);
                objCommand.Parameters.AddWithValue("@NewSubscriptionDescription", NewSubscriptionDescription);
                objCommand.Parameters.AddWithValue("@NewSubscriptionPrice", NewSubscriptionPrice);
                objCommand.Parameters.AddWithValue("@NewSubscriptionBilling", NewSubscriptionBillingTime);


                objDB.DoUpdateUsingCmdObj(objCommand);

                gvSubscriptions.DataBind();

                Response.Redirect("AdminSubscription.aspx");



            }



        }


    }
}