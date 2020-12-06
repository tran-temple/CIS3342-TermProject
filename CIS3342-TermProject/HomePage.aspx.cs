using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceLibrary;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CIS3342_TermProject
{
    public partial class HomePage : System.Web.UI.Page
    {
        ProductService productService = new ProductService();
        DataSet productDS;

        //INDEX of USED columns
        private const int PRODUCT_ID_COLUMN = 6;
        private const int PRODUCT_IMG_COLUMN = 0;
        private const int PRODUCT_NAME_COLUMN = 1;
        private const int PRODUCT_PRICE_COLUMN = 2;
        private const int PRODUCT_QUANTITY_COLUMN = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Show subscriptions
                ShowSubscriptions();

                //Show list categories and products
                ShowCategoriesList();
                ShowProductsList();
            }
        }
        
        //Show subscriptions
        private void ShowSubscriptions()
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

            Label lblSubscriptionID = (Label)DLSubscriptions.Items[rowIndex].FindControl("lblSubID");

            String subscriptionID = lblSubscriptionID.Text;


            Label lblSubscriptionName = (Label)DLSubscriptions.Items[rowIndex].FindControl("lblSubName");

            String subscriptionName = lblSubscriptionName.Text;

            Label lblSubscriptionPrice = (Label)DLSubscriptions.Items[rowIndex].FindControl("lblSubPrice");

            Double subscriptionPrice = Double.Parse(lblSubscriptionPrice.Text);


            //     lblSubscriptionIDShow.Text = "You selected Subscription ID " + subscriptionID;


            // WIll be used to add to cart later on

            List<CartItem> cart = null;

            CartItem item = new CartItem();

            item.ProductID = int.Parse(subscriptionID);
            item.ProductName = subscriptionName;
            Image img = (Image)DLSubscriptions.Items[rowIndex].FindControl("subImage");
            item.ImageURL = img.ImageUrl;
            item.ProductPrice = subscriptionPrice;
            item.Type = "Subscription";

            item.Quantity = 1;

            if (Session["Cart"] != null)
            {

                cart = (List<CartItem>)Session["Cart"];
                for (int i = 0; i < cart.Count; i++)

                {
                    if (cart[i].Type == "Subscription") // If the cart already has a subscription in it
                    {
                        cart.RemoveAt(i);
                        cart.Add(item);
                        break;
                        // Response.Write("<script>alert(' You have already selected a subscription type. You must remove it from the cart to add another.')</script>"); // Alert 

                    }

                    else
                    {
                        cart.Add(item);
                    }
                }
            }
            else
            {
                cart = new List<CartItem>();
                cart.Add(item);
                Session["Cart"] = cart;
            }
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
            string searchText = txtSearch.Text;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SearchByText";
            objCommand.Parameters.AddWithValue("@SearchText", searchText);
            DataSet myDS4 = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS4.Tables[0].Rows.Count > 0)
            {
                gvProducts.DataSource = myDS4;
                gvProducts.DataBind();


            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categorySelected = ddlCategory.SelectedValue;

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SearchByCategory";
            objCommand.Parameters.AddWithValue("@CategorySelected", categorySelected);
            DataSet myDS3 = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS3.Tables[0].Rows.Count > 0)
            {
                gvProducts.DataSource = myDS3;
                gvProducts.DataBind();

            }
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ViewProductDetail.aspx?ProdID=" + gvProducts.SelectedRow.Cells[PRODUCT_ID_COLUMN].Text);
        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                //Proceed to adding item to cart
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvProducts.Rows[index];
                List<CartItem> cart = null;

                CartItem item = new CartItem();
                item.ProductID = int.Parse(row.Cells[PRODUCT_ID_COLUMN].Text);
                item.ProductName = row.Cells[PRODUCT_NAME_COLUMN].Text;
                Image img = (Image)row.FindControl("imgRestaurant");
                item.ImageURL = img.ImageUrl;
                item.ProductPrice = double.Parse(row.Cells[PRODUCT_PRICE_COLUMN].Text, NumberStyles.Currency);
                TextBox txtBox = (TextBox)row.FindControl("txtQuantity");
                item.Quantity = int.Parse(txtBox.Text);
                item.Type = "Product";

                if (Session["Cart"] != null)
                {
                    cart = (List<CartItem>)Session["Cart"];
                }
                else
                {
                    cart = new List<CartItem>();
                    Session["Cart"] = cart;
                }
                // check item inside cart
                bool isItemExistedInCart = false;
                foreach (CartItem cartItem in cart)
                {
                    if (cartItem.ProductID == item.ProductID)
                    {
                        // inscrease the quantity only
                        cartItem.Quantity = cartItem.Quantity + item.Quantity;
                        isItemExistedInCart = true;
                        break;
                    }
                }
                // item is not existed in cart
                if (!isItemExistedInCart)
                {
                    // add new item to cart
                    cart.Add(item);
                }
            }
        }

        protected bool CustomerLogin()
        {
            if (Session["usertype"].ToString() == Constant.CUSTOMER)
            {
                return true;
            }
            return false;
        }

    }
}