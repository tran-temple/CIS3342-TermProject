using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class MySubscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check session storage & make sure user type is member
            // If user type is member then get their username 
            // If user type is member then check to see if they have a subscription from DB 
            // If they have a subscription then Cancel Subscription button is not hidden
            // If they have a subscription and its != highest type of subscription then Upgrade button is not hidden
            // else if {
            // they have no subcription then cancel subscription  button and upgrade are hidden and only add new is shown 
        }

        protected void btnCancelSubscription_Click(object sender, EventArgs e)
        {
            // Popup "Are you sure you would like you cancel your current subscription?"
            // If yes {
            // Set subscription type in DB to None
            // "Your subscription has been successfully cancelled"
            // Remove image of subscription
            // Set label to " No subscription exists" 

        }

        protected void btnUpgradeSubscription_Click(object sender, EventArgs e)
        {

            // Popup "Are you sure you would like you cancel your current subscription?"
            // If yes {
            // Set subscription type in DB to upgraded subscription
            // "Your subscription has been successfully cancelled"
            // Remove image of subscription
            // Set label to new subcription type

        }

        protected void btnAddSubscription_Click(object sender, EventArgs e)
        {
            // Select subscription type and add it to the users cart 
        }
    }
}