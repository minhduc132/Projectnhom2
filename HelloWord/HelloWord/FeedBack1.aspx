<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedBack1.aspx.cs" Inherits="HelloWord.FeedBack1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="TextBox1" runat="server" Height="42px" Width="339px">
    </asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Width="334px"></asp:TextBox>
    <br />

    <input id="Text1" type="text" /><br />

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />

    </asp:Content>
