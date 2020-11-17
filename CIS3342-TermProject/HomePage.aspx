<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CIS3342_TermProject.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 105px;
        }

       @media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.container {
  max-width: 960px;

}

.pricing-header {
  max-width: 700px;
}

.card-deck .card {
  min-width: 220px;
}

.border-top { border-top: 1px solid #e5e5e5; }
.border-bottom { border-bottom: 1px solid #e5e5e5; }

.box-shadow { box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05); 

}

.card-body {
    height: 475px;
}

.hide {
    color: white;
    font-size: 0.1px;
}


.subtitle {
    text-align: center;
    font-size: 20px;
    color: darkkhaki;

}

.subImg {
    border-radius: 50%;
    
    display: block;
  margin-left: auto;
  margin-right: auto;
 
  width: 50%;
}



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server" >
   
    <asp:Label ID ="lblSubtitle" runat="server" CssClass="subtitle">Subscriptions</asp:Label>
    <br /><br />
       <asp:Label ID="lblSubscriptionIDShow" runat="server" Text="Label"></asp:Label>
       <asp:DataList ID="DLSubscriptions" runat="server" RepeatDirection="Horizontal"  OnItemCommand="DLSubscriptions_ItemCommand">
       <ItemTemplate>
           <div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom box-shadow">

<div class="container">
      <div class="card-deck mb-3 text-center">
        <div class="card mb-4 box-shadow">
          <div class="card-header">

            <h4 class="my-0 font-weight-normal"> <asp:Label ID="Label1" runat="server"  Text='<%# Bind("SubscriptionName") %>'> </asp:Label></h4>
                <h4 class="my-0 font-weight-normal" aria-hidden="true"> <asp:Label ID="lblSubscriptionID" runat="server" CssClass="hide" Text='<%# Bind("SubscriptionID") %>'> </asp:Label></h4>
          </div>
          <div class="card-body d-flex flex-column">

               <asp:Image Class="subImg" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "SubscriptionImage") %>' Width="150px" Height="150px" />
 <br />

            <h1 class="card-title pricing-card-title">  <asp:Label ID="Label2" runat="server"  Text= '<%# DataBinder.Eval(Container.DataItem, "SubscriptionPrice") %>'> </asp:Label><small class="text-muted"> <asp:Label ID="Label3" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "SubscriptionBillingTime") %>'> </asp:Label>  </small></h1>
            <ul class="list-unstyled mt-3 mb-4">
                <li>
                      <asp:Label ID="Label4" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "SubscriptionDescription") %>'>
                         </asp:Label>
                </li>
                  </ul>
                <asp:Button ID="btnAddSubscriptionToCart" runat="server" Text="Choose Subscription" CssClass=" btn btn-lg btn-block btn-outline-success mt-auto" />
                               
                </div>
            </div>
          </div>
 
    </div>
       
       </ItemTemplate>     

</asp:DataList>

    
    <asp:Label ID="lblProductsTitle" runat="server" CssClass="subtitle">Products</asp:Label>
        <div class="card box-shadow col-lg-12 mt-2 ">
            <!-- Search area -->
            <div class="row justify-content-center mt-2 ">
                <div class="col-md-6 m-2">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="w-100"></asp:TextBox>
                </div>
                <div class="col m-2">
                    <asp:DropDownList ID="ddlCategory" runat="server">
                        <asp:ListItem Value="-1" Selected="True">Select a category...</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>

            <!-- Showing the list of products -->
            <div class="row justify-content-center mt-2">
                <div class="col m-2">
                    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
                        CellPadding="8" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvProducts_PageIndexChanging" CssClass="w-100">
                        <Columns>                            
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <asp:Image ID="imgRestaurant" runat="server" ImageUrl='<%# Eval("ProductImage") %>' Width="150px" Height="150px" CssClass="rounded-circle shadow-lg m-2"/>
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="ProductPrice" DataFormatString="{0:c}" HeaderText="Price" />
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQuantity" runat="server" Width="60px" TextMode="Number"></asp:TextBox>
                                    <asp:Label ID="lblQuantity" runat="server" Text="OUT OF STOCK" CssClass="text-danger" Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to cart" CssClass="btn-primary"></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ButtonType="Link" ShowSelectButton="true" SelectText="Detail" ControlStyle-CssClass="text-primary"></asp:CommandField>
                            <asp:BoundField DataField="ProductID" HeaderText="ProductID" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol" />
                            <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" HeaderStyle-CssClass="hiddenCol" ItemStyle-CssClass="hiddenCol" />
                        </Columns>
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" CssClass="hiddenCol"/>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </div>
        </div>

</asp:Content>
