using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using EcommerceLibrary;
using Newtonsoft.Json.Serialization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();

        /*// GET: api/<controller>
        [HttpGet]
       public List<Product> Get()
        {
            DBConnect objDB = new DBConnect();


            // Need to use stored procedure for this.
            DataSet ds = objDB.GetDataSet("SELECT * FROM TP_Products");

            List<Product> products = new List<Product>();

            Product product;
            
            foreach (DataRow record in ds.Tables[0].Rows)

            {

                product = new Product();
                product.ProductID = int.Parse(record["ProductID"].ToString());
                product.ProductName = record["ProductName"].ToString();
                product.CategoryID = int.Parse(record["CategoryID"].ToString());
                product.Description = record["ProductDescription"].ToString();
                product.ProductPrice = double.Parse(record["ProductPrice"].ToString());
                product.ProductQuantity = int.Parse(record["ProductQuantity"].ToString());
                product.ImageURL = record["ProductImage"].ToString();

              

                products.Add(product);

            }



            return products;

        }

        [HttpPost()]              

        [HttpPost("AddProduct")]   // POST api/AddProduct/

        public Boolean AddCustomer([FromBody]Product product)

        {

            if (product != null)

            {

                DBConnect objDB = new DBConnect();

                SqlCommand objCommand = new SqlCommand();



                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.CommandText = "TP_AddNewProduct";



                objCommand.Parameters.AddWithValue("@newProductName", product.ProductName);

                objCommand.Parameters.AddWithValue("@newProductDescription", product.Description);

                objCommand.Parameters.AddWithValue("@newProductCategoryID", product.CategoryID);

                objCommand.Parameters.AddWithValue("@newProductPrice", product.ProductPrice);

                objCommand.Parameters.AddWithValue("@newProductQuantity", product.ProductQuantity);

                objCommand.Parameters.AddWithValue("@newProductImage", product.ImageURL);

              



                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);



                if (retVal > 0)

                    return true;

                else

                    return false;

            }

            else

            {

                return false;

            }

        }*/

        // This method receives an id for a product and returns a product object with the field values from the database record.    
        [HttpGet("GetProductByID/{id}")]  // GET api/Products/GetProductByID/
        public Product GetProductByID(int id)
        {
            Product product = null;
            product = productService.GetProductByID(id);
            return product;
        }

        // This method receives a product id to get reviews of a product from the database records
        [HttpGet("GetReviewsByProductID/{id}")]  // GET api/Products/GetReviewsByProductID/
        public List<Review> GetReviewsByProductID(int id)
        {
            List<Review> reviewList = new List<Review>();
            DataSet resultDS = productService.GetReviewsByProductID(id);

            int count = resultDS.Tables[0].Rows.Count;
            if (count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    Review review = new Review();
                    review.ReviewID = int.Parse(row["ReviewID"].ToString());
                    review.UserID = int.Parse(row["UserID"].ToString());
                    review.ProductID = int.Parse(row["ProductID"].ToString());
                    review.Rating = int.Parse(row["Rating"].ToString());
                    review.Comments = row["Comments"].ToString();
                    review.ReviewDate = DateTime.Parse(row["ReviewDate"].ToString());
                    reviewList.Add(review);
                }
            }
            return reviewList;
        }

        // This method receives a product to insert that product into database records
        [HttpPost("AddProduct")]   // POST api/Products/AddProduct/
        public int AddProduct([FromBody]Product product)
        {
            int productID = 0;
            if (product != null)
            {
                productID = productService.InsertProduct(product);
            }            
            return productID;
        }

        // This method receives a product to update that product into database records
        [HttpPut("ModifyProduct")]  // PUT api/Products/ModifyProduct/
        public Boolean ModifyProduct([FromBody]Product product)
        {
            if (product != null)
            {
                int retVal = productService.UpdateProduct(product);
                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }                
        }

        /* sample -----------------------
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        -----------------------------------------------*/
    }
}

