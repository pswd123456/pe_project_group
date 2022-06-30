<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductAdd.aspx.cs" Inherits="Manger_ProductAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>书籍添加</title>
</head>
<body  style="font-family :宋体; font-size: 9pt;">
<form id="Form1" method="post" runat="server">
			<table  cellSpacing="0" cellPadding="0" width="480" align="center" border="0" bgcolor="#EFF3FB">
				<tr>
					<th  align="left" height="25" colspan="2">
						&nbsp;
						<asp:label id="lblTitleInfo" Runat="server">书籍添加</asp:label>
					</th>
				<tr>
				</tr>
			</table>
			<table  cellSpacing="1" cellPadding="1" width="480" align="center" border="0" id="tabAddProduct" bgcolor="#EFF3FB">
				<tr>
					<td style="width: 478px">
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" width="80">
                                    书籍名称：</td>
								
								<td style="width: 359px"><asp:textbox id="txtName" runat="server"></asp:textbox><font color="red">*</font></td>
								
								
							</tr>
							<tr>
								<td align="left">
                                    所属类别：
								</td>
								<td style="width: 359px">
									<asp:DropDownList id="ddlCategory" runat="server" AutoPostBack="True"></asp:DropDownList>
								</td>
							</tr>

							<tr>
								<td align="left" style="height: 24px">
                                    ISBN：</td>
								<td style="width: 359px; height: 24px;"><asp:textbox id="txtISBN" runat="server"></asp:textbox><span style="color: #ff0000">*</span></td>
							</tr>
							
							<tr>
								<td align="left" style="height: 24px">
                                    页数：
								</td>
								<td style="width: 359px; height: 24px;"><asp:textbox id="txtPageNum" runat="server"></asp:textbox><FONT color="red">*</FONT></td>
							</tr>
							<tr>
								<td align="left" height="17">
                                    出版社：
								</td>
								<td height="17" style="width: 359px"><asp:textbox id="txtPublisher" runat="server"></asp:textbox><span style="color: #ff0000">*</span></td>
							</tr>
							<tr>
								<td align="left" height="17">
                                    出版时间：
								</td>
								<td height="17" style="width: 359px"><asp:textbox id="txtPublishDate" runat="server"></asp:textbox><span style="color: #ff0000">*<asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPublishDate"
                                        ErrorMessage="请正确输入日期格式（格式：2008年6月）" ValidationExpression="\d{4}年\d{0,2}月"></asp:RegularExpressionValidator></span></td>
							</tr>
							<tr>
								<td align="left" height="17">
                                    作者：
								</td>
								<td height="17" style="width: 359px"><asp:textbox id="txtAuthor" runat="server"></asp:textbox><span style="color: #ff0000">*</span></td>
							</tr>
							<tr>
								<td align="left" height="19">市场价格：
								</td>
								<td colSpan="3" height="19"><asp:textbox id="txtMarketPrice" runat="server"></asp:textbox><FONT color="red">*<asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMarketPrice"
                                        ErrorMessage="请正确输入（格式：1.00）" ValidationExpression="^[0-9]+(.[0-9]{2})?$"></asp:RegularExpressionValidator></FONT></td>
							</tr>
							<tr>
								<td align="left" style="height: 24px">会员价格：
								</td>
								<td colSpan="3" style="height: 24px"><asp:textbox id="txtMemberPrice" runat="server"></asp:textbox><FONT color="red">*<asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMemberPrice"
                                        ErrorMessage="请正确输入（格式：1.00）" ValidationExpression="^[0-9]+(.[0-9]{2})?$"></asp:RegularExpressionValidator></FONT></td>
							</tr>
							<tr>
								<td align="left" colspan="4" style="height: 15px"><b>附件设置</b></td>
							</tr>
							<tr>
								<td align="left" style="height: 22px">
                                    书籍图像：
								</td>
								<td colSpan="3" style="height: 22px">
                                    <asp:DropDownList ID="ddlUrl" runat="server" OnSelectedIndexChanged="ddlUrl_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList></td>
							</tr>
                            <tr>
                                <td align="left" style="height: 22px">
                                </td>
                                <td colspan="3" style="height: 22px">
                                    <asp:ImageMap ID="ImageMapPhoto" runat="server" ImageUrl="~/Images/icon_7.gif">
                                    </asp:ImageMap></td>
                            </tr>
							<tr>
								<td align="left" style="height: 20px">是否推荐：
								</td>
								<td colSpan="3" style="height: 20px"><asp:checkbox id="cbxCommend" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							
							<tr>
								<td align="left">
                                    是否热销：
								</td>
								<td colSpan="3"><asp:checkbox id="cbxHot" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td align="left">是否参与打折：
								</td>
								<td colSpan="3"><asp:checkbox id="cbxDiscount" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td align="left">
                                    图书描述：
								</td>
								<td style="width: 359px"><asp:textbox id="txtShortDesc" runat="server" Width="307px" Height="89px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="4"><br>
									<asp:button id="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:button>&nbsp;<asp:button id="btnReset" runat="server" Text="重置"  OnClick="btnReset_Click"></asp:button>
                                    <asp:Button ID="btnReturn" runat="server" Text="返回" CausesValidation="False" OnClick="btnReturn_Click" /></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			
		</form>
	</body>

</html>
