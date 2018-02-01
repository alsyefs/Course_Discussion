<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Course_Discussion.Contact" %>

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
