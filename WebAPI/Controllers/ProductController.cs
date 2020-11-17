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
    [Route("api/Products")]
    public class ProductController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
       public List<Product> Get()
        {
            DBConnect objDB = new DBConnect();


            // Need to write stored procedure for this.
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
    }
}

