using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using EcommerceLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace CIS3342_TermProject.UserControls
{
    public partial class ImageUploadUC : System.Web.UI.UserControl
    {

        public string filename;
        public string uploadedImage;

        public void Page_Load(object sender, EventArgs e)
        {

            if (FileUploadControl.HasFile)
            {

                filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);

                FileUploadControl.SaveAs(Server.MapPath("~/images") + filename);
                uploadedImage = FileUploadControl.PostedFile.FileName.ToString();
                Object file = (Server.MapPath("~/images") + filename);
                BinaryFormatter serializer = new BinaryFormatter();
                MemoryStream memStream = new MemoryStream();
                serializer.Serialize(memStream, file);
                byte[] byteArray;
                byteArray = memStream.ToArray(); 
            }

            else
            {
                uploadedImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png";
            }

            }
        }
    }

        
    
