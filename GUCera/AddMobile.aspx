<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMobile.aspx.cs" Inherits="GUCera.AddMobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please enter the mobile number:<br />
            <asp:TextBox ID="mobileNumber" runat="server" MaxLength="20"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addMobileNumber" runat="server" Text="Add the mobile number" OnClick="addMobileNumber_Click" />
            <br />
            <br />
            <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>    
        </div>
    </form>
</body>
</html>
