<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TDView.aspx.cs" Inherits="RAsio_Project.View.TDView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" style="display:flex; flex-direction:row; gap:48px;">
        <asp:GridView ID="TransactionDetailGV" runat="server"
            AutoGenerateColumns="false"
            BorderColor="Transparent"
            HeaderStyle-HorizontalAlign="Left"
            Style=
            "
            padding: 4px;
            margin-top: 24px;
            border-radius: 8px 8px 0 0;
            background-color: rgba(255, 255, 255, 0.9);
            ">
            <Columns>
                <asp:BoundField 
                    HeaderStyle-Width="24px"
                    HeaderStyle-CssClass="grid-header-style"
                    ItemStyle-CssClass="grid-item-style"
                    DataField="StationeryName" HeaderText="ID" />

                <asp:BoundField 
                    HeaderStyle-Width="24px"
                    HeaderStyle-CssClass="grid-header-style"
                    ItemStyle-CssClass="grid-item-style"
                    DataField="StationeryPrice" HeaderText="Date" />

                <asp:BoundField
                    HeaderStyle-Width="128px"
                    HeaderStyle-CssClass="grid-header-style"
                    ItemStyle-CssClass="grid-item-style"
                    DataField="Quantity" HeaderText="Customer" />

            </Columns>
        </asp:GridView>
        
    </div>

</asp:Content>
