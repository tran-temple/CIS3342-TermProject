using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EcommerceLibrary;

namespace CIS3342_TermProject
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    List<CartItem> cart = (List<CartItem>)Session["Cart"];
                    lvShoppingBag.DataSource = cart;
                    lvShoppingBag.DataBind();

                    DisplaySummary();
                }
                else
                {
                    lblGeneral_Error.Text = "You have not added any item in the shopping cart!";
                }
            }

        }

        private void DisplaySummary()
        {
            double subTotal = 0.0;
            double total = 0.0;
            double taxAmount = 0.0;
            double shippingFee = 0.0;

            List<CartItem> cart = (List<CartItem>)Session["Cart"];
            foreach (CartItem item in cart)
            {
                subTotal += item.ProductPrice * item.Quantity;
            }
            if (subTotal < Constant.FREE_SHIPPING_STANDARD)
            {
                shippingFee = Constant.SHIPPING_FEE;
            }
            taxAmount = subTotal * Constant.TAX;
            total = subTotal + taxAmount + shippingFee;

            lblSubTotal.Text = subTotal.ToString("C2");
            lblTax.Text = taxAmount.ToString("C2");
            lblShippingFee.Text = shippingFee.ToString("C2");
            lblTotal.Text = total.ToString("C2");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
        
        }
    }
}