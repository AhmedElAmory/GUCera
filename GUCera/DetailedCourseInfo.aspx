<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailedCourseInfo.aspx.cs" Inherits="GUCera_Website.DetailedCourseInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href ="Courses.aspx">
                Back
            </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="StudentHome.aspx">
                Home
            </a>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enroll In This Course" OnClick="Enroll" />
            <br />
            <strong>Please pick the instructor you wish to take this course with:<br />
            </strong>
            <asp:TextBox ID="instructor" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Course ID"  />
                    <asp:BoundField DataField="creditHours" HeaderText="Credit Hours" />
                    <asp:BoundField DataField="name" HeaderText="Course Name" />
                    <asp:BoundField DataField="courseDescription" HeaderText="Course Description" />
                    <asp:BoundField DataField="price" HeaderText="Price" />
                    <asp:BoundField DataField="content" HeaderText="Content" />
                    <asp:BoundField DataField="adminId" HeaderText="Admin ID" />
                    <asp:BoundField DataField="instructorId" HeaderText="Instructor ID" />
                    <asp:BoundField DataField="accepted" HeaderText="Accepted" />
                    <asp:BoundField DataField="firstName" HeaderText="Instructor First Name" />
                    <asp:BoundField DataField="lastName" HeaderText="Instructor Last Name" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
