﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Course_Discussion.Accounts.Expert.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <div class="navbar navbar-inverse navbar-fixed-top" style=" background-color:#4D1E1E; font-size:medium; font-weight: 700;">
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
                        <li><a runat="server" href="~/Accounts/Expert/Home">Home</a></li>
                        <li><a runat="server" href="~/Accounts/Expert/About">About</a></li>
                        <li><a runat="server" href="~/Accounts/Expert/Contact">Contact</a></li>
                        <li><a runat="server" href="~/Accounts/Expert/Help" style ="background-color:blue; color:white">Help</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">                 
                        <li><a runat="server" href="~/Accounts/Expert/Account">Account</a></li>
                        <li><a runat="server" href="~/Logout">Logout</a></li>
                    </ul>
                </div>
            </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h2><%: Title %></h2>
    
    <p>This web application is to help maintain helpful discussion between instructors and students.</p>
        </div>
</asp:Content>
