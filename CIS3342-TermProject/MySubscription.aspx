<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MySubscription.aspx.cs" Inherits="CIS3342_TermProject.MySubscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

    .title {
         text-align: center;
    font-size: 40px;
    color: black;
    margin-top: 10px;
    padding-top: 20px;
    padding-bottom: 20px;
    margin-bottom: 10px;
    }

        </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <asp:Label ID="lblTitle" runat="server" CssClass="title"> Current Subscription </asp:Label>
    <asp:Panel ID="panelHasSubscription" runat="server">
        <div class="card text-center">
  <div class="card-header">
    <h4 class="my-0 font-weight-normal"> <asp:Label ID="lblSubscriptionName" runat="server"  Text=""> </asp:Label></h4>
  </div>
  <div class="card-body">

       <asp:Image ID="imgSubscription" runat="server" Height="288px" Width="279px" />
                <h1 class="card-title pricing-card-title">  <asp:Label ID="lblSubscriptionPrice" runat="server"  Text="$99.99"> </asp:Label><small class="text-muted"> <asp:Label ID="lblSubscriptionBillingTime" runat="server"  Text="/mo">    </asp:Label>  </small></h1>
    <p class="card-text">
        
        <asp:Label ID="lblSubscriptionDescription" runat="server" Text=""> </asp:Label></p>
 <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">Cancel</button>
      <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">Upgrade / Downgrade</button>
     
  </div>
  <div class="card-footer text-muted">
   
  </div>
</div>

  
   
           <div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
    
        <h4 class="modal-title">Cancel Subscription</h4>
      </div>
      <div class="modal-body">
          
         Are you sure you want to cancel your subscription?
          <asp:Button type="button" class="btn btn-success align-content-center" ID="btnAdd" runat="server" Text="Yes" onclick="btnYesCancel_Click"></asp:Button>
          <button type="button" class="btn btn-danger align-content-center " data-dismiss="modal">No</button>
    <br /><br />
  
          </div>
       
   
      <div class="modal-footer">
          <button type="button" class="btn btn-primary" data-dismiss="modal">Cancel</button>
              
      </div>
    </div>

  </div>
</div>



        
           <div id="myModal2" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
    
        <h4 class="modal-title">Upgrade or Downgrade</h4>
      </div>
      <div class="modal-body">
          
      Choose New Subscription Type:<br />
          <asp:DropDownList ID="ddlSubscriptionTypes" runat="server" CssClass="align-content-center"></asp:DropDownList>


          <br />

   
       
    <br /><br />
  
          </div>
       
   
      <div class="modal-footer">
                 <asp:Button type="button" class="btn btn-success align-right" ID="btnConfirmClick" runat="server" Text="Confirm" onclick="btnConfirm_Click"></asp:Button>
          <button type="button" class="btn btn-primary align-left" data-dismiss="modal">Cancel</button>
              
      </div>
    </div>

  </div>
</div>
  </asp:Panel>


    <asp:Panel ID="panelNoSubscription" runat="server">

        <asp:Label ID="lblNoSubscription" runat="server"> You currently have no subscription. You can find our subscription options <a href="HomePage.aspx"> here </a> </asp:Label>
    </asp:Panel>




</asp:Content>
