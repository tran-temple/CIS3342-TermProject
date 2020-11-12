using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check user type!=null && username ! == null
            // Store username 

            // If user type = Admin {
            // Show admin nav, hide member & guest nav
            // Set user name lblLoggedInAs = session username
            // If user type == Member {
            // Show Member nav, hide guest & admnin nav
            // Set user name lblLoggedInAs = session username
            // If user type == Guest {
            // Show guest nav, hide member & admin nav

            // else {

            // Guest nav shown
        }
    }
}