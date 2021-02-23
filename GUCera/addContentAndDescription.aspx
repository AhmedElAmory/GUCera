<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addContentAndDescription.aspx.cs" Inherits="GUCera.addContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label6" runat="server" Text="Course Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Content"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="content" runat="server" Width="575px" MaxLength="200"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Description"></asp:Label>
&nbsp;&nbsp;
            <br />
            <asp:TextBox ID="description" runat="server" Height="91px" Width="583px" MaxLength="200"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addingCourse" runat="server" Text="submit" OnClick="addingCourse_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="returnTohome" runat="server" OnClick="returnTohome_Click">Return to home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
