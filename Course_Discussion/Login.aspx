<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Course_Discussion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="jumbotron">
     <h3>
        Login
    </h3>
    <br />
    <asp:Label ID="lblUsername" runat="server" Text="Username:" Font-Size="Medium"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtUsername" runat="server" Font-Size="Medium" Height="23px" ></asp:TextBox>
    &nbsp;&nbsp;
    <asp:Label ID="lblUsernameError" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Size="Medium" ></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password:" Font-Size="Medium"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPassword" runat="server" type="password" Font-Size="Medium" Height="23px" ></asp:TextBox>
    &nbsp;&nbsp;
    <asp:Label ID="lblPasswordError" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Size="Medium"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="drpRole" runat="server" Font-Size="Medium" Width="186px" ></asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Label ID="lblRoleError" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Size="Medium"></asp:Label>
    <br />
    <br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" BackColor="Green" Font-Bold="True" Font-Size="Medium" Width="120px" class="btn btn-primary" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnCancel" runat="server" BackColor="Red" Font-Bold="True" Font-Size="Medium" OnClick="btnCancel_Click" Text="Cancel" Width="121px" class="btn btn-primary"/>
         <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Size="Medium"></asp:Label>
    <br />
         </div>
</asp:Content>
