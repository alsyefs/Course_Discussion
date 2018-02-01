<%@ Page Title="Entries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entries.aspx.cs" Inherits="Course_Discussion.Accounts.Intermediate.Entries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <div class="navbar navbar-inverse navbar-fixed-top" style=" background-color:#172E13; font-size:medium; font-weight: 700;">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <%--<a class="navbar-brand" runat="server" href="~/">Course Discussion</a>--%>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/Accounts/Intermediate/Home">Home</a></li>
                        <li><a runat="server" href="~/Accounts/Intermediate/About">About</a></li>
                        <li><a runat="server" href="~/Accounts/Intermediate/Contact">Contact</a></li>
                        <li><a runat="server" href="~/Accounts/Intermediate/Help" style ="background-color:blue; color:white">Help</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">                 
                        <li><a runat="server" href="~/Accounts/Intermediate/Account">Account</a></li>
                        <li><a runat="server" href="~/Logout">Logout</a></li>
                    </ul>
                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    
    <asp:Label ID="lblHeader" runat="server" Text="Label" BackColor="#CCCCFF" BorderColor="#CCCCFF" BorderStyle="Solid" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label> 
    <br />
    <asp:Label ID="lblEntry" runat="server" Text="Label" Visible="False" Font-Size="Medium"></asp:Label>
    <br />
    
    <style>.content { min-width:100%; }</style>
    <asp:TextBox ID="txtAddEntity" runat="server" Height="130px" Width="959px" TextMode="MultiLine" CssClass="content"></asp:TextBox>
    <br /> <br />
    <asp:FileUpload ID="FileUpload1" runat="server" Visible="False" class="btn btn-primary"/> 
    &nbsp;
    <br />
    <asp:Button ID="btnAddEntry" runat="server" Text="Add New Entry" Height="37px" Width="169px" OnClick="btnAddEntry_Click" BackColor="Green" Font-Bold="True" Font-Size="Medium" class="btn btn-primary"/>
    &nbsp;&nbsp;
    

    <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="Red" Visible="False" Font-Size="Medium"></asp:Label>
        </div>
</asp:Content>
