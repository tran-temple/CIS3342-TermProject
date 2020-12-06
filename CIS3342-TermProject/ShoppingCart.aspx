<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="CIS3342_TermProject.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-12 mt-3">
        <div class="row form-group ml-2">
            <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
        </div>
        <asp:Panel ID="pnlShoppingCart" runat="server">
            <div class="row form-group">
                <div class="col-8">
                    <div class="card-deck mb-3">
                        <div class="card mb-4 box-shadow">
                            <div class="card-header">
                                <asp:Label ID="lblHeadingCart" runat="server" Text="Shopping Bag"></asp:Label>
                            </div>
                            <div class="card-body d-flex flex-column">
                                <asp:ListView ID="lvShoppingBag" runat="server" OnItemCommand="lvShoppingBag_ItemCommand" > 
                                    <ItemTemplate>
                                        <div class="card border mt-2">
                                            <div class="row form-group">
                                                <div class="col ml-2 mt-2">
                                                    <span class="font-weight-bolder">Item <%# Container.DataItemIndex + 1 %>:</span>
                                                </div>
                                            </div>
                                            <div class="row form-group">                                                
                                                <div class="col-3">
                                                    <asp:Image runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageURL") %>' Width="90px" Height="90px" CssClass="rounded-circle shadow ml-2"/>
                                                </div>
                                                <div class="col-6">
                                                    <asp:Label ID="lblProductName" runat="server" CssClass="font-weight-bold"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>'></asp:Label>
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="lblQuantity" runat="server" CssClass="font-weight-bold"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %> ' ></asp:Label>
                                                </div>
                                                <div class="col mr-2">
                                                    <asp:Label ID="lblProductPrice" runat="server" CssClass="font-weight-bold"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductPrice", "{0:c}") %>'></asp:Label>
                                                    <br />
                                                  
                                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass=" btn btn-sm  btn-outline-danger mt-auto" CommandName="Remove" CommandArgument='<%# Container.DataItemIndex%>' />                                            
                                                </div>                                                
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card-deck mb-3">
                        <div class="card mb-4 box-shadow">
                            <div class="card-header">
                                <asp:Label ID="lblHeadingTotal" runat="server" Text="Summary"></asp:Label>
                            </div>
                            <div class="card-body d-flex flex-column">
                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblSubTotalTitle" runat="server" Text="SubTotal"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="lblSubTotal" runat="server" Text="$0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblTaxTitle" runat="server" Text="Tax"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="lblTax" runat="server" Text="FREE"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblShippingTitle" runat="server" Text="Shipping"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="lblShippingFee" runat="server" Text="FREE"></asp:Label>
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col">
                                        <asp:Label ID="lblTotalTitle" runat="server" Text="Total"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                                    </div>
                                </div>
                                <div class="row text-center mt-3">
                                    <div class="col">
                                        <asp:Button ID="btnCheckOut" runat="server" CssClass="btn-success" Text="Proceed To Checkout" OnClick="btnCheckOut_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
