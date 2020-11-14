<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminSubscription.aspx.cs" Inherits="CIS3342_TermProject.AdminSubscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">

    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <asp:GridView ID="gvSubscriptions" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"  EnableViewState="False" OnRowEditing="gvSubscriptions_RowEditing" OnRowUpdating="gvSubscriptions_RowUpdating" OnSelectedIndexChanged="gvSubscriptions_SelectedIndexChanged" OnRowCancelingEdit="gvSubscriptions_RowCancelingEdit">
        <Columns>
                        <asp:BoundField DataField="SubscriptionID" HeaderText="Subscription ID" ReadOnly="True" Visible="false" />
                  <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Delete" ShowHeader="True" Text="Delete" ControlStyle-CssClass="btn btn-outline-dark"  />        

            <asp:ImageField DataImageUrlField="SubscriptionImage" HeaderText="Image" ControlStyle-Width="100" ControlStyle-Height = "100">
            </asp:ImageField>
            <asp:BoundField DataField="SubscriptionName" HeaderText="Subscription Name" SortExpression="SubscriptionName" />
            <asp:BoundField DataField="SubscriptionPrice" HeaderText="Price" SortExpression="SubscriptionPrice" />
            <asp:BoundField DataField="SubscriptionBillingTime" HeaderText="Billing Time" SortExpression="SubscriptionBillingTime" />
            <asp:BoundField DataField="SubscriptionDescription" HeaderText="Description" SortExpression="SubscriptionDescription" />
     
            <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
        </Columns>
                   
    </asp:GridView>

    <br />
    <br />
    <button type="button" class="btn btn-success float-right" data-toggle="modal" data-target="#myModal">Add New Subscription</button>

<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
    
        <h4 class="modal-title">Add New Subscription</h4>
      </div>
      <div class="modal-body">
          <div class="form-group row justify-content-around">
              <label for="txtNewSubscriptionName" class="col-sm-5 col-form-label"> Subscription Name</label>
        <asp:TextBox ID="txtNewSubscriptionName" runat="server" CssClass="col-sm-5"> </asp:TextBox>
        <br />
                <label for="txtNewSubscriptionDescription" class="col-sm-5 col-form-label"> Subscription Description</label>
        <asp:TextBox ID="txtNewSubscriptionDescription" runat="server" CssClass="col-sm-5"> </asp:TextBox>
              <br />
                <label for="txtNewSubcriptionPrice" class="col-sm-5 col-form-label"> Subscription Price</label>
        <asp:TextBox ID="txtNewSubscriptionPrice" runat="server" CssClass="col-sm-5"> </asp:TextBox>
              <br />
                <label for="txtNewSubscriptionBilling" class="col-sm-5 col-form-label"> Subscription Billing Time</label>
        <asp:TextBox ID="txtNewSubscriptionBilling" runat="server" CssClass="col-sm-5"> </asp:TextBox>

              <br />
              <label for="imageUpload" class="col-sm-5 col-form-label"> Subscription Image</label>
              <asp:FileUpload ID="FileUpload1" runat="server" />

          </div>
       
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
              <asp:Button type="button" class="btn btn-primary" ID="btnAddNewSubscription" runat="server" Text="Add"></asp:Button>
      </div>
    </div>

  </div>
</div>

    



</asp:Content>

