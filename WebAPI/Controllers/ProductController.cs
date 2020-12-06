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
        [HttpPost()]                // POST api/Products/
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

        // This method receives a product id to delete that product from database
        [HttpDelete("DeleteProduct/{id}")]  // PUT api/Products/DeleteProduct/
        public Boolean DeleteProduct(int id)
        {
            int retVal = productService.DeleteProduct(id);
            if (retVal > 0)
                return true;
            else
                return false;           
        }

    }
}

