<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="AssignmentWebApp.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Validation Page</title>
    <style>
    body {
        font-family: Arial;
        background-color: #f4f4f4;
    }

    h2 {
        color: darkblue;
    }

    input, button {
        padding: 6px;
        margin: 5px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">

        <h2> User Validation Form </h2>
        
        <br />
        <br />
        <br />
        
        Name : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="txtName" runat="server"
            ErrorMessage="Name Required" ForeColor="Red" />
        <br /><br />

        Family Name: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="txtFamily" runat="server"
            errorMessage="Family name Required" ForeColor="Red" />
        <br /><br />

        Address : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ControlToValidate="txtAddress" runat="server"
            validationExpression=".{2,}" ErrorMessage="Minimum 2 Characters"
            forecolor="Red" />
                <br /><br />

        City: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ControlToValidate="txtCity" runat="server"
            validationExpression=".{2,}" ErrorMessage="Minimum 2 Characters"
            forecolor="Red" />
        <br /><br />

        Zip Code: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ControlToValidate="txtZip" runat="server"
            validationExpression="\d{5}" ErrorMessage="5 Digits Zip Code"
            forecolor="Red" />
        <br /><br />

        Phone : &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ControlToValidate="txtPhone" runat="server"
            validationExpression="(\d{2}|\d{3})-\d{7}"
            errorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
            forecolor="Red" />
        <br /><br />

        Email: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server"
            validationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            errorMessage="Invalid Email"
            foreColor="Red" />
        <br />
        <br /><br />

        <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
        <br />
        <br />
        <br />

        <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>

       
    </form>
</body>
</html>
