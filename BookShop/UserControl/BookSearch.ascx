<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookSearch.ascx.cs" Inherits="UserControl_BookSearch" %>
<asp:Label ID="lblSearch" runat="server" Font-Size="Medium" Text="图书搜索："></asp:Label>
<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;
<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索" />
