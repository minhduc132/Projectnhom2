<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SqlDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" Width="254px" />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="240px" OnTextChanged="TextBox1_TextChanged" Width="285px"></asp:TextBox>
    </form>
</body>
</html>
