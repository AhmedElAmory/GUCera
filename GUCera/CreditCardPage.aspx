<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCardPage.aspx.cs" Inherits="GUCera_Website.CreditCardPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="StudentHome.aspx">
                Home
            </a>
            <br />
            <br />
            <strong>Add credit card details:</strong><br />
            <br />
            Credit Card Number:<br />
            <asp:TextBox ID="num" runat="server" MaxLength="15" ToolTip="Max 15 characters"></asp:TextBox>
            <br />
            Card Holder Name:<br />
            <asp:TextBox ID="name" runat="server" MaxLength="16" ToolTip="Max 16 characters"></asp:TextBox>
            <br />
            Expiry date:<br />
            <asp:TextBox ID="date" runat="server" TextMode="Date" placeholder="dd/mm/yyyy"></asp:TextBox>
            <br />
            CVV:<br />
            <asp:TextBox ID="cvv" runat="server" MaxLength="3" ToolTip="Max 3 characters"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="AddCC" />
        </div>
    </form>
</body>
</html>
