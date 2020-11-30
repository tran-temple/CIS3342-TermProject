using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EcommerceLibrary;

namespace CIS3342_TermProject.UserControls
{
    public partial class RatingReviewUC : System.Web.UI.UserControl
    {
        ProductService productService = new ProductService();
        // Event Handler for post review button
        public event EventHandler RatingSubmitedSuccessful;
        // Event Handler for Close button
        public event EventHandler CloseButtonClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get product ID from URL
            hidProductID.Value = Request.QueryString["ProdID"];
            hidUserID.Value = Session["userID"].ToString();
        }

        //Create a review for insert
        private Review CreateReviewObject()
        {
            Review review = new Review();
            review.ProductID = int.Parse(hidProductID.Value);
            review.UserID = int.Parse(hidUserID.Value);
            if (rdoStar1.Checked) review.Rating = 1;
            if (rdoStar2.Checked) review.Rating = 2;
            if (rdoStar3.Checked) review.Rating = 3;
            if (rdoStar4.Checked) review.Rating = 4;
            if (rdoStar5.Checked) review.Rating = 5;
            review.Comments = txtComments.Text;

            return review;
        }

        private void ClearForm()
        {
            rdoStar1.Checked = false;
            rdoStar2.Checked = false;
            rdoStar3.Checked = false;
            rdoStar4.Checked = false;
            rdoStar5.Checked = false;
            txtComments.Text = "";
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            Review review = CreateReviewObject();
            if (review.Rating < 1)
            {
                lblRating_Error.Text = "Please choose a rating level!";
                return;
            }
            else
            {
                int ret = productService.InsertReview(review);
                if (ret > 0)
                {
                    // Clear the form
                    ClearForm();
                    // fire the successful event
                    RatingSubmitedSuccessful(this, EventArgs.Empty);
                }
                else
                {
                    lblMessage.Text = "The review is not posted!";
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            // fire the close event
            CloseButtonClicked(this, EventArgs.Empty);
        }
    }
}