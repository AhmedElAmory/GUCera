<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHome.aspx.cs" Inherits="GUCera.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Student Home Page<br />
            <br />
            <asp:Button ID="addMobile" runat="server" Text="Add a new Mobile Number" OnClick="addMobile_Click" />
            <br />
            <br />
            Student Part one
            <br />

             <br />
            <asp:Button ID="Button1" runat="server" Text="View Profile" OnClick="ViewProfile" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="View Available Courses"  OnClick="ViewCourses" />
            (Enroll through here)<br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Add Credit Card" OnClick="CreditCard" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="View Promo Code"  OnClick="ViewPromoCode" />
            <br />
            <br />
            <br />
            Student Part Two<br />
            <br />
            <asp:Button ID="viewAssignments" runat="server" Text="View Assignments" OnClick="viewAssignments_Click" />
            <br />
            <br />
            <asp:Button ID="submitAssignments" runat="server" Text="Submit Assignments" OnClick="submitAssignments_Click" />
            <br />
            <br />
            <asp:Button ID="viewAssignmentGrade" runat="server" Text="View Assignment Grade" OnClick="viewAssignmentGrade_Click" />
            <br />
            <br />
            <asp:Button ID="addFeedbackToCourse" runat="server" Text="Add Feedback to Course" OnClick="addFeedbackToCourse_Click" />
            <br />
            <br />
            <asp:Button ID="listCourseCertificates" runat="server" Text="List Course Certificates" OnClick="listCourseCertificates_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
