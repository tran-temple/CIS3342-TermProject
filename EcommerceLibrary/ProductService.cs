using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EcommerceLibrary
{
    public class ProductService
    {
        DBConnect objDB = new DBConnect();

        //Get the list of categories
        public DataSet GetCategories()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCategories";

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get the list of products
        public DataSet GetProducts()
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProducts";

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Get a product by ID
        public Product GetProductByID(int id)
        {
            Product product = new Product();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProductByID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            if (resultDS.Tables.Count > 0)
            {
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    product.ProductID = int.Parse(row["ProductID"].ToString());
                    product.CategoryID = int.Parse(row["CategoryID"].ToString());
                    product.ProductName = row["ProductName"].ToString();
                    product.Description = row["ProductDescription"].ToString();
                    product.ProductPrice = double.Parse(row["ProductPrice"].ToString());
                    product.ProductQuantity = int.Parse(row["ProductQuantity"].ToString());
                    product.ImageURL = row["ProductImage"].ToString();
                }
            }
            return product;
        }

        //Get the list of Reviews of a product
        public DataSet GetReviewsByProductID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetReviewsByProductID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);
            return resultDS;
        }

        //Insert Product
        public int InsertProduct(Product product)
        {
            int id = 0;
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_InsertProduct";            
            SqlParameter outParam = new SqlParameter("@theID", product.ProductID);
            outParam.Direction = ParameterDirection.Output;
            outParam.SqlDbType = SqlDbType.Int;
            outParam.Size = 4;
            objCommand.Parameters.Add(outParam);

            ConvertProductToParams(objCommand, product);

            objDB.DoUpdateUsingCmdObj(objCommand);
            if (outParam.Value != DBNull.Value)
            {
                id = Convert.ToInt32(outParam.Value);
            }
            return id;
        }

        //Update Product
        public int UpdateProduct(Product product)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateProduct";
            ConvertProductToParams(objCommand, product);
            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Convert Product to params of DB
        private void ConvertProductToParams(SqlCommand objCommand, Product product)
        {
            //set value for input parameter
            SqlParameter inputParam;
            if (product.ProductID != 0)
            {
                inputParam = new SqlParameter("@theID", product.ProductID);
                inputParam.Direction = ParameterDirection.Input;
                inputParam.SqlDbType = SqlDbType.Int;
                inputParam.Size = 4;
                objCommand.Parameters.Add(inputParam);
            }

            objCommand.Parameters.AddWithValue("@theCategoryID", product.CategoryID);
            objCommand.Parameters.AddWithValue("@theProductName", product.ProductName);
            objCommand.Parameters.AddWithValue("@theDescription", product.Description);
            objCommand.Parameters.AddWithValue("@thePrice", product.ProductPrice);
            objCommand.Parameters.AddWithValue("@theQuantity", product.ProductQuantity);
            objCommand.Parameters.AddWithValue("@theImage", product.ImageURL);
        }

        //Delete Product
        public int DeleteProduct(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteProduct";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Insert Review
        public int InsertReview(Review review)
        {
            int id = 0;
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_InsertReview";

            SqlParameter outParam = new SqlParameter("@theID", review.ReviewID);
            outParam.Direction = ParameterDirection.Output;
            outParam.SqlDbType = SqlDbType.Int;
            outParam.Size = 4;
            objCommand.Parameters.Add(outParam);
            
            //input parameters
            objCommand.Parameters.AddWithValue("@theUserID", review.UserID);
            objCommand.Parameters.AddWithValue("@theProductID", review.ProductID);
            objCommand.Parameters.AddWithValue("@theRating", review.Rating);
            objCommand.Parameters.AddWithValue("@theComments", review.Comments);

            objDB.DoUpdateUsingCmdObj(objCommand);

            if (outParam.Value != DBNull.Value)
            {
                id = Convert.ToInt32(outParam.Value);
            }
            return id;
        }
    }
}
