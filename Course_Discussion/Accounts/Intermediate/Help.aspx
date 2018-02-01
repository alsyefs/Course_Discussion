<%@ Page Title="Help" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Course_Discussion.Accounts.Intermediate.Help" %>
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
    <br />
    <h1>Frequently Asked Questions</h1>
    
    <h3>1. How to select a discussion?</h3>
    <p>To select a discussion, navigate to the home page and you will find the available discussions that </p>
    <p>you are allowed to view. Just simply click on the link right before the discussion ID and you will</p>
    <p>be redirected to the discussion page. Please note that if the discussion is terminated you will not</p>
    <p>be able to add a new entry.</p>
    <br />
    <h3>2. How to add a new entry in a discussion?</h3>
    <p>To add a new entry in a discussion, select to a discussion (refer to question 1), then you will get</p>
    <p>the list of entries for that discussion. at the very bottom of the page, you will find a textfield where</p>
    <p>you would type any text. Type the text for your entry at the textfield. After finishing from typing,</p>
    <p>simply click on the button called "Add New Entry". After that, the page will refresh and your entry will </p>
    <p>be visible to every user who has access to that discussion.</p>
    <br />
    <h3>3. How to view your account details?</h3>
    <p>To view your account details, simply navigate to the link right before the "Logout" link. Click on</p>
    <p>Account, and you will be redirected to another page that shows you your details.</p>
    <p>_____________________________________________________________________________________________________________</p>
    <h4>For more help, please do not hesitate to contact the support by clicking <a href="Contact.aspx">here</a></h4> 

        </div>
</asp:Content>
