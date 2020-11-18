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
    }
}
