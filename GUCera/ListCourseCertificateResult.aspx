<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCourseCertificateResult.aspx.cs" Inherits="GUCera.ListCourseCertificateResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="sid" HeaderText="Student ID" />
                    <asp:BoundField DataField="cid" HeaderText="Course ID" />
                    <asp:BoundField DataField="issueDate" HeaderText="Issue Date" />
                </Columns>
            </asp:GridView>
            
            <br />
        <asp:LinkButton ID="back" runat="server" OnClick="back_Click" >Go back</asp:LinkButton>
            <br />
            <br />
        <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
