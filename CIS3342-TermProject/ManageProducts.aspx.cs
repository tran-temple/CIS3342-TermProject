using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using EcommerceLibrary;                      // needed for the product class

namespace CIS3342_TermProject
{

    //TO DO:

       // Change GV to non auto generate, use boundfields
       // Add product button click 
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



            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.

            JavaScriptSerializer js = new JavaScriptSerializer();

            Product[] products = js.Deserialize<Product[]>(data);



            gvProducts.DataSource = products;

            gvProducts.DataBind();
        }

        protected void btnAdd_Click(Object sender, EventArgs e)
        {
        }
    }
}