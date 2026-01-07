<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectricityProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title style="font-weight:bold;" >Admin Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(to right, #4CAF50, #81C784);
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form {
            background: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 0px 15px rgba(0,0,0,0.3);
            text-align: center;
            width: 350px;
        }

        h2 {
            color: #333;
            margin-bottom: 20px;
        }

        input[type=text], input[type=password], input[type=submit], .aspTextBox {
            padding: 5px;
            margin: 5px 0;
            border-radius: 3px;
            border: 1px solid #ccc;
            transition: 0.3s;
        }

        input[type=text]:focus, input[type=password]:focus {
            border-color: #4CAF50;
            box-shadow: 0 0 5px #4CAF50;
        }

        asp:Button {
            cursor: pointer;
        }

        #lblMsg {
            font-weight: bold;
        }

    </style>

    <script type="text/javascript">
        window.onload = function () {
            alert("Welcome Admin! Please login to continue.");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       
        <h2 style="font-weight:bold;">Admin Login</h2>

        <asp:Label ID="lblUser" runat="server" Text="Username: "></asp:Label>
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="lblPass" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Height="44px" Width="75px" />
        <br />
        <br />

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>











    </form>
</body>
</html>
