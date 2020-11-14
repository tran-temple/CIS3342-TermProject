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
    height: 300px;
}



    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">


       <asp:DataList ID="DLSubscriptions" runat="server" RepeatDirection="Horizontal">
       <ItemTemplate>
           <div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom box-shadow">

<div class="container">
      <div class="card-deck mb-3 text-center">
        <div class="card mb-4 box-shadow">
          <div class="card-header">
            <h4 class="my-0 font-weight-normal"> <asp:Label ID="Label1" runat="server"  Text='<%# Bind("SubscriptionName") %>'> </asp:Label></h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title">  <asp:Label ID="Label2" runat="server"  Text= '<%# DataBinder.Eval(Container.DataItem, "SubscriptionPrice") %>'> </asp:Label><small class="text-muted"> <asp:Label ID="Label3" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "SubscriptionBillingTime") %>'> </asp:Label>  </small></h1>
            <ul class="list-unstyled mt-3 mb-4">
                <li>
                      <asp:Label ID="Label4" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "SubscriptionDescription") %>'>
                         </asp:Label>
                </li>
                  </ul>
                <asp:Button ID="btnAddSubscriptionToCart" runat="server" Text="Choose Subscription" CssClass="align-self-end btn btn-lg btn-block btn-outline-success" />
                               
                </div>
            </div>
          </div>
    </div>
       
       </ItemTemplate>     

</asp:DataList>

    

  
         

</asp:Content>
