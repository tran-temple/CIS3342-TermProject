using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class ProductPage : System.Web.UI.Page
    {
        String webApiUrl = "http://localhost:8000/api/Products/";
        ProductService productService = new ProductService();
        string action;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null) action = Request.QueryString["action"];
            else Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                if (action == "add")
                {
                    lblProductHeading.Text = "Add Product";
                    ShowCategoriesList();
                }
                else
                {
                    hidProductID.Value = Request.QueryString["ProdID"];
                    LoadProductInfo(int.Parse(hidProductID.Value));
                    lblProductHeading.Text = "Modify Product";
                }
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

        //Load Product Info to modify
        private void LoadProductInfo(int id)
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
                txtProductName.Text = product.ProductName;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.ProductPrice.ToString();
                txtQuantity.Text = product.ProductQuantity.ToString();
                ImageUploadUC.uploadedImage = product.ImageURL;

                ShowCategoriesList();
                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue(product.CategoryID.ToString()).Selected = true;
            }            
        }

        //Create a product for insert or update
        private Product CreateProductObject(int id)
        {
            Product product = new Product();
            product.ProductID = id;            
            product.CategoryID = int.Parse(ddlCategory.SelectedValue);
            product.ProductName = txtProductName.Text;
            product.Description = txtDescription.Text;
            product.ProductPrice = double.Parse(txtPrice.Text);
            product.ProductQuantity = int.Parse(txtQuantity.Text);
            product.ImageURL = ImageUploadUC.uploadedImage;            

            return product;
        }

        private void ClearErrorMessage()
        {
            lblCategory_Error.Text = "";
            lblProductName_Error.Text = "";
            lblDescription_Error.Text = "";
            lblPrice_Error.Text = "";
            lblQuantity_Error.Text = "";            
        }

        //Validate the product input
        private bool ValidateProductObject()
        {
            bool result = true;
            ClearErrorMessage();

            if (ddlCategory.SelectedValue == "-1")
            {                
                lblCategory_Error.Text = "Select one category!";
                result = false;
            }
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                lblProductName_Error.Text = "Input Name!";
                result = false;                
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                lblDescription_Error.Text = "Input Description!";
                result = false;                
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                lblPrice_Error.Text = "Input Price!";
                result = false;
            }
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                lblQuantity_Error.Text = "Input Quantity!";
                result = false;
            }
            if (string.IsNullOrWhiteSpace(ImageUploadUC.uploadedImage))
            {
                lblImage_Error.Text = "Choose a image!";
                result = false;
            }
            return result;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (action == "add")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("ViewProductDetail.aspx?ProdID=" + hidProductID.Value);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Product product;

                if (action == "add")
                {                    
                    if (ValidateProductObject())
                    {
                        product = CreateProductObject(0);
                        // Serialize a Product object into a JSON string.
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        String jsonProduct = js.Serialize(product);
                        // Send the Product object to the Web API that will be used to store a new product record in the database.
                        // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                        WebRequest request = WebRequest.Create(webApiUrl + "AddProduct");
                        request.Method = "POST";
                        request.ContentLength = jsonProduct.Length;
                        request.ContentType = "application/json";
                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonProduct);
                        writer.Flush();
                        writer.Close();
                        // Read the data from the Web Response, which requires working with streams.
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();

                        reader.Close();
                        response.Close();

                        if (!data.Equals("0"))
                        {
                            hidProductID.Value = data;
                            Response.Redirect("ViewProductDetail.aspx?ProdID=" + data);
                        }
                        else
                        {
                            lblGeneral_Error.Text = "Cannot insert product!";
                        }
                    }
                }
                else
                {                    
                    if (ValidateProductObject())
                    {
                        product = CreateProductObject(int.Parse(hidProductID.Value));
                        // Serialize a Product object into a JSON string.
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        String jsonProduct = js.Serialize(product);
                        // Send the Product object to the Web API that will be used to store a new product record in the database.
                        // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                        WebRequest request = WebRequest.Create(webApiUrl + "ModifyProduct");
                        request.Method = "PUT";
                        request.ContentLength = jsonProduct.Length;
                        request.ContentType = "application/json";
                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonProduct);
                        writer.Flush();
                        writer.Close();
                        // Read the data from the Web Response, which requires working with streams.
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();

                        reader.Close();
                        response.Close();

                        if (data == "true")
                        {
                            Response.Redirect("ViewProductDetail.aspx?ProdID=" + hidProductID.Value);
                        }
                        else
                        {
                            lblGeneral_Error.Text = "Cannot update product!";
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
        }
    }
}