<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignments.aspx.cs" Inherits="GUCera.ViewAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Enter the course number to view its assignments:  <asp:TextBox ID="viewAssignmentsCourseNumber" runat="server" Height="16px"></asp:TextBox>
             <br />
            <br />
            <asp:Button ID="viewAssignmentsButton" runat="server" Text="View Assignments" OnClick="viewAssignmentsButton_Click" />
             <br />
            <br />
            <asp:Label ID="viewAssignError" runat="server" Text="" ForeColor="Red"></asp:Label>
             <br />
            <br />
        <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
