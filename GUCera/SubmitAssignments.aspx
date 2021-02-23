<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitAssignments.aspx.cs" Inherits="GUCera.SubmitAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please enter the Assignment information:<br />
            <br />
            Assignment type:<asp:DropDownList ID="assignmentType" runat="server">
                <asp:ListItem>quiz</asp:ListItem>
                <asp:ListItem>exam</asp:ListItem>
                <asp:ListItem>project</asp:ListItem>
            </asp:DropDownList>
            <br />
            Assignment number:<asp:TextBox ID="assignmentNumber" runat="server"></asp:TextBox>
            <br />
            Course ID:<asp:TextBox ID="courseID" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="submitAssignment" runat="server" Text="Submit Assignment" OnClick="submitAssignment_Click" />


            <br />
            <br />


            <asp:Label ID="message" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
