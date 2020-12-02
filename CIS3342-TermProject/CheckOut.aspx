<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="CIS3342_TermProject.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-lg-12 mt-3">
        <div class="row form-group">
            <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
             <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>
        </div>
       
        <asp:Panel ID="pnlShoppingCart" runat="server">
            <div class="row form-group">
                <div class="col-8">
                    <div class="card-deck mb-3">
                        <div class="card mb-4 box-shadow">
                            <div class="card-header">
                                <asp:Label ID="lblHeadingOrder" runat="server" Text="You are ordering the following items:"></asp:Label>
                            </div>
                            <div class="card-body d-flex flex-column">
                                <!-- The items list is ordered -->
                                <asp:ListView ID="lvShoppingBag" runat="server">
                                    <ItemTemplate>
                                        <div class="card border-left-0 border-top-0 border-right-0">
                                            <div class="row form-group">
                                                <div class="col ml-2 mt-2">
                                                    <span class="font-weight-bolder">Item <%# Container.DataItemIndex + 1 %>:</span>
                                                </div>
                                            </div>
                                            <div class="row form-group">
                                                <div class="col">
                                                    <asp:Image runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageURL") %>' Width="80px" Height="80px" CssClass="rounded-circle shadow ml-2" />
                                                </div>
                                                <div class="col">
                                                    <asp:Label ID="lblProductName" runat="server" CssClass="font-weight-bold"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>'></asp:Label>
                                                </div>
                                                <div class="col text-center">
                                                    <asp:Label ID="lblQuantity" runat="server" CssClass="font-weight-bold"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %> '></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblProductPrice" runat="server" CssClass="font-weight-bold"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductPrice", "{0:c}") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <hr />
                                <!-- Shipping info-->
                                <div class="row col">
                                    <asp:Panel ID="pnlShippingInfo" runat="server">
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>Recipient: </span>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="txtRecipient" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="lblRecipient_Error" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>Address: </span>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="lblAddress_Error" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>City: </span>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="lblCity_Error" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>State: </span>
                                            </div>
                                            <div class="col">
                                                <asp:DropDownList ID="ddlState" runat="server">
                                                    <asp:ListItem Value="">Choose a state...</asp:ListItem>
                                                    <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                                    <asp:ListItem Value="CA">California</asp:ListItem>
                                                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                                    <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                                                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                                    <asp:ListItem Value="FL">Florida</asp:ListItem>
                                                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                                    <asp:ListItem Value="ME">Maine</asp:ListItem>
                                                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                                    <asp:ListItem Value="MT">Montana</asp:ListItem>
                                                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                                    <asp:ListItem Value="NY">New York</asp:ListItem>
                                                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                                    <asp:ListItem Value="TX">Texas</asp:ListItem>
                                                    <asp:ListItem Value="UT">Utah</asp:ListItem>
                                                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                                    <asp:ListItem Value="WA">Washington</asp:ListItem>
                                                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label ID="lblState_Error" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>Zipcode: </span>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="txtZipcode" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="lblZipcode_Error" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <hr />
                                <!-- Credit card info-->
                                <div class="row col">
                                    <asp:Panel ID="pnlCreditCardInfo" runat="server">
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>Card Type: </span>
                                            </div>
                                            <div class="col">
                                                <asp:DropDownList ID="ddlCardType" runat="server">
                                                    <asp:ListItem>American Express</asp:ListItem>
                                                    <asp:ListItem>Discover</asp:ListItem>
                                                    <asp:ListItem>MasterCard</asp:ListItem>
                                                    <asp:ListItem>Visa</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>Card number: </span>
                                            </div>
                                            <div class="col">
                                                <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox><br />
                                                <asp:Label ID="lblCardNumber_Error" runat="server" CssClass="text-danger"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <span>Expire Date: </span>
                                            </div>
                                            <div class="col">
                                                <asp:DropDownList ID="ddlMonth" runat="server">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col">
                                                <asp:DropDownList ID="ddlYear" runat="server">
                                                    <asp:ListItem>2020</asp:ListItem>
                                                    <asp:ListItem>2021</asp:ListItem>
                                                    <asp:ListItem>2022</asp:ListItem>
                                                    <asp:ListItem>2023</asp:ListItem>
                                                    <asp:ListItem>2024</asp:ListItem>
                                                    <asp:ListItem>2025</asp:ListItem>
                                                    <asp:ListItem>2026</asp:ListItem>
                                                    <asp:ListItem>2027</asp:ListItem>
                                                    <asp:ListItem>2028</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col">
                                                <asp:CheckBox ID="chkStoreCreditCard" runat="server" Text="Store Credit Card" CssClass="btn-primary" />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Order summary -->
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
                                        <asp:Label ID="lblCode" runat="server" Text=" Coupon Code"></asp:Label>
                                    </div>
                                    <div class="col">
                                        <asp:Textbox ID="txtCode" runat="server"></asp:Textbox>
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
                                           <ContentTemplate>
                                        <asp:Button ID="btnApplyCode" runat="server" CssClass="btn-sm btn-outline-primary" Text="Apply" OnClick="btnApplyCode_Click" />

                                               <div class="row">
                                    
                                    <div class="col">
                                        
                                        <asp:Label ID="lblTotalTitle" runat="server" Text="Total"></asp:Label>
                                    </div>
                                   
                                </div>
                                  <div class="col">
                                        
                                       
                                              <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                                         
                                                 
                                    </div>
                                </div>
                                                </ContentTemplate>
                                         </asp:UpdatePanel>
                            
                                <div class="row text-center mt-3">
                                    <div class="col">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-danger" OnClick="btnCancel_Click"/> &nbsp;&nbsp;
                                        <asp:Button ID="btnPlaceOrder" runat="server" CssClass="btn-success" Text="Place Order" OnClick="btnPlaceOrder_Click"/>                                        
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
