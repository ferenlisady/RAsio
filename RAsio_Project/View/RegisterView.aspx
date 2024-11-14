<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavigationBar.Master" AutoEventWireup="true" CodeBehind="RegisterView.aspx.cs" Inherits="RAsio_Project.View.RegisterView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="../Master/StyleMaster.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br />
    <div style="display:flex; flex-direction: column;">

        <div style="margin-bottom:10px;">
            <asp:Label runat="server" Text="Username" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="UsernameTB" CssClass="form-textbox"  runat="server"></asp:TextBox>
        </div>

        <div style="margin-bottom:10px;">
            <asp:Label runat="server" Text="Date Of Birth" CssClass="form-label"></asp:Label>
            <input type="date" runat="server" id="UserDOB" class="form-date-input" name="birthdate" />
        </div>

        <div style="margin-bottom:10px;">
            <asp:Label runat="server" Text="Gender" CssClass="form-label"></asp:Label>
            <asp:RadioButtonList ID="GenderRBList" RepeatDirection="Horizontal" CssClass="form-radiobutton" runat="server">
                <asp:ListItem Selected="True">Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div style="margin-bottom:10px;">
            <asp:Label runat="server" Text="Address" CssClass="form-label"></asp:Label>
            <textarea id="UserAddressTA" runat="server" class="form-textarea" rows="3"></textarea>
        </div>

        <div style="margin-bottom:10px;">
            <asp:Label runat="server" Text="Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="UserPasswordTB" runat="server" type="Password" CssClass="form-textbox"></asp:TextBox>
        </div>

        <div style="margin-bottom:10px;">
            <asp:Label runat="server" Text="Phone Number" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="PhoneNumberTB" runat="server" CssClass="form-textbox"></asp:TextBox>
        </div>

        <div style="margin-bottom:10px;">
            <br>
            <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass="form-button" OnClick="registerBtn_Click" />
        </div>
        <br />
        <asp:Label ID="errorMsg" runat="server" Text="" CssClass="form-errorMsg"></asp:Label>

    </div>

</asp:Content>
