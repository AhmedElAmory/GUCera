<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorHome.aspx.cs" Inherits="GUCera.InstructorHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome<br />
            <br />
            <asp:Button ID="LinkButton1" runat="server" Text="Add mobile phone" OnClick="addMobile_Click" />
            <br />
            <asp:Button ID="addCourse" runat="server" Text="Add a course" OnClick="addCourse_Click" />
            <br />
            <asp:Button ID="addContentDescription" runat="server" Text="Add a content  and description to a course you added" OnClick="addContentDescription_Click"  />
            <br />
            <asp:Button ID="addAssignment" runat="server" Text="Define an assignment of a course" OnClick="addAssignment_Click" />
            <br />
            <asp:Button ID="viewAssign" runat="server" Text="View assignments submitted by students"  OnClick="viewAssign_Click"/>
            <br />
            <asp:Button ID="grading" runat="server" Text="Grade assignments"  OnClick="grading_Click" />
            <br />
            <asp:Button ID="viewFeedback" runat="server" Text="View feedbacks"  OnClick="viewFeedback_Click"/>
            <br />
            
            <asp:Button ID="certificate" runat="server" Text="Issue certificate" OnClick="certificate_Click" />
        </div>
    </form>
</body>
</html>
