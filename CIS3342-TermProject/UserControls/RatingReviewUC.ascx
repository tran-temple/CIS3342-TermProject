<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatingReviewUC.ascx.cs" Inherits="CIS3342_TermProject.UserControls.RatingReviewUC" %>
<asp:Panel ID="pnlRatingReview" runat="server">
<!-- Modal -->
    <div id="modalRatingReview" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Write a review</h4>
                    <br />
                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                    <asp:HiddenField ID="hidProductID" runat="server" />
                    <asp:HiddenField ID="hidUserID" runat="server" />
                </div>
                <div class="modal-body">
                    <div class="row form-group">
                        <div class="col">
                            <span>Choose A Rating Level: </span>
                            &nbsp;&nbsp;<asp:Label ID="lblRating_Error" runat="server" CssClass="text-danger"></asp:Label><br />
                            <asp:RadioButton ID="rdoStar1" GroupName="Rating" runat="server" />
                                <span class="fa fa-star checked"></span>
                            <br />
                            <asp:RadioButton ID="rdoStar2" GroupName="Rating" runat="server" />
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                            <br />
                            <asp:RadioButton ID="rdoStar3" GroupName="Rating" runat="server" />
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                            <br />
                            <asp:RadioButton ID="rdoStar4" GroupName="Rating" runat="server" />
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                            <br />
                            <asp:RadioButton ID="rdoStar5" GroupName="Rating" runat="server" />
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                                <span class="fa fa-star checked"></span>
                        </div>
                    </div>
                    <div class="row form-group">
                        <div class="col">
                            <span>Comments: </span><br />
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" CssClass="w-100"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button class="btn-primary" ID="btnPost" runat="server" Text="Post Review" OnClick="btnPost_Click"></asp:Button>
                </div>
            </div>

        </div>
    </div>
</asp:Panel>
