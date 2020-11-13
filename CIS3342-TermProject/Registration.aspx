<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CIS3342_TermProject.Registration" %>

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

    <title>Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-4 offset-lg-4 mt-2">
            <div class="row form-group justify-content-center mt-2">
                <img src="images/logo.jpg" width="300" height="150" class="d-inline-block img-fluid" alt="Logo" />                
            </div>            
        </div>
        <div class="col-lg-4 offset-lg-4 mt-2 border">
            <div class="row form-group justify-content-center mt-2">
                <h2 class="font-weight-bold">Registration</h2>
            </div>
            <div class="row form-group justify-content-center">
                <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger"></asp:Label>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Username: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblUserName_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>       
            <div class="row form-group">
                <div class="col">
                    <span>First Name: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblFirstName_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>     
            <div class="row form-group">
                <div class="col">
                    <span>Last Name: </span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblLastNameID_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-12">
                    <asp:RadioButton ID="rdoCustomer" GroupName="UserType" runat="server" Text="Registerd Customer" /><br />
                    <asp:RadioButton ID="rdoOwner" GroupName="UserType" runat="server" Text="Owner" /><br />
                    <asp:Label ID="lblUserType_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group justify-content-center">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-secondary" OnClick="btnCancel_Click"/>&nbsp;&nbsp;
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-primary" OnClick="btnRegister_Click"/>
            </div>            
        </div>
    </form>
</body>
</html>
