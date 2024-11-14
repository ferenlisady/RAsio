<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="RAsio_Project.View.LoginView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="display:flex; flex-direction: column;">

    <div style="margin-bottom:10px;">
        <asp:Label runat="server" Text="Username" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="UsernameTB" CssClass="form-textbox"  runat="server"></asp:TextBox>
    </div>

    <div style="margin-bottom:10px;">
        <asp:Label runat="server" Text="Password" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="UserPasswordTB" runat="server" type="Password" CssClass="form-textbox"></asp:TextBox>
    </div>
        
    <asp:CheckBox ID="RemembermeCB" Text="Remember Me" runat="server" CssClass="form-label" />
    <div style="margin-bottom:10px;">
        <br>
        <asp:Button ID="loginBtn" runat="server" Text="Login" CssClass="form-button" OnClick="loginBtn_Click" />
    </div>
    <br />
    <asp:Label ID="errorMsg" runat="server" Text="" CssClass="form-errorMsg"></asp:Label>

</div>

</asp:Content>
