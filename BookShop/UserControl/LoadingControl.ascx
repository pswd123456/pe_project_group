<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingControl.ascx.cs" Inherits="LoadingControl" %>        
<table style="/*background-image: url(../Images/index/登录.jpg);*/ width: 220px; height: 117px" border="0" cellpadding="0" cellspacing="0" runat =server   id=tabLoading >
    <tr>
        <td align="center" valign="top" style="height: 117px; width: 220px;" >
              <table style ="width: 178px; height: 90px; font-size: 9pt; font-family: 宋体;"   >
                <tr style ="width: 152px;height: 18px; font-size: 9pt; font-family: 宋体;">
                    <td style="width: 1575px">
                        &nbsp;
                        会员名：</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Height="16px" Width="100px"></asp:TextBox></td>
                  
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: 宋体;">
                    <td style="height: 18px; width: 1575px;">
                        &nbsp; &nbsp;
                        密码：</td>
                    <td style="width: 158px; height: 18px;">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" Height="16px" Width="100px"></asp:TextBox></td>
                   
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: 宋体;">
                    <td style="width: 1575px; height: 18px;" >
                        &nbsp;
                        验证码：</td>
                    <td style="width: 158px; text-align: justify;">
                        <asp:TextBox ID="txtValid" runat="server" Height="12px" Width="48px"></asp:TextBox>
                        <asp:Label ID="lbValid" runat="server" Text="8888" BackColor="Silver" Font-Names="幼圆" Height="14px" Width="30px"></asp:Label></td>
                  
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnLoad" runat="server" Text="登录" OnClick="btnLoad_Click" Height="18px" Width="40px" CausesValidation="False" /><asp:Button ID="btnRegister" runat="server" Text="注册" OnClick="btnRegister_Click" Height="18px" Width="40px" CausesValidation="False" /></td>
                </tr>
            </table>  
        </td>
    </tr>
</table>
  <table  style="background-image: url(../Images/index/登录.jpg); width: 220px; height: 117px; font-size: 9pt; font-family: 宋体;"   runat =server id=tabLoad visible =false border="0" cellpadding="0" cellspacing="0"  >
                <tr>
                          <td align="center" valign="top" style="height: 117px; width: 220px;" >
                             <br /><br /><table style ="width: 178px; height: 50px; font-size: 9pt; font-family: 宋体;"   >
                <tr>
                    <td colspan="2"  >
                        &nbsp; 
                        欢迎<font color="#80A5E7"><u><%=Session["UserName"]%></u></font>光临！</td>
                </tr> 
                <tr>
                    <td colspan="2" >
                        &nbsp; 
                        <asp:Button ID="btnLogout" runat="server" Height="18px" Text="注销"
                            Width="40px" OnClick="btnLogout_Click" CausesValidation="False" />&nbsp;
                        <asp:HyperLink ID="hpLinkUser" runat="server" NavigateUrl="~/User/UpdateMember.aspx">更新信息</asp:HyperLink>
                        <asp:HyperLink ID="hpLinkAddAP" runat="server" NavigateUrl="~/User/AddAdvancePay.aspx">会员充值</asp:HyperLink></td>
                </tr>
            </table></td></tr></table>


      
           
             