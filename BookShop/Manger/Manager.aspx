<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manager.aspx.cs" Inherits="Manger_Manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div>
     <table class="tableBorder" cellSpacing="0" cellPadding="0" width="776" align="center" border="0" bgcolor="#EFF3FB">
				<tr>
					<th class="tableHeaderText" height="25" align="left">
                        管理会员</th>
					
				<tr>
				</tr>
			</table>
			<table class="tableBorder" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
				<tr>
					<td height="23" style="width: 776px" >
                       <asp:GridView ID="gvMemberList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="5" DataKeyNames ="MemberID"  Width="100%" HorizontalAlign="Center"
							HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvMemberList_PageIndexChanging" OnRowDeleting="gvMemberList_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None">
							<HeaderStyle Font-Bold="True" CssClass="summary-title" BackColor="#507CD1" ForeColor="White"></HeaderStyle>
                            <Columns>
                                <asp:BoundField DataField="MemberID" HeaderText="会员代号" ReadOnly="True" >
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TrueName" HeaderText="真实姓名" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Phonecode" HeaderText="电话号码" >
                                    <ItemStyle HorizontalAlign="Left"  />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Emails" HeaderText="会员Email" />
                                <asp:BoundField DataField="City" HeaderText="所在城市" />  
                                <asp:TemplateField  HeaderText ="详细地址">
                                <HeaderStyle HorizontalAlign =Center />
                                <ItemStyle HorizontalAlign =Left />
                                <ItemTemplate>    
                                <%#DataBinder.Eval(Container.DataItem,"Address")%>
                                </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:BoundField DataField="PostCode" HeaderText="邮编号码" />
                                <asp:BoundField DataField="AdvancePayment" HeaderText="预付金额" />
                                <asp:TemplateField  HeaderText="加入日期">
                                <HeaderStyle HorizontalAlign =Center />
                                <ItemStyle HorizontalAlign =Left />
                                <ItemTemplate>
                                <%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "LoadDate").ToString()).ToLongDateString()%>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                           <RowStyle BackColor="#EFF3FB" />
                           <EditRowStyle BackColor="#2461BF" />
                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
