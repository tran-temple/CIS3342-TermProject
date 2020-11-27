using EcommerceLibrary;                      // needed for the product class
using System;
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Web.Script.Serialization;  // needed for JSON serializers
using System.Data;
using System.Data.SqlClient;
namespace CIS3342_TermProject
{

    //TO DO:

    // Change GV to non auto generate, use boundfields

    // Delete product
    // Edit product
    // Change product category textbox to DDL and load categories from DB

    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("https://localhost:44315/api/Products");

            WebResponse response = request.GetResponse();



            // Read the data from the Web Response, which requires working with streams.

            Stream theDataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(theDataStream);

            String data = reader.ReadToEnd();

            reader.Close();

            response.Close();



            // Deserialize a JSON string that contains an array of JSON objects into an Array of product objects.

            JavaScriptSerializer js = new JavaScriptSerializer();

            Product[] products = js.Deserialize<Product[]>(data);



            gvProducts.DataSource = products;
            //  String[] names = new string[1];
            //   names[0] = "ProductID";
            //   gvProducts.DataKeyNames = names;
            gvProducts.DataBind();
        }

        protected void btnAdd_Click(Object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCategories";

            DataSet myDS2 = objDB.GetDataSetUsingCmdObj(objCommand);
            ddlProductCategory.DataSource = myDS2;
            ddlProductCategory.DataTextField = "CategoryName";
            ddlProductCategory.DataValueField = "CategoryID";
            ddlProductCategory.DataBind();

            Product product = new Product();



            product.ProductName = txtNewProductName.Text;

            product.Description = txtNewProductDescription.Text;

            product.ProductPrice = double.Parse(txtNewProductPrice.Text);

            product.CategoryID = int.Parse(ddlProductCategory.SelectedValue);

            product.ProductQuantity = int.Parse(txtNewProductQuantity.Text);

            product.ImageURL = ImageUploadUC.uploadedImage;



            // Serialize a Customer object into a JSON string.

            JavaScriptSerializer js = new JavaScriptSerializer();

            String jsonCustomer = js.Serialize(product);



            try

            {

                // Send the Customer object to the Web API that will be used to store a new customer record in the database.

                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.

                WebRequest request = WebRequest.Create("https://localhost:44315/api/Products/AddProduct");

                request.Method = "POST";

                request.ContentLength = jsonCustomer.Length;

                request.ContentType = "application/json";



                // Write the JSON data to the Web Request

                StreamWriter writer = new StreamWriter(request.GetRequestStream());

                writer.Write(jsonCustomer);

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

                    gvProducts.DataBind();
                    Response.Redirect("ManageProducts.aspx");

                    lblDisplay.Text = "The customer was successfully saved to the database.";
                }



                else
                {

                    lblDisplay.Text = "A problem occurred while adding the customer to the database. The data wasn't recorded.";



                }
            }

            catch (Exception ex)

            {

                lblDisplay.Text = "Error: " + ex.Message;

            }

        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        protected void gvProducts_RowEditing(Object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {


        }

        protected void gvProducts_RowUpdating(Object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

        }


        protected void gvProducts_RowCommand(Object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {



        }








        protected void gvProducts_RowCancelingEdit(Object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {


        }
    }
}
