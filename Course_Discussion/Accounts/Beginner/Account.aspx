<%@ Page Title="Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Course_Discussion.Accounts.Beginner.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
      <div class="navbar navbar-inverse navbar-fixed-top" style=" background-color:#212E58; font-size:large; font-weight: 700;">
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
                        <li><a runat="server" href="~/Accounts/Beginner/Home">Home</a></li>
                        <li><a runat="server" href="~/Accounts/Beginner/About">About</a></li>
                        <li><a runat="server" href="~/Accounts/Beginner/Contact">Contact</a></li>
                        <li><a runat="server" href="~/Accounts/Beginner/Help" style ="background-color:blue; color:white">Help</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">                 
                        <li><a runat="server" href="~/Accounts/Beginner/Account">Account</a></li>
                        <li><a runat="server" href="~/Logout">Logout</a></li>
                    </ul>
                </div>
            </div>
        </div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
    <br />
    <asp:Label ID="lblUsername" runat="server" Text="Your username is: " Font-Size="Medium"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="lblUsernameOutput" runat="server" Text="." Font-Bold="True" Font-Size="Small"></asp:Label>

    <br />
    <asp:Label ID="lblCourses" runat="server" Text="Your rigestered courses: " Font-Size="Medium"></asp:Label>
    &nbsp;&nbsp;
    <asp:Label ID="lblCoursesOutput" runat="server" Text="." Visible="False" Font-Size="Medium"></asp:Label>
    <br /> <br />

      <asp:GridView ID="grdCourses" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdCourses_PageIndexChanging"  Visible="False">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>

</div>
</asp:Content>
