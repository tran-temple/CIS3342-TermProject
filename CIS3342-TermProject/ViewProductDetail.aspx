<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewProductDetail.aspx.cs" Inherits="CIS3342_TermProject.ViewProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 shadow border">
        <div class="row form-group justify-content-center">
            <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <!-- View Product Detail -->
        <asp:Panel ID="pnlViewProfile" runat="server">
            <div class="row justify-content-center mt-2">
                <div class="col">
                    <div class="row mt-2 ml-1 mb-2"><asp:Image ID="imgProduct" Width="200px" Height="200px" runat="server" CssClass="border shadow"/></div>
                    <div class="row ml-1"><asp:Button ID="btnAddToCart" runat="server" Text="Add to cart" CssClass="btn-primary mt-2" Visible="false" OnClick="btnAddToCart_Click" /></div>
                    <div class="row ml-1"><asp:Button ID="btnAddReview" runat="server" Text="Add Review" CssClass="btn-primary mt-2" Visible="false" OnClick="btnAddReview_Click" /></div>
                    <div class="row ml-1"><asp:Button ID="btnModifyProduct" runat="server" Text="Modify Product" CssClass="btn-primary mt-2" Visible="false" OnClick="btnModifyProduct_Click" /></div>
                    <div class="row ml-1"><asp:Button ID="btnDeleteProduct" runat="server" Text="Delete Product" CssClass="btn-primary mt-2" Visible="false" OnClick="btnDeleteProduct_Click" /></div>
                </div>
                <div class="col-md-8">
                    <div class="row mt-2 ml-1">
                        <span>Name: </span>&nbsp;
                        <asp:Label ID="lblName" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Description: </span>&nbsp;
                        <asp:Label ID="lblDescription" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <div class="row mt-2 ml-1">
                        <span>Price: </span>&nbsp;
                        <asp:Label ID="lblPrice" runat="server" CssClass="font-weight-bold"></asp:Label>
                    </div>
                    <asp:Panel ID="pnlQuantity" runat="server" Visible="false">
                        <div class="row mt-2 ml-1">
                            <span>Quantity in stock: </span>&nbsp;
                        <asp:Label ID="lblQuantity" runat="server" CssClass="font-weight-bold"></asp:Label>
                        </div>
                    </asp:Panel>                    
                    <div class="row mt-2 ml-1">
                        <span>Rating: </span>&nbsp;
                        <asp:Label ID="lblTotalRate" runat="server" CssClass="font-weight-bold"></asp:Label><br />
                    </div>
                    <div class="row mt-2 ml-1">                        
                        <asp:Label ID="lblOutOfStock" runat="server" CssClass="font-weight-bold text-danger text-uppercase" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>

            <!-- Showing the list of reviews -->
            <div class="row justify-content-center mt-3">
                <div class="col">
                    <asp:Repeater ID="rptReviews" runat="server">                        
                        <ItemTemplate>
                            <hr />
                            <div class="row mt-3 ml-2">
                                <span class="font-weight-bolder">Review <%# Container.ItemIndex + 1 %>:</span>
                            </div>
                            <div class="row ml-4">
                                <span>Rating:</span>&nbsp;
                                <asp:Label ID="lblRating" runat="server" CssClass="font-weight-bold"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "Rating") %>'></asp:Label>                                
                            </div>
                            <div class="row ml-4">
                                <span>Comments:</span>&nbsp;
                                <asp:Label ID="lblComments" runat="server" CssClass="font-italic"
                                    Text='<%# DataBinder.Eval(Container.DataItem, "Comments") %>'></asp:Label>
                            </div>                            
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
