<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="ElectricityBillWebApp.AddBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title style="font-weight:bold;">Add Electricity Bill</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: #F2F2F2;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
        }

        form {
            background:  #edbbbb;
            margin-top: 30px;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0px 0px 15px rgba(0,0,0,0.2);
            width: 600px;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        input[type=text], input[type=number] {
            padding: 8px;
            margin: 5px 0 15px 41;
            border: 1px solid #ccc;
            border-radius: 5px;
            transition: 0.3s;
        }

        input[type=text]:focus, input[type=number]:focus {
            border-color: #2196F3;
            box-shadow: 0 0 5px #2196F3;
        }

        asp:Button {
            padding: 8px 15px;
            border-radius: 5px;
            background-color: #2196F3;
            color: white;
            border: none;
            cursor: pointer;
            transition: 0.3s;
        }

        asp:Button:hover {
            background-color: #0b7dda;
        }

        #lblResult {
            font-weight: bold;
            margin-top: 15px;
        }

        #gvBills tr:hover {
            background-color: #f1f1f1;
        }

        
    </style>

    <script type="text/javascript">
        function showBillMessage() {
            var lbl = document.getElementById('<%= lblResult.ClientID %>');
            lbl.style.color = "green";
            lbl.style.fontSize = "16px";
            lbl.style.transition = "all 0.5s";
            setTimeout(function () {
                lbl.style.fontSize = "12px";
            }, 800);
        }

        // Optional: Animate when button is clicked
        window.onload = function () {
            var btnCalc = document.getElementById('<%= btnCalculate.ClientID %>');
            btnCalc.onclick = function () {
                setTimeout(showBillMessage, 100);
            };
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <h2 style="font-weight:bold;">Add Electricity Bill</h2>
        <p style="font-weight:bold;">&nbsp;</p>

        Consumer No: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtConsumerNo" runat="server" Width="170px" ></asp:TextBox>
        <br />
        <br />

        Consumer Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"  Width="170px" ></asp:TextBox>
        <br />
        <br />

        Units Consumed:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txtUnits" runat="server" Width="170px" ></asp:TextBox>
        <br />
        <br />

        <asp:Button ID="btnCalculate" runat="server"
            text="Calculate & Save" OnClick="btnCalculate_Click" Height="44px" Width="182px" />

        <br />

        <br />
        <br />

        <asp:Label id="lblResult" runat="server" ForeColor="Green"></asp:Label>

        <br />

        <br />
        <br />
        Enter N: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:TextBox ID="txtN" runat="server" Width="170px" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Last N Bills" OnClick="btnRetrieve_Click" style="margin-left: 0px;" Height="44px" Width="182px" />

        <br />
        <br />

        <br />
        <br />
        <asp:GridView ID="gvBills" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>






        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <br />






    </form>
</body>
</html>
