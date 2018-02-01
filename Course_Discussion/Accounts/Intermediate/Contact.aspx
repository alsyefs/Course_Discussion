<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Course_Discussion.Contact" %>

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

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="jumbotron">
    <h2><%: Title %></h2>
    
    <address>
        <abbr title="Name">Name:</abbr> 
        Saleh A. Alsyefi
        <br />        
        <abbr title="Phone">Phone:</abbr>
        608-406-8929
    </address>

    <address>
        <strong>Work email:</strong>   <a href="mailto:Alsyefi.Saleh@uwlax.edu">Alsyefi.Saleh@uwlax.edu</a><br />
        <strong>Personal email:</strong> <a href="mailto:Saleh.Alsyefi@gmail.com">Saleh.Alsyefi@gmail.com</a>
    </address>
       </div>
</asp:Content>
