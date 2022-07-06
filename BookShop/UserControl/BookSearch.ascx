<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookSearch.ascx.cs" Inherits="UserControl_BookSearch" %>
<!DOCTYPE html>
<script src="https://how2j.cn/study/js/jquery/2.0.0/jquery.min.js"></script>
<link href="https://how2j.cn/study/css/bootstrap/3.3.6/bootstrap.min.css" rel="stylesheet">
<script src="https://how2j.cn/study/js/bootstrap/3.3.6/bootstrap.min.js"></script>

<html>
<head>
    <title>search</title>    
</head>
    <body >
    
        <asp:Label class="text-muted" ID="lblSearch" runat="server" Font-Size="Medium" Text="Search a book："></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;
        <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Submit" />



    </body>
</html>


