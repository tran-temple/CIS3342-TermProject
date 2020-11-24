using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EcommerceLibrary;
using System.Collections;

using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for OrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet HelloWorld()
        {
            DBConnect objDB = new DBConnect();
           
            DataSet ds = objDB.GetDataSet("SELECT * FROM TP_Orders");
            return ds;
        }
      
       

     
    }
}
