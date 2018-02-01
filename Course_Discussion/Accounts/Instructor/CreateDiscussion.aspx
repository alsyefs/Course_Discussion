<%@ Page Title="Create Discussion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateDiscussion.aspx.cs" Inherits="Course_Discussion.Accounts.Instructor.CreateDiscussion" %>
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
    <asp:Label ID="lblTopic" runat="server" Text="Discussion topic: " Font-Size="Medium"></asp:Label>&nbsp;    
    <asp:TextBox ID="txtTopic" runat="server" Font-Size="Medium" Width="228px"></asp:TextBox>
    &nbsp;<asp:Label ID="lblTopicError" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Size="Medium"></asp:Label>
    <br /> <br />    
    <asp:Label ID="lblCourse" runat="server" Text="Choose course: " Font-Size="Medium"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="drpCourse" runat="server" Font-Size="Medium" Width="229px"></asp:DropDownList>
    &nbsp; <asp:Label ID="lblCourseError" runat="server" Text="Label" ForeColor="Red" Visible="False" Font-Size="Medium"></asp:Label>
    
    <br /> <br />
    <asp:Button ID="btnCreate" runat="server" Text="Create Discussion" OnClick="btnCreate_Click" BackColor="Green" Font-Bold="True" Font-Size="Medium" class="btn btn-primary"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" BackColor="Red" Font-Bold="True" Font-Size="Medium" OnClick="btnCancel_Click" Text="Go back" Width="212px" class="btn btn-primary"/>
        <br />
    <asp:Label ID="lblSuccess" runat="server" Text="Label" ForeColor="Green" Visible="False" Font-Size="Medium"></asp:Label>
        </div>
</asp:Content>
