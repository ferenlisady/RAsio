<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="CartUpdateView.aspx.cs" Inherits="RAsio_Project.View.CartUpdateView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="center-container">
        <div class="outer-container">
            <asp:Label ID="nameLB" runat="server" Text="" CssClass="form-label"></asp:Label>
            <br />
            <asp:Label ID="priceLB" runat="server" Text="" CssClass="form-label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Quantity" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="quantityTB" runat="server" CssClass="form-textbox" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="updateBtn" runat="server" Text="Update" CssClass="form-button" OnClick="updateBtn_Click"/>
            <br />
            <asp:Label ID="errorMsg" runat="server" Text="" CssClass="form-errorMsg"></asp:Label>
        </div>
    </div>
</asp:Content>
