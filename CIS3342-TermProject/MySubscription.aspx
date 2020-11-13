<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MySubscription.aspx.cs" Inherits="CIS3342_TermProject.MySubscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <asp:Image ID="imgSubscription" runat="server" Height="288px" Width="279px" />
            <asp:Label ID ="lblCurrentSubscription" runat="server"></asp:Label>
            <asp:Button ID="btnCancelSubscription" runat="server" Text="Button" OnClick="btnCancelSubscription_Click" />
            <asp:Button ID="btnUpgradeSubscription" runat="server" Text="Button" OnClick="btnUpgradeSubscription_Click" />
            <asp:Button ID="btnAddSubscription" runat="server" Text="Button" OnClick="btnAddSubscription_Click" />
</asp:Content>
