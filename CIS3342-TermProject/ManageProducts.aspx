<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="CIS3342_TermProject.ManageProducts" %>

<%@ Register Src="~/UserControls/ImageUploadUC.ascx" TagPrefix="uc1" TagName="ImageUploadUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <asp:Label ID="lblDisplay" runat="server"></asp:Label>
    <asp:GridView ID="gvProducts" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged"  EnableViewState="False" OnRowCommand="gvProducts_RowCommand" OnRowEditing="gvProducts_RowEditing" OnRowUpdating="gvProducts_RowUpdating" OnRowCancelingEdit="gvProducts_RowCancelingEdit">
        <Columns>
               <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" SortExpression="ProductID"  Visible="false" />
            <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" ControlStyle-CssClass="btn btn-outline-dark" />
         
            <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Image" ControlStyle-Width="100" ControlStyle-Height = "100">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="ProductName" HeaderText="Name" SortExpression="ProductName" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="ProductPrice" HeaderText="Price" SortExpression="ProductPrice" />
            <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" SortExpression="ProductQuantity" />
            <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" ShowHeader="True" ControlStyle-CssClass="btn btn-outline-dark" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>

     <button type="button" class="btn btn-success float-right" data-toggle="modal" data-target="#myModal">Add New Product</button>
                        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
    
        <h4 class="modal-title">Add New Product</h4>
      </div>
      <div class="modal-body">
          <div class="form-group">
              
              <asp:Label ID="lblFormError" runat="server" CssClass="error"> </asp:Label>
              <br /><br />
              <label for="txtNewProductName" class="col-form-label"> Product Name</label>
        <asp:TextBox ID="txtNewProductName" runat="server" CssClass="form-control"> </asp:TextBox>
        <br />
                <label for="txtNewProductDescription" class="col-form-label"> Product Description</label>
        <asp:TextBox ID="txtNewProductDescription" runat="server" CssClass="form-control"> </asp:TextBox>
              <br />
                <label for="txtNewProductPrice" class="col-form-label" > Product Price</label>
        <asp:TextBox ID="txtNewProductPrice" runat="server" CssClass="form-control"> </asp:TextBox>
              <label for="txtNewProductQuantity" class="col-form-label" > Product Quantity</label>
        <asp:TextBox ID="txtNewProductQuantity" runat="server" CssClass="form-control"> </asp:TextBox>
              <br />
                <label for="txtNewProductCategory" class="col-form-label"> Product Category</label>
       <asp:TextBox ID="txtNewProductCategory" runat="server" CssClass="form-control"> </asp:TextBox>
              <asp:DropDownList ID="ddlProductCategory" runat="server"></asp:DropDownList>

              <br />
     
              <uc1:ImageUploadUC runat="server" ID="ImageUploadUC" />
    <br /><br />
  
          </div>
       
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
              <asp:Button type="button" class="btn btn-success" ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:Button>
      </div>
    </div>

  </div>
</div>
</asp:Content>
