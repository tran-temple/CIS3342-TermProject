using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;
using EcommerceLibrary;
using System.Data;

namespace CIS3342_TermProject
{
    public partial class CheckOut : System.Web.UI.Page
    {
        ProceedOrderService service = new ProceedOrderService();
        LoginService loginService = new LoginService();
        Utilities utils = new Utilities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    List<CartItem> cart = (List<CartItem>)Session["Cart"];
                    lvShoppingBag.DataSource = cart;
                    lvShoppingBag.DataBind();

                    //Show info
                    DisplaySummary();
                    string userName = Session["username"].ToString();
                    int userID = int.Parse(Session["userid"].ToString());
                    ShowCustomerInfo(userName);
                    ShowCreditCardInfo(userID);                    
                }
                else
                {
                    lblGeneral_Error.Text = "You have not added any items to the shopping cart!";
                }
            }
        }

        //Create Order to insert
        private Order CreateOrder()
        {
            Order order = new Order();
            order.UserID = int.Parse(Session["userid"].ToString());
            string shippingAddress = txtAddress.Text + ", " + txtCity.Text + ", " +
                ddlState.SelectedValue + " " + txtZipcode.Text;
            order.ShippingAddress = shippingAddress;
            order.OrderTotal = double.Parse(lblTotal.Text, NumberStyles.Currency);
            order.PaymentMethod = ddlCardType.SelectedValue;

            return order;
        }

        //Create the order items list to insert
        private List<OrderItem> CreateOrderItemList()
        {
            List<OrderItem> items = new List<OrderItem>();
            List<CartItem> cart = (List<CartItem>)Session["Cart"];

            foreach (CartItem cartItem in cart)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.ProductID = cartItem.ProductID;
                orderItem.ItemPrice = cartItem.ProductPrice;
                orderItem.ItemQuantity = cartItem.Quantity;
                items.Add(orderItem);
            }
            return items;
        }

        //Create Credit Card to store
        private CreditCard CreateCreditCard()
        {
            CreditCard creditCard = new CreditCard();
            creditCard.CardNumber = utils.Decrypt(hidCardNumber.Value);
            creditCard.CardType = ddlCardType.SelectedValue;
            creditCard.ExpirationMonth = int.Parse(ddlMonth.SelectedValue);
            creditCard.ExpirationYear = int.Parse(ddlYear.SelectedValue);

            return creditCard;
        }

        //Calculate Order and display
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

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = CreateOrder();
                List<OrderItem> items = CreateOrderItemList();
                if (order != null && items.Count > 0)
                {
                    Boolean result = service.InsertFullOrder(order, items);
                    List<CartItem> cart = (List<CartItem>)Session["Cart"];
                    
                    if (chkStoreCreditCard.Checked)
                    {
                        int userID = int.Parse(Session["userid"].ToString());
                        CreditCard myCard = CreateCreditCard();
                        int retValue = service.StoreCreditCardInfoByUserID(userID, myCard);
                        if (retValue == 0)
                        {
                            lblGeneral_Error.Text = "Your credit card can't be stored!";
                        }
                    }

                    if (result)
                    {
                        lblSuccess.Text = "Order was placed successfully!";
                        // pnlShoppingCart.Visible = false;
                        pnlShippingInfo.Visible = false;
                        pnlCreditCardInfo.Visible = false;
                        txtCode.Visible = false;

                        // Need to traverse through shopping cart and update subscription for user who purchased it
                        for (int i = 0; i < cart.Count; i++)
                        {
                            if (cart[i].Type == "Subscription")
                            {
                                string userid = Session["userid"].ToString();
                                int UserID = int.Parse(userid);
                                string subID = cart[i].ProductID.ToString();
                                int SubID = int.Parse(subID);
                                service.UpdateSubscription(UserID, SubID);
                            }
                        }
                        Session.Remove("Cart");
                        // hide command buttons
                        btnCancel.Visible = false;
                        btnPlaceOrder.Visible = false;                                   
                    }
                }
            }
            catch (Exception ex)
            {
                lblGeneral_Error.Text = ex.Message;
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }

        //Show Customer Info
        private void ShowCustomerInfo(string username)
        {
            User user = loginService.GetUserByUsername(username);
            if (user != null)
            {
                txtRecipient.Text = user.Firstname + " " + user.Lastname;
                txtAddress.Text = user.Street;
                txtCity.Text = user.City;
                ddlState.SelectedValue = user.State;
                txtZipcode.Text = user.Zipcode;
            }
        }

        //Show Credit Card Info
        private void ShowCreditCardInfo(int id)
        {
            CreditCard creditCard = service.GetCreditCardInfoByUserID(id);
            if (creditCard != null)
            {
                txtCardNumber.Text = creditCard.CardNumber.Substring(0, 4) + " xxxx xxxx " + creditCard.CardNumber.Substring(12, 4);
                hidCardNumber.Value = utils.Encrypt(creditCard.CardNumber);
                ddlCardType.SelectedValue = creditCard.CardType;
                ddlMonth.SelectedValue = creditCard.ExpirationMonth.ToString();
                ddlYear.SelectedValue = creditCard.ExpirationYear.ToString();
            }
        }

        protected void btnApplyCode_Click(object sender, EventArgs e)
        {
            double subTotal = 0.0;
            double total = 0.0;
            double taxAmount = 0.0;
            double shippingFee = 0.0;
            string code = txtCode.Text;
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

            if (code == "FREE15")
            {                
                lblCodeErrorNone.Visible = true;
                lblTotal.Text =   (total-(total * 0.15)).ToString("c2");
                txtCode.Text = "";
                btnApplyCode.Visible = false;
                lblCode.Visible = false;
                txtCode.Visible = false;
                lblCodeErrorNone.Text = "Success! 15% Off Order Applied";
                lblCodeError.Visible = false;
            }
            else
            {
                lblCodeError.Visible = true;
                lblTotal.Text = total.ToString("c2");
                lblCodeError.Text = "This code did not work.";
                lblCodeErrorNone.Visible = false;
                txtCode.Text = "";
                btnApplyCode.Visible = true;
            }
        }

        protected void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            hidCardNumber.Value = utils.Encrypt(txtCardNumber.Text);
        }
    }
}