<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="certificate.aspx.cs" Inherits="GUCera.certificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Course Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Student ID"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="sid" runat="server"></asp:TextBox>
            <br />
            Date of issue&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="date" runat="server" TextMode="Date" placeholder="mm/dd/yyyy"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Issuecertificate" runat="server" Text="Issue" OnClick="Issuecertificate_Click" style="height: 29px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="returnTohome" runat="server" OnClick="returnTohome_Click">Return to home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
