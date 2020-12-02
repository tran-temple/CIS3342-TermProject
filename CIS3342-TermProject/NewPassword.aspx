<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPassword.aspx.cs" Inherits="CIS3342_TermProject.NewPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Montserrat:wght@500;700&display=swap" />    
    
    <link rel="stylesheet" href="styles/styles.css" />

    <title>New Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-4 offset-lg-4 mt-2">
            <div class="row form-group justify-content-center mt-2">
                <img src="images/logo2.png" width="500" height="500" class="d-inline-block img-fluid" alt="Logo" />                
            </div>            
        </div>        
        <div class="col-lg-4 offset-lg-4 mt-2 border">            
            <div class="row form-group justify-content-center mt-2">
                <h2 class="font-weight-bold">Create New Password</h2>                
            </div>
            <div class="row form-group justify-content-center ml-1">
                <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger mt-2"></asp:Label><br />
            </div>
            <div class="row form-group">       
                <div class="col">
                    <span>Username: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="disabled"></asp:TextBox><br />
                </div>
            </div>            
            <div class="row form-group">       
                <div class="col">
                    <span>New Password: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblNewPassword_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">       
                <div class="col">
                    <span>Confirm New Password: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblConfirmPassword_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">                
                <div class="col text-center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-primary" OnClick="btnSubmit_Click"/>
                </div>                
            </div>            
        </div>
    </form>
</body>
</html>
