<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNavUC.ascx.cs" Inherits="CIS3342_TermProject.AdminNavUC" %>


<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="StyleNavigation.css" />
          <asp:Panel ID="panelNavAdmin" runat="server">
            <div class="navAdmin" runat="server">
                <ul>
                     <li>
  <a href="Home.aspx">
                  Home
                </a>
                   </li>
                <li><a href="ModifySubscription.aspx">
                    Modify Subscriptions
                    </a>
                </li>
                    <li>
                <a href="ManageProducts.aspx">
                    Manage Products
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
           