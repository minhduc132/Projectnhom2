<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HelloWord.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


       <p>
           <br />
           <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       </p>
        <p>
             <asp:RequiredFieldValidator ControltoValidate="TextBox1"
                Errormessage="Input textbox1"
                runat="server"
                Display="Static"/>

        </p>

         <p >
           <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
       </p>
        <p>
           <asp:RequiredFieldValidator ControltoValidate="TextBox2"
                Errormessage="Input textbox2"
                runat="server"
                Display="Static"/>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button"
                Onclick="Button1_click" />
        </p>
   
</asp:Content>
