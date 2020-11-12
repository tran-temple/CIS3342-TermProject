<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GuestNavUC.ascx.cs" Inherits="CIS3342_TermProject.GuestNavUC" %>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link rel="stylesheet" href="StyleNavigation.css" />
          <asp:Panel ID="panelNavGuest" runat="server">
            <div class="navGuest" runat="server">
                <ul>
                     <li>
  <a href="Home.aspx">
                  Home
                </a>
                   </li>
               


           
                    <li>
               
                    <li class="float-right">
                        <asp:Label ID="lblLoggedInAs" runat="server" Text="Guest"></asp:Label>
                    </li>
                    <li>
                        <a href="LogIn.aspx"> Sign Up</a>
                    </li>
               </ul>
            </div>
                 </asp:Panel>
           