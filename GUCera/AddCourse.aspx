<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="GUCera.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="direction: ltr">
            <asp:Label ID="Label1" runat="server" Text="Course Name"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="cname" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Credithours"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="hours" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="price" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addingCourse" runat="server" Text="submit" OnClick="addingCourse_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="returnTohome" runat="server" OnClick="returnTohome_Click">Return to home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
