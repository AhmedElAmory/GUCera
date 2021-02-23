<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewFeedbacks.aspx.cs" Inherits="GUCera.viewFeedbacks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Course Id&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="viewAssignment" runat="server" Text="View" OnClick="viewAssignment_Click" />

        &nbsp;&nbsp;
            <asp:LinkButton ID="returnTohome" runat="server" OnClick="returnTohome_Click">Return to home</asp:LinkButton>

            <br />
            <asp:GridView ID="gridView" runat="server" OnSelectedIndexChanged="gridView_SelectedIndexChanged"></asp:GridView>

        </div>
    </form>
</body>
</html>
