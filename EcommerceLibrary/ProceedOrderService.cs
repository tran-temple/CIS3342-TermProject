using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream

namespace EcommerceLibrary
{
    public class ProceedOrderService
    {
        DBConnect objDB = new DBConnect();

        //Get Credit Card Info of User
        public CreditCard GetCreditCardInfoByUserID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetCreditCardInfoByUserID";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;

            objCommand.Parameters.Add(inputParam);
            DataSet resultDS = objDB.GetDataSetUsingCmdObj(objCommand);

            CreditCard creditCard = null;

            if (resultDS.Tables.Count > 0)
            {                
                foreach (DataRow row in resultDS.Tables[0].Rows)
                {
                    // De-serialize the binary data to reconstruct the CreditCard object retrieved
                    // from the database
                    if (row["CreditCardInfo"] != DBNull.Value)
                    {
                        creditCard = new CreditCard();
                        Byte[] byteArray = (Byte[])row["CreditCardInfo"];

                        BinaryFormatter deSerializer = new BinaryFormatter();
                        MemoryStream memStream = new MemoryStream(byteArray);

                        creditCard = (CreditCard)deSerializer.Deserialize(memStream);
                    }                    
                }
            }
            return creditCard;
        }

        //Store Credit Card Info of User
        public int StoreCreditCardInfoByUserID(int id, CreditCard creditCard)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_StoreCreditCardInfo";

            //set value for input parameter
            SqlParameter inputParam = new SqlParameter("@theID", id);
            inputParam.Direction = ParameterDirection.Input;
            inputParam.SqlDbType = SqlDbType.Int;
            inputParam.Size = 4;
            objCommand.Parameters.Add(inputParam);

            // Serialize the CreditCard object
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] byteArray;
            serializer.Serialize(memStream, creditCard);
            byteArray = memStream.ToArray();

            // Update the account to store the serialized object (binary data) in the database
            objCommand.Parameters.AddWithValue("@theCreditCard", byteArray);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Insert Order and Order Items
        public Boolean InsertFullOrder(Order order, List<OrderItem> items)
        {
            Boolean result = false;
            int id = 0;
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_InsertOrder";

            SqlParameter outParam = new SqlParameter("@theID", order.OrderID);
            outParam.Direction = ParameterDirection.Output;
            outParam.SqlDbType = SqlDbType.Int;
            outParam.Size = 4;
            objCommand.Parameters.Add(outParam);

            //input parameters
            objCommand.Parameters.AddWithValue("@theUserID", order.UserID);
            objCommand.Parameters.AddWithValue("@theShippingAddress", order.ShippingAddress);
            objCommand.Parameters.AddWithValue("@theTotal", order.OrderTotal);
            objCommand.Parameters.AddWithValue("@thePaymentMethod", order.PaymentMethod);

            objDB.DoUpdateUsingCmdObj(objCommand);

            if (outParam.Value != DBNull.Value)
            {
                id = Convert.ToInt32(outParam.Value);
                int totalItems = 0;

                foreach (OrderItem item in items)
                {
                    item.OrderID = id;
                    int retValue = InsertOrderItem(item);
                    if (retValue > 0)
                    {
                        UpdateQuantityByProductID(item.ProductID, item.ItemQuantity);
                        totalItems++;
                    }                
                }
                if (totalItems == items.Count)
                {
                    result = true;
                }
                else
                {
                    DeleteOrderItemByOrderID(id);
                    DeleteOrderByID(id);
                }
            }
            return result;
        }

        //Insert An Order Item
        public int InsertOrderItem(OrderItem item)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_InsertOrderItem";

            //input parameters
            objCommand.Parameters.AddWithValue("@theOrderID", item.OrderID);
            objCommand.Parameters.AddWithValue("@theProductID", item.ProductID);
            objCommand.Parameters.AddWithValue("@thePrice", item.ItemPrice);
            objCommand.Parameters.AddWithValue("@theQuantity", item.ItemQuantity);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Update Quantity By Product ID
        public int UpdateQuantityByProductID(int id, int quantity)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateQuantityProduct";

            //input parameters
            objCommand.Parameters.AddWithValue("@theID", id);
            objCommand.Parameters.AddWithValue("@theQuantity", quantity);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Delete Order
        public int DeleteOrderByID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteOrder";

            //input parameters
            objCommand.Parameters.AddWithValue("@theID", id);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }

        //Delete Order Items By OrderID
        public int DeleteOrderItemByOrderID(int id)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteOrderItemByOrderID";

            //input parameters
            objCommand.Parameters.AddWithValue("@theID", id);

            return objDB.DoUpdateUsingCmdObj(objCommand);
        }
    }
}

