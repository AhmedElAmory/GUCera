<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCourseCertificates.aspx.cs" Inherits="GUCera.ListCourseCertificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Show Course Certificate:<br />
            <br />
            Enter Course ID:<asp:TextBox ID="courseID" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="showCertificate" runat="server" Text="Show Certificate" OnClick="showCertificate_Click" />
            <br />
            <br />
            <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
