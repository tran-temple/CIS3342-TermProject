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
                <img src="images/logo2.png" width="500" height="500" class="d-inline-block img-fluid" alt="Logo" />                                
            </div>            
        </div>
        <div class="col-lg-6 offset-lg-3 mt-2 border">
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
                <div class="col-md-10">
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblUserName_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Password: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtPassword" runat="server" ></asp:TextBox><br />
                    <asp:Label ID="lblPassword_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>First Name: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblFirstName_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>     
            <div class="row form-group">
                <div class="col">
                    <span>Last Name: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblLastName_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Email: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox><br />
                    <asp:Label ID="lblEmail_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Question 1: </span>
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlQuestion1" runat="server">
                        <asp:ListItem Value="-1" Selected="True">Select a question...</asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:Label ID="lblQuestion1_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Answer 1: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblAnswer1_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Question 2: </span>
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlQuestion2" runat="server">
                        <asp:ListItem Value="-1" Selected="True">Select a question...</asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:Label ID="lblQuestion2_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Answer 2: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblAnswer2_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Question 3: </span>
                </div>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddlQuestion3" runat="server">
                        <asp:ListItem Value="-1" Selected="True">Select a question...</asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:Label ID="lblQuestion3_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                    <span>Answer 3: </span>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="txtAnswer3" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblAnswer3_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row form-group">
                <div class="col">
                </div>
                <div class="col-md-10">
                    <asp:RadioButton ID="rdoCustomer" GroupName="UserType" runat="server" Text="Registerd Customer" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdoOwner" GroupName="UserType" runat="server" Text="Owner" /><br />
                    <asp:Label ID="lblUserType_Error" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>            
            <asp:Panel ID="pnlCustomerInfo" runat="server" >
                <div class="row form-group">
                    <div class="col">
                        <span>Address: </span>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />
                        <asp:Label ID="lblAddress_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col">
                        <span>City: </span>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><br />
                        <asp:Label ID="lblCity_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col">
                        <span>State: </span>
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="ddlState" runat="server">
                            <asp:ListItem Value="">Choose a state...</asp:ListItem>
                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                            <asp:ListItem Value="CA">California</asp:ListItem>
                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                            <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                            <asp:ListItem Value="DE">Delaware</asp:ListItem>
                            <asp:ListItem Value="FL">Florida</asp:ListItem>
                            <asp:ListItem Value="GA">Georgia</asp:ListItem>
                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                            <asp:ListItem Value="IL">Illinois</asp:ListItem>
                            <asp:ListItem Value="IN">Indiana</asp:ListItem>
                            <asp:ListItem Value="IA">Iowa</asp:ListItem>
                            <asp:ListItem Value="KS">Kansas</asp:ListItem>
                            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                            <asp:ListItem Value="ME">Maine</asp:ListItem>
                            <asp:ListItem Value="MD">Maryland</asp:ListItem>
                            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                            <asp:ListItem Value="MI">Michigan</asp:ListItem>
                            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                            <asp:ListItem Value="MO">Missouri</asp:ListItem>
                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                            <asp:ListItem Value="NY">New York</asp:ListItem>
                            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                            <asp:ListItem Value="OH">Ohio</asp:ListItem>
                            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                            <asp:ListItem Value="TX">Texas</asp:ListItem>
                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                            <asp:ListItem Value="VT">Vermont</asp:ListItem>
                            <asp:ListItem Value="VA">Virginia</asp:ListItem>
                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblState_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col">
                        <span>Zipcode: </span>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtZipcode" runat="server"></asp:TextBox><br />
                        <asp:Label ID="lblZipcode_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="col">
                        <span>Phone: </span>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox><br />
                        <asp:Label ID="lblPhone_Error" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
                </div>
            </asp:Panel>
            <div class="row form-group justify-content-center">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-secondary" OnClick="btnCancel_Click"/>&nbsp;&nbsp;
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn-primary" OnClick="btnRegister_Click"/>
            </div>            
        </div>
    </form>
    
</body>
</html>

