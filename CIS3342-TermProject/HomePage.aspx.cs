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
    public partial class HomePage : System.Web.UI.Page
    {
        ProductService productService = new ProductService();
        DataSet productDS;

        //INDEX of USED columns
        private const int PRODUCTID_COLUMN = 6;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAllSubscriptions";
                DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

                if (myDS.Tables[0].Rows.Count > 0)
                {
                    DLSubscriptions.DataSource = myDS;
                    DLSubscriptions.DataBind();
                }

                //Show list categories and products
                ShowCategoriesList();
                ShowProductsList();
            }
        }

        //Show the list of categories
        private void ShowCategoriesList()
        {
            DataSet ds = productService.GetCategories();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(new ListItem() { Text = row["CategoryName"].ToString(), Value = row["CategoryID"].ToString() });
                }
            }
        }

        //Show the list of all products
        private void ShowProductsList()
        {
            productDS = productService.GetProducts();
            gvProducts.DataSource = productDS;
            gvProducts.DataBind();

            Session["productDS"] = productDS;
        }

        protected void DLSubscriptions_ItemCommand(Object sender, System.Web.UI.WebControls.DataListCommandEventArgs e)

        {

            // Retrieve the row index for the item that fired the ItemCommand event

            int rowIndex = e.Item.ItemIndex;



            // Retrieve a value from a control in the DL's Items collection

            Label myLabel = (Label)DLSubscriptions.Items[rowIndex].FindControl("lblSubscriptionID");

            String subscriptionID = myLabel.Text;



            lblSubscriptionIDShow.Text = "You selected Subscription ID " + subscriptionID;
            // WIll be used to add to cart later on

        }
               
        protected void dlSubscriptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the GridView to display the correct page
            gvProducts.PageIndex = e.NewPageIndex;
            productDS = (DataSet)Session["productDS"];
            gvProducts.DataSource = productDS;
            gvProducts.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductDetail.aspx?ProdID=" + gvProducts.SelectedRow.Cells[PRODUCTID_COLUMN].Text);
        }
    }
}