<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFeedbackToCourse.aspx.cs" Inherits="GUCera.AddFeedbackToCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add Feedback to Course:<br />
            <br />
            Course ID:<asp:TextBox ID="courseID" runat="server"></asp:TextBox>
            <br />
            <br />
            Feedback:<br />
            <asp:TextBox ID="feedback" runat="server" Height="100px" Width="939px" MaxLength="100"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="submitFeedback" runat="server" Text="Submit Feedback" OnClick="submitFeedback_Click" />
            <br />
            <br />
            <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="home" runat="server" OnClick="home_Click">Return to Home</asp:LinkButton>
        </div>
    </form>
</body>
</html>
