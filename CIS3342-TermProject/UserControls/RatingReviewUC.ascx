<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatingReviewUC.ascx.cs" Inherits="CIS3342_TermProject.UserControls.RatingReviewUC" %>
<asp:Panel ID="pnlRatingReview" runat="server">
    <div class="modal-backdrop show"></div>
<!-- Modal -->
    <div id="modalRatingReview" class="modal show" style="display: block; padding-right: 19px;" role="dialog" data-backdrop="static"  tabindex="-1" aria-modal="true" role="dialog">
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
                    <asp:Button ID="btnClose"  class="btn-danger" runat="server" OnClick="btnClose_Click" Text="Close"></asp:Button>
                    <asp:Button class="btn-primary" ID="btnPost" runat="server" Text="Post Review" OnClick="btnPost_Click"></asp:Button>
                </div>
            </div>

        </div>
    </div>
</asp:Panel>
