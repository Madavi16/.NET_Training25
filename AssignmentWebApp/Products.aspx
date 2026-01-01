<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="AssignmentWebApp.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Products </h2>
        <asp:DropDownList ID="ddlProducts" runat="server"
            AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            <asp:ListItem Text="Select" Value="0" />
            <asp:ListItem Text="Laptop" Value="Laptop" />
            <asp:ListItem Text="Mobile" Value="Mobile" />
            <asp:ListItem Text="Tablet" Value="Tablet" />
        </asp:DropDownList>
        <br />
        <br />


        <asp:Image ID="imgProduct" runat="server" Width="400px" Height="400px" />
        <br />
        <br />

        <asp:Button ID="btnPrice" runat="server"
            Text="Get Price" OnClick="btnPrice_Click" />
        <br />
        <br />

        <asp:Label ID="lblPrice" runat="server" ForeColor="Blue" />

        <div>
        </div>
    </form>
</body>
</html>
