<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Manger_Product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>书籍管理</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div>
            <table cellSpacing="0" cellPadding="0" width="640" align="center" border="0" bgcolor="#EFF3FB">
				<tr>
					<th class="tableHeaderText" height="25" align="left">
						书籍管理</th>
					
				<tr>
				</tr>
			</table>
			 <table cellSpacing="0" cellPadding="0" width="640" align="center" border="0" bgcolor="#EFF3FB">
			 <tr>
					
					<td align="center">搜索：&nbsp;
						 <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>&nbsp;
						<asp:Button id="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click"></asp:Button>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
				</tr>
          
            <tr>
                <td >
                    <br />
                    <asp:GridView ID="gvBookInfo" runat="server" CellPadding="4" Width="100%" HorizontalAlign="Center" DataKeyNames ="BookID"
							HeaderStyle-CssClass="summary-title" AutoGenerateColumns="False" OnPageIndexChanging="gvBookInfo_PageIndexChanging" OnRowDeleting="gvBookInfo_RowDeleting" AllowPaging="True" PageSize="20" ForeColor="#333333" GridLines="None" >
                       <HeaderStyle Font-Bold="True" CssClass="summary-title" BackColor="#507CD1" ForeColor="White"></HeaderStyle>
                        <Columns>
                            <asp:BoundField DataField="BookID" HeaderText="图书ID"  >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BookName" HeaderText="图书名称">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText ="图书类别">
                            <HeaderStyle HorizontalAlign =Center />
                            <ItemStyle HorizontalAlign =Center />
                            <ItemTemplate >
                            <%# GetClass(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "ClassID").ToString())) %>
                            </ItemTemplate>
                            </asp:TemplateField> 
                             <asp:TemplateField HeaderText ="图书会员价">
                            <HeaderStyle HorizontalAlign =Center />
                            <ItemStyle HorizontalAlign =Center />
                            <ItemTemplate >
                            <%# GetVarStr(DataBinder.Eval(Container.DataItem, "MemberPrice").ToString())%>￥
                            </ItemTemplate>
                            </asp:TemplateField> 
                          
                            <asp:HyperLinkField HeaderText="详细信息" Text="详细信息" DataNavigateUrlFields="BookID" DataNavigateUrlFormatString="EditProduct.aspx?BookID={0}" >
                                <ControlStyle Font-Underline="False" ForeColor="Black" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                                <ControlStyle Font-Underline="False" ForeColor="Black" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
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
