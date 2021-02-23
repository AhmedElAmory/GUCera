<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAssignmentOfStudents.aspx.cs" Inherits="GUCera.viewAssignmentOfStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="Label1" runat="server" Text="Course ID"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>

            <br />
            <asp:Button ID="viewAssignment" runat="server" Text="View" OnClick="viewAssignment_Click" />

        &nbsp;&nbsp;
            <asp:LinkButton ID="returnTohome" runat="server" OnClick="returnTohome_Click">Return to home</asp:LinkButton>

            <br />
            <asp:GridView ID="gridView" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>
