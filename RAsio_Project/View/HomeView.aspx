<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="HomeView.aspx.cs" Inherits="RAsio_Project.View.HomeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <asp:PlaceHolder ID="AdminInsertLink" runat="server" />

    <div runat="server" style="display:flex; flex-direction:row; gap:48px;">
        <asp:GridView ID="StationeryGV" runat="server"
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
                    DataField="StationeryID" HeaderText="ID" />

                <asp:BoundField
                    HeaderStyle-Width="128px"
                    HeaderStyle-CssClass="grid-header-style"
                    ItemStyle-CssClass="grid-item-style"
                    DataField="StationeryName" HeaderText="Name" />

                <asp:BoundField 
                    HeaderStyle-Width="524px"
                    HeaderStyle-CssClass="grid-header-style"
                    ItemStyle-CssClass="grid-item-style" 
                    DataField="StationeryPrice" HeaderText="Price" />

                <asp:TemplateField 
                    HeaderStyle-CssClass="grid-header-style"
                    HeaderText="Update Stationery"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button 
                            CssClass="grid-button" OnClick="UpdateStationeryBtn_Click" 
                            ID="UpdateStationeryBtn" runat="server" Text="Update"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField 
                    HeaderStyle-CssClass="grid-header-style"
                    HeaderText="Delete Stationery"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button 
                            CssClass="grid-button" OnClick="DeleteStationeryBtn_Click" 
                            ID="DeleteStationeryBtn" runat="server" Text="Delete"/>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField 
                    HeaderStyle-CssClass="grid-header-style"
                    HeaderText="Detail"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button 
                            CssClass="grid-button" OnClick="DetailStationeryBtn_Click" 
                            ID="DetailStationeryBtn" runat="server" Text="Detail"/>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        
    </div>

</asp:Content>
