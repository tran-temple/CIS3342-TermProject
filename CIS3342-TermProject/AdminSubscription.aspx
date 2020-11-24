<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminSubscription.aspx.cs" Inherits="CIS3342_TermProject.AdminSubscription" %>

<%@ Register Src="~/UserControls/ImageUploadUC.ascx" TagPrefix="ucUpload" TagName="ImageUpload1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    
<link href="https://fonts.googleapis.com/css2?family=Secular+One&display=swap" rel="stylesheet">

<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet">
   <link rel="stylesheet" type="text/css" href="styles/AdminSubscriptionStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <div class="gvContainer">

    <asp:Label ID="lblError" runat="server"></asp:Label>
                <asp:GridView ID="gvSubscriptions" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"  EnableViewState="False" OnRowCommand="gvSubscriptions_RowCommand" OnRowEditing="gvSubscriptions_RowEditing" OnRowUpdating="gvSubscriptions_RowUpdating" OnSelectedIndexChanged="gvSubscriptions_SelectedIndexChanged" OnRowCancelingEdit="gvSubscriptions_RowCancelingEdit">
        <Columns>
                        <asp:BoundField DataField="SubscriptionID" HeaderText="Subscription ID" ReadOnly="True" Visible="false" />
                  <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Delete" ShowHeader="True" Text="Delete" ControlStyle-CssClass="btn btn-outline-dark"  >        

<ControlStyle CssClass="btn btn-outline-dark"></ControlStyle>
                        </asp:ButtonField>
            <asp:TemplateField HeaderText="Image" HeaderStyle-Width="200px">  
                <ItemTemplate>  
                    <asp:Image ID="imgSub" runat="server" ImageUrl='<%# Eval("SubscriptionImage") %>' Height="100px" Width="100px" />  
                </ItemTemplate>  
                <EditItemTemplate>  
                    
                    <br />  
                  <asp:FileUpload ID="FileUploadControl2" runat="server" />
                </EditItemTemplate>
                 </asp:TemplateField>  
            
            <asp:BoundField DataField="SubscriptionName" HeaderText="Subscription Name" SortExpression="SubscriptionName" ControlStyle-Width="60" />
            <asp:BoundField DataField="SubscriptionPrice" HeaderText="Price" SortExpression="SubscriptionPrice" ControlStyle-Width="40" />
            <asp:BoundField DataField="SubscriptionBillingTime" HeaderText="Billing Time" SortExpression="SubscriptionBillingTime" ControlStyle-Width="40"/>
            <asp:BoundField DataField="SubscriptionDescription" HeaderText="Description" SortExpression="SubscriptionDescription" ControlStyle-Width="170" />
     
            <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" ShowHeader="False"  ControlStyle-CssClass="btn btn-outline-dark" >
<ControlStyle CssClass="btn btn-outline-dark"></ControlStyle>
                        </asp:CommandField>
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
 
   
    <br />
    <br />
    <asp:Image ID="imageFile" runat="server" />

          </div>



    <button type="button" class="btn btn-success float-right" data-toggle="modal" data-target="#myModal">Add New Subscription</button>
                        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
    
        <h4 class="modal-title">Add New Subscription</h4>
      </div>
      <div class="modal-body">
          <div class="form-group">
              
              <asp:Label ID="lblFormError" runat="server" CssClass="error"> </asp:Label>
              <br /><br />
              <label for="txtNewSubscriptionName" class="col-form-label"> Subscription Name</label>
        <asp:TextBox ID="txtNewSubscriptionName" runat="server" CssClass="form-control"> </asp:TextBox>
        <br />
                <label for="txtNewSubscriptionDescription" class="col-form-label"> Subscription Description</label>
        <asp:TextBox ID="txtNewSubscriptionDescription" runat="server" CssClass="form-control"> </asp:TextBox>
              <br />
                <label for="txtNewSubcriptionPrice" class="col-form-label" > Subscription Price</label>
        <asp:TextBox ID="txtNewSubscriptionPrice" runat="server" CssClass="form-control"> </asp:TextBox>
              <br />  
                <label for="txtNewSubscriptionBilling" class="col-form-label"> Subscription Billing Time</label>
      
              <asp:DropDownList ID="ddlBilling" runat="server">
                  <asp:ListItem Value="/week"> Weekly </asp:ListItem>
                   <asp:ListItem Value="/mo"> Monthly </asp:ListItem>
                   <asp:ListItem Value="/bi-annually"> Bi Annually </asp:ListItem>
                   <asp:ListItem Value="/year"> Yearly </asp:ListItem>
              </asp:DropDownList>
              <br />
              <ucUpload:ImageUpload1 runat="server" ID="ImageUploadUC" />
               
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

