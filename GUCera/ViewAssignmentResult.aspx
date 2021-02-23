<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignmentResult.aspx.cs" Inherits="GUCera.ViewAssignmentResult" %>

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
                    <asp:BoundField DataField="cid" HeaderText="Course ID" />
                    <asp:BoundField DataField="number" HeaderText="Number" />
                    <asp:BoundField DataField="type" HeaderText="Type" />
                    <asp:BoundField DataField="fullGrade" HeaderText="Full Grade" />
                    <asp:BoundField DataField="weight" HeaderText="Weight" />
                    <asp:BoundField DataField="deadline" HeaderText="Deadline" />
                    <asp:BoundField DataField="content" HeaderText="Content" />
                </Columns>
            </asp:GridView>


        </div>
        <br />
        <asp:LinkButton ID="back" runat="server" OnClick="back_Click" >Go back</asp:LinkButton>
            <br />
        <br />
        <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
    </form>
</body>
</html>
