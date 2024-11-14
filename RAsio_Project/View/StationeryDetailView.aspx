<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="StationeryDetailView.aspx.cs" Inherits="RAsio_Project.View.StationeryDetailView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="center-container">
        <div class="outer-container">
            <asp:Label ID="idLabel" runat="server" Text="" CssClass="form-label"></asp:Label>
            <br />
            <asp:Label ID="nameLabel" runat="server" Text="Name" CssClass="form-label"></asp:Label>
            <br />
            <asp:Label ID="priceLabel" runat="server" Text="Price" CssClass="form-label"></asp:Label>
            <br />
            <asp:Label ID="quantityLabel" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="quantityTB" runat="server" TextMode="Number"></asp:TextBox>
            <br /><br />
            <asp:Button ID="orderBtn" runat="server" Text="Order" CssClass="form-button" OnClick="orderBtn_Click"/>
            <br />
            <asp:Label ID="errorMsg" runat="server" Text="" CssClass="form-errorMsg"></asp:Label>
        </div>
    </div>
</asp:Content>
