<%@ Page Title="Delete Entry" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteEntry.aspx.cs" Inherits="Course_Discussion.Accounts.Instructor.DeleteEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

      <div class="navbar navbar-inverse navbar-fixed-top">
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
                        <li><a runat="server" href="~/Accounts/Instructor/Home">Home</a></li>
                        <li><a runat="server" href="~/Accounts/Instructor/CreateDiscussion">Create new discussion</a></li>
                        <li><a runat="server" href="~/Accounts/Instructor/About">About</a></li>
                        <li><a runat="server" href="~/Accounts/Instructor/Contact">Contact</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">                               
                                <li><a runat="server" href="~/Logout">Logout</a></li>
                    </ul>
                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <br />

    <asp:Label ID="lblInformation" runat="server" Text="Label" Font-Size="Medium"></asp:Label>

    &nbsp;
    <br /><br />
    <asp:Button ID="btnYes" runat="server" Text="Yes" Height="42px" Width="136px" BackColor="Green" OnClick="btnYes_Click" Font-Bold="True" Font-Size="Medium" class="btn btn-primary"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Go back" Height="42px" Width="136px" BackColor="Red" OnClick="btnCancel_Click" Font-Bold="True" Font-Size="Medium" class="btn btn-primary"/>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblMessage" runat="server" Text="Label" ForeColor="Green" Visible="False" Font-Size="Medium"></asp:Label>


    </div>
</asp:Content>
