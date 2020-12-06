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
                ShowCart();
            }
        }

        private void ShowCart()
        {
            ClearSummary();

            if (Session["Cart"] != null)
            {
                List<CartItem> cart = (List<CartItem>)Session["Cart"];

                lvShoppingBag.DataSource = cart;
                String[] names = new string[1];
                names[0] = "ProductID";
                lvShoppingBag.DataKeyNames = names;
                lvShoppingBag.DataBind();

                DisplaySummary();

                if (cart.Count == 0)
                {
                    lblGeneral_Error.Text = "You do not have any item in the shopping cart!";
                }
            }
            else
            {
                lblGeneral_Error.Text = "You do not have any item in the shopping cart!";
            }
        }

        private void DisplaySummary()
        {
            List<CartItem> cart = (List<CartItem>)Session["Cart"];

            if (cart.Count > 0)
            {
                double subTotal = 0.0;
                double total = 0.0;
                double taxAmount = 0.0;
                double shippingFee = 0.0;

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
                btnCheckOut.Visible = true;
            }
        }

        private void ClearSummary()
        {
            lblSubTotal.Text = "0";
            lblTax.Text = "0";
            lblShippingFee.Text = "0";
            lblTotal.Text = "0";
            btnCheckOut.Visible = false;
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOut.aspx");
        }

        protected void lvShoppingBag_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                
                int ProductId = int.Parse(lvShoppingBag.DataKeys[dataItem.DisplayIndex].Value.ToString());
                // remove item in listview
                lvShoppingBag.Items.Remove(dataItem);
                // remove item in session
                if (Session["Cart"] != null)
                {
                    List<CartItem> cart = (List<CartItem>)Session["Cart"];
                    int cartItemIndex = -1;
                    int deleteItemIndex = -1;
                    foreach (CartItem item in cart)
                    {
                        cartItemIndex++;
                        if (item.ProductID == ProductId)
                        {
                            deleteItemIndex = cartItemIndex;
                            break;
                        }
                    }
                    cart.RemoveAt(deleteItemIndex);
                }
                // update the list view
                ShowCart();                
            }
        }
    }
}