<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="CIS3342_TermProject.ProductPage" %>

<%@ Register Src="~/UserControls/ImageUploadUC.ascx" TagPrefix="uc1" TagName="ImageUploadUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="col-lg-8 offset-lg-2 mt-3 shadow border">        
        <!-- Add / Modify a Product -->                
        <div class="m-3 form-group">            
            <asp:Panel ID="pnlProduct" runat="server">
                <div class="row form-group justify-content-center">
                    <asp:Label ID="lblProductHeading" runat="server" Text="... Product" CssClass="h3 font-weight-bold"></asp:Label>
                    <asp:HiddenField ID="hidProductID" runat="server" />
                </div>
                <div class="row form-group">
                    <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Product name: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblProductName_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Description: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblDescription_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Categories: </span></div>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem Value="-1" Selected="True">Select a category...</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;<asp:Label ID="lblCategory_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Product Price: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPrice" runat="server" ></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblPrice_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col"><span>Product Quantity: </span></div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number"></asp:TextBox>
                        &nbsp;&nbsp;<asp:Label ID="lblQuantity_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col-md-12">
                        <uc1:ImageUploadUC runat="server" ID="ImageUploadUC" />
                        &nbsp;&nbsp;<asp:Label ID="lblImage_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>                                
                <div class="row form-group justify-content-center">                    
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-secondary" OnClick="btnCancel_Click"/>
                    &nbsp;&nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-primary" OnClick="btnSubmit_Click"/>
                </div>
            </asp:Panel>
        </div>
    </div>

</asp:Content>
