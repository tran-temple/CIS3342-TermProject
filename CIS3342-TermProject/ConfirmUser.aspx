<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ConfirmUser.aspx.cs" Inherits="CIS3342_TermProject.ConfirmUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 shadow border">
        <div class="m-3 form-group">
            <div class="row form-group justify-content-center">
                <asp:label ID="lblErrorMessage" runat="server" cssclass="text-danger"></asp:label>
                <asp:label ID="lblSuccessMessage" runat="server" cssclass="text-success"></asp:label><br />                
                <asp:LinkButton ID="btnGoToLogin" runat="server" CssClass="btn-link" OnClick="btnGoToLogin_Click">Please click this link to go to Login!</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
