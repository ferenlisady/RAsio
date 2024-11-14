<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="StationeryInsertView.aspx.cs" Inherits="RAsio_Project.View.StationeryInsertView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="center-container">
        <div class="outer-container">
            <asp:Label ID="Label2" runat="server" Text="Name" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="nameTB" runat="server" CssClass="form-textbox"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Price" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="priceTB" runat="server" CssClass="form-textbox"></asp:TextBox>
            <br />
            <asp:Button ID="insertBtn" runat="server" Text="Update" CssClass="form-button" OnClick="insertBtn_Click"/>
            <br />
            <asp:Label ID="errorMsg" runat="server" Text="" CssClass="form-errorMsg"></asp:Label>
        </div>
    </div>
</asp:Content>
