<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Course_Discussion.Accounts.Expert.Home" %>
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
    
    <h3>Available Discussions:</h3>  

    <%--The search bar:--%>
    <asp:Label ID="lblSearch" runat="server" Text="Search for a topic: " Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtSearch" runat="server" Font-Size="Medium" Height="16px"></asp:TextBox>
    &nbsp;
    <asp:ImageButton ID="btnSearch" runat="server" Height="28px" ImageUrl="~/icons/icon_search.png" Width="37px" OnClick="btnSearch_Click" />
    <br />
    <asp:Label ID="lblSearchError" runat="server" Text="Label" ForeColor="Red" Visible="False" Font-Size="Medium"></asp:Label>
        <br />
    <%--End of search bar.--%>

    <%--The Below Works, just uncomment--%>
    <asp:GridView ID="grdDiscussions" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"  OnPageIndexChanging="grdDiscussions_PageIndexChanging"   OnSelectedIndexChanged ="grdDiscussions_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            
            <asp:HyperLinkField Text="View" DataNavigateUrlFields="id" SortExpression="id" DataNavigateUrlFormatString="~/Accounts/Expert/Entries.aspx?id={0}" />
            
        </Columns>
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
