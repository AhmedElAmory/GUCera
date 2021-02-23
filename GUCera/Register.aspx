<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUCera.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please enter your information:<br />
            <br />
            First Name:
            <asp:TextBox ID="firstName" runat="server" MaxLength="10"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Last Name:<asp:TextBox ID="lastName" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            Password:<asp:TextBox ID="password" runat="server" MaxLength="10" ></asp:TextBox>
            <br />
            <br />
            Email:<asp:TextBox ID="email" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            Gender:<br />
            <asp:RadioButtonList ID="Gender" runat="server" >
                <asp:ListItem Value="0" Selected="True">Male</asp:ListItem>
                <asp:ListItem Value="1">Female</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            Address:<asp:TextBox ID="address" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="registerAsStudentButton" runat="server" Text="Register as Student" OnClick="registerAsStudent" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="registerAsInstructorButton" runat="server" Text="Register as Instructor" OnClick="registerAsInstructor"/>
            <br />
            <br />
            <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="return to Login"  Visible="false" OnClick="Button1_Click"/>
            <br />
        </div>
    </form>
</body>
</html>
