<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingControl.ascx.cs" Inherits="LoadingControl" %>        

<link href="https://how2j.cn/study/css/bootstrap/3.3.6/bootstrap.min.css" rel="stylesheet">

<div class="container" id="tabLoading" runat="server">
    <div class="col-md-4" style="background-color:#eee; width:250px">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Log in" style="font-size: 20px"></asp:Label>
        </center>
    
            <div class="form-group">
                <label>Username:</label>
                <asp:TextBox ID="txtName" runat="server"  class="form-control" style="color:black;height:20px"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" class="form-control" style="color:black;height:20px"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtValid" runat="server" Height="16px" Width="115px"></asp:TextBox>
                <asp:Label ID="lbValid" runat="server" Text="8888" BackColor="Silver"  Height="21px" Width="54px"></asp:Label>
            </div>
            <div class="form-group" align="center">
                 <asp:Button ID="btnLoad" runat="server" Text="Confirm" OnClick="btnLoad_Click" class="btn btn-success form-control" CausesValidation="False" />
                 <asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click" >Register Here</asp:LinkButton>
                <br/>
            </div>

    </div>
    <div class="col-md-4"></div>
</div>

<div class="container" id="tabLoad" runat="server" visible="false">
    <div class="col-md-4" style="background-color:#eee; width:250px">
        <asp:Label ID="Label2" runat="server" Text="Welcome! " Font-Size="15px"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label" Font-color="#80A5E7" Font-Size="15px"><u><%=Session["UserName"]%></u></asp:Label>
        <asp:Button ID="btnLogout" runat="server" Height="24px" Text="Log Out" Width="82px" OnClick="btnLogout_Click" CausesValidation="False" />
        <br/>
        <asp:HyperLink ID="hpLinkUser" runat="server" NavigateUrl="~/User/UpdateMember.aspx"  >Update Info</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="hpLinkAddAP" runat="server" NavigateUrl="~/User/AddAdvancePay.aspx" >Top Up</asp:HyperLink>

    </div>
    <div class="col-md-4"></div>
</div>

           
             