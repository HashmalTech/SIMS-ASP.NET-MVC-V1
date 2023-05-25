<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SIMS.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblusername" runat="server" Text="[username]"></asp:Label><asp:TextBox ID="txtusername" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblpassword" runat="server" Text="[password]"></asp:Label><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblvalid" runat="server" Text="[valid]"></asp:Label><br />
    <asp:Button ID="BtnLogin" runat="server" Text="[Login]" OnClick="BtnLogin_Click" />
</asp:Content>
