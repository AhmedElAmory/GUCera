<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineAssign.aspx.cs" Inherits="GUCera.DefineAssign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Course Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Assignment number"></asp:Label>
            &nbsp;<asp:TextBox ID="number" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Assignment Type"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" >
                <asp:ListItem Value="-1">Choose a type</asp:ListItem>
                <asp:ListItem>quiz</asp:ListItem>
                <asp:ListItem>project</asp:ListItem>
                <asp:ListItem>exam</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Full grade"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="grade" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Assignment weight"></asp:Label>
            &nbsp;<asp:TextBox ID="weight" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="deadline"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="deadlinee" runat="server" TextMode="Date" placeholder="mm/dd/yyyy"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="content"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="content" runat="server" Width="484px" MaxLength="200"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addAssign" runat="server" Text="add the assignment" OnClick="addAssign_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="returnTohome" runat="server" OnClick="returnTohome_Click">Return to home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
