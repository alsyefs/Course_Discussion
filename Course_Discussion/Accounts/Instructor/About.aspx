<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Course_Discussion.About" %>

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


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h2><%: Title %></h2>
    
    <p>This web application is to help maintain helpful discussion between instructors and students.</p>
        </div>
</asp:Content>
