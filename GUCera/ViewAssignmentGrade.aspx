<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignmentGrade.aspx.cs" Inherits="GUCera.ViewAssignmentGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            View the assignment grade:<br />
            <br />
            Assignment number:<asp:TextBox ID="assignmentNumber" runat="server"></asp:TextBox>
            <br />
            <br />
            Assignment type:<asp:DropDownList ID="assignmentType" runat="server">
                <asp:ListItem>quiz</asp:ListItem>
                <asp:ListItem>exam</asp:ListItem>
                <asp:ListItem>project</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Course ID:<asp:TextBox ID="courseID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="checkGrade" runat="server" Text="Check Grade" OnClick="checkGrade_Click" />
            <br />
            <br />
            The Grade is:<asp:Label ID="grade" runat="server" Text="" ForeColor="Red"></asp:Label>

            <br />
            <br />
            <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
