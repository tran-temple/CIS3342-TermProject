<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="CIS3342_TermProject.ForgetPassword" %>

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

    <title>Forget Password</title>
</head>
<body class="bg-light">
    <script>
        function EnterEvent(e) {
            if (e.keyCode == 13) {
                __doPostBack('<%=btnUserName.UniqueID%>', "");
            }
        }
    </script>
    <form id="form1" runat="server">
        <div class="col-lg-4 offset-lg-4 mt-3">
            <div class="row form-group justify-content-center mt-2">
                <img id="logo" src="images/logo3.png" width="350" height="350" class="d-inline-block img-fluid shadow" alt="Logo" />                
            </div>            
        </div>        
        <div class="col-lg-4 offset-lg-4 mt-2 border bg-white shadow">            
            <div class="row form-group justify-content-center mt-2">
                <h2 class="font-weight-bold">Forget Password</h2>                
            </div>
            <div class="row form-group justify-content-center ml-1">
                <asp:Label ID="lblGeneral_Error" runat="server" CssClass="text-danger mt-2"></asp:Label><br />
            </div>
            <div class="row form-group">       
                <div class="col">
                    <span>Please input Username: </span>
                </div>
                <div class="col">
                    <asp:TextBox ID="txtUsername" runat="server" onkeypress="return EnterEvent(event)"></asp:TextBox><br />
                    <asp:Label ID="lblUserName_Error" runat="server" CssClass="text-danger"></asp:Label>
                    <asp:Button ID="btnUserName" OnClick="btnUserName_Click" runat="server" style="display:none" Text="Button" />
                </div>
            </div>
            <div class="row form-group">       
                <div class="col">
                    <span>Your security Question: </span>
                </div>
                <div class="col">
                    <asp:Label ID="lblQuestion" runat="server" ></asp:Label>
                    <asp:HiddenField ID="hidQuestionId" runat="server" />
                </div>
            </div>
            <div class="row form-group">       
                <div class="col">
                    <span>Your security Answer: </span>
                </div>
                <div class="col">
                    <asp:TextBox ID="txtAnswer" runat="server" ></asp:TextBox><br />
                    <asp:Label ID="lblAnswer_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">                
                <div class="col text-center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-secondary" OnClick="btnCancel_Click"/> &nbsp;                                   
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-primary" OnClick="btnSubmit_Click"/>
                </div>                
            </div>            
        </div>
    </form>
</body>
</html>
