using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class ViewProductDetail : System.Web.UI.Page
    {
        String webApiUrl = "http://localhost:8000/api/Products/";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get product ID from URL
            int prodID = int.Parse(Request.QueryString["ProdID"]);

            if (!IsPostBack)
            {
                ShowProductDetail(prodID);
            }
        }

        //Show the Product Detail
        private void ShowProductDetail(int id)
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(webApiUrl + "GetProductByID/" + id);
            WebResponse response = request.GetResponse();

            // Read data from the Web response, which requires working with streams
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            //Deserialize a JSON string that contains a JSON object
            JavaScriptSerializer js = new JavaScriptSerializer();
            Product product = js.Deserialize<Product>(data);

            if (product != null)
            {
                int quantity = product.ProductQuantity;
                imgProduct.ImageUrl = product.ImageURL;
                lblName.Text = product.ProductName;
                lblDescription.Text = product.Description;
                lblPrice.Text = String.Format("{0:C}", product.ProductPrice);
                if (quantity > 0) lblQuantity.Text = quantity.ToString();
                else
                {
                    lblQuantity.Text = "OUT OF STOCK";
                    lblQuantity.ForeColor = Color.Red;
                    lblOutOfStock.Text = "OUT OF STOCK";
                }
                SetOperations();
                ShowReviews(id);
            }           
        }

        // calculate rating and show
        private void LoadTotalRating(List<Review> list)
        {
            float rating = 0;
            float totalRating = 0;

            if (list.Count > 0)
            {
                foreach (Review review in list) rating += review.Rating;
                totalRating = rating / list.Count;
                lblTotalRate.Text = totalRating.ToString("0.0");
            }
            else
            {
                lblTotalRate.Text = "This product doesn't have any review";
            }            
        }

        //Show the reviews list of a product
        private void ShowReviews(int id)
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(webApiUrl + "GetReviewsByProductID/" + id);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Reviews objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Review> reviews = js.Deserialize<List<Review>>(data);

            // Bind the list to the GridView to display all reviews.            
            rptReviews.DataSource = reviews;
            rptReviews.DataBind();

            //Load rating
            LoadTotalRating(reviews);
        }

        //Set Operations depending on user type
        private void SetOperations()
        {            
            switch (Session["usertype"])
            {
                case Constant.CUSTOMER:
                    btnAddReview.Visible = true;
                    btnAddToCart.Visible = true;
                    lblOutOfStock.Visible = true;
                    break;
                case Constant.OWNER:
                    btnModifyProduct.Visible = true;
                    btnDeleteProduct.Visible = true;
                    pnlQuantity.Visible = true;
                    break;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddReview_Click(object sender, EventArgs e)
        {

        }

        protected void btnModifyProduct_Click(object sender, EventArgs e)
        {
            //Get product ID from URL
            int prodID = int.Parse(Request.QueryString["ProdID"]);
            Response.Redirect("ProductPage.aspx?ProdID=" + prodID + "&action=modify");
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            //Get product ID from URL
            int prodID = int.Parse(Request.QueryString["ProdID"]);

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(webApiUrl + "DeleteProduct/" + prodID);
            request.Method = "DELETE";
            WebResponse response = request.GetResponse();

            // Read data from the Web response, which requires working with streams
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            if (data == "true")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblGeneral_Error.Text = "Cannot delete product!";
            }            
        }
    }
}