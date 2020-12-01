<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="CIS3342_TermProject.PurchaseHistory" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="BodyPlaceHolder" runat="server">


   

    <div class="col-lg-8 offset-lg-2 mt-3 shadow border">        
        <!-- Display list of orders belong to one customer -->                
        <div class="m-3 form-group">            
            <asp:Panel ID="pnlProduct" runat="server">
                <div class="row form-group justify-content-center">
                    <asp:Label ID="lblHeading" runat="server" Text="Purchase History" CssClass="h3 font-weight-bold"></asp:Label>
                </div>
                <div class="row form-group">
                    <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row form-group">
                  
                    <div class="col-md-8">
                        <asp:Label ID="lblDisplay" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>     
                
                    <asp:GridView ID="gvHistory" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="466px">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </asp:Panel>
        
        </div>
    </div>    
</asp:Content>
