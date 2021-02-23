<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="GUCera_Website.Courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="StudentHome.aspx">
                Home
            </a>
            <br />
            <br />
            <strong>Enter course ID to view detailed info and enroll:<br />
            <asp:TextBox ID="courseid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="View" OnClick="ViewDetailedInfo" />
            <br />
            <br />
            <hr />
            <br />
            Available Courses:<br />
            </strong>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Course Name" />     
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
