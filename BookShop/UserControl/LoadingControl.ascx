<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoadingControl.ascx.cs" Inherits="LoadingControl" %>        
<table style="/*background-image: url(../Images/index/��¼.jpg);*/ width: 220px; height: 117px" border="0" cellpadding="0" cellspacing="0" runat =server   id=tabLoading >
    <tr>
        <td align="center" valign="top" style="height: 117px; width: 220px;" >
              <table style ="width: 178px; height: 90px; font-size: 9pt; font-family: ����;"   >
                <tr style ="width: 152px;height: 18px; font-size: 9pt; font-family: ����;">
                    <td style="width: 1575px">
                        &nbsp;
                        ��Ա����</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Height="16px" Width="100px"></asp:TextBox></td>
                  
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: ����;">
                    <td style="height: 18px; width: 1575px;">
                        &nbsp; &nbsp;
                        ���룺</td>
                    <td style="width: 158px; height: 18px;">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" Height="16px" Width="100px"></asp:TextBox></td>
                   
                </tr>
                <tr style ="width: 152px;height: 18px;font-size: 9pt; font-family: ����;">
                    <td style="width: 1575px; height: 18px;" >
                        &nbsp;
                        ��֤�룺</td>
                    <td style="width: 158px; text-align: justify;">
                        <asp:TextBox ID="txtValid" runat="server" Height="12px" Width="48px"></asp:TextBox>
                        <asp:Label ID="lbValid" runat="server" Text="8888" BackColor="Silver" Font-Names="��Բ" Height="14px" Width="30px"></asp:Label></td>
                  
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnLoad" runat="server" Text="��¼" OnClick="btnLoad_Click" Height="18px" Width="40px" CausesValidation="False" /><asp:Button ID="btnRegister" runat="server" Text="ע��" OnClick="btnRegister_Click" Height="18px" Width="40px" CausesValidation="False" /></td>
                </tr>
            </table>  
        </td>
    </tr>
</table>
  <table  style="background-image: url(../Images/index/��¼.jpg); width: 220px; height: 117px; font-size: 9pt; font-family: ����;"   runat =server id=tabLoad visible =false border="0" cellpadding="0" cellspacing="0"  >
                <tr>
                          <td align="center" valign="top" style="height: 117px; width: 220px;" >
                             <br /><br /><table style ="width: 178px; height: 50px; font-size: 9pt; font-family: ����;"   >
                <tr>
                    <td colspan="2"  >
                        &nbsp; 
                        ��ӭ<font color="#80A5E7"><u><%=Session["UserName"]%></u></font>���٣�</td>
                </tr> 
                <tr>
                    <td colspan="2" >
                        &nbsp; 
                        <asp:Button ID="btnLogout" runat="server" Height="18px" Text="ע��"
                            Width="40px" OnClick="btnLogout_Click" CausesValidation="False" />&nbsp;
                        <asp:HyperLink ID="hpLinkUser" runat="server" NavigateUrl="~/User/UpdateMember.aspx">������Ϣ</asp:HyperLink>
                        <asp:HyperLink ID="hpLinkAddAP" runat="server" NavigateUrl="~/User/AddAdvancePay.aspx">��Ա��ֵ</asp:HyperLink></td>
                </tr>
            </table></td></tr></table>


      
           
             