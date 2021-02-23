<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please Login<br />
            <br />
            ID:<br />
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="Password" runat="server" MaxLength="20"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="signin" runat="server" OnClick="login" Text="Login" />
            <br />
            <br />
            <asp:Button ID="register" runat="server" OnClick="register_Click" Text="Register a new account" />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
