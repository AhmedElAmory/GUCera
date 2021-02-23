<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PromoCodePage.aspx.cs" Inherits="GUCera_Website.PromoCodePage" %>

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
            <strong>Your promo codes:<br />
            <br />
            </strong>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="code" HeaderText="Code" />
                    <asp:BoundField DataField="isuueDate" HeaderText="Issue Date" />
                    <asp:BoundField DataField="expiryDate" HeaderText="Expiry Date" />
                    <asp:BoundField DataField="discount" HeaderText="Discount" />
                    <asp:BoundField DataField="adminId" HeaderText="Admin ID" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
