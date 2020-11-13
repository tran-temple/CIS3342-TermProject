<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberNavUC.ascx.cs" Inherits="CIS3342_TermProject.MemberNavUC" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="StyleNavigation.css" />
          <asp:Panel ID="panelNavMember" runat="server">
            <div class="navMember" runat="server">
                <ul>
                     <li>
  <a href="Home.aspx">
                  Home
                </a>
                   </li>
                <li><a href="PurchaseHistory.aspx">
                   Purchase History
                    </a>
                </li>
                    <li>
                <a href="ManageSubscription.aspx">
                    Manage Subscription
                </a>
                        </li>

                    <li>
                     <a href="MyCart.aspx"> 

                         My Cart
</a>
                    </li>
                    <li>
               
                    <li class="float-right">
                        <asp:Label ID="lblLoggedInAs" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <a href="LogIn.aspx"> Log Off</a>
                    </li>
               </ul>
            </div>
                 </asp:Panel>
           