<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="User_BookDetail" Title="图书详细信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<table  cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr>
					<th  align="left" height="25" colspan="2">图书详细信息
						&nbsp;
					</th>
				<tr>
				</tr>
			</table>
			<table  cellSpacing="1" cellPadding="1" width="480" align="center" border="0" id="tabAddProduct">
				<tr>
					<td style="width: 478px">
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" style="width: 82px; height: 24px;">
                                    书籍名称：</td>
								
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblName" runat="server" Height="18px"></asp:Label></td>
								
								
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px">
                                    所属类别：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblCategory" runat="server" Height="18px"></asp:Label></td>
							</tr>

							<tr>
								<td align="left" style="height: 24px; width: 82px;">
                                    ISBN：</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblISBN" runat="server" Height="18px"></asp:Label></td>
							</tr>
							
							<tr>
								<td align="left" style="height: 24px; width: 82px;">
                                    页数：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblPageNum" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" height="24" style="width: 82px">
                                    出版社：
								</td>
								<td height="24" style="width: 359px">
                                    <asp:Label ID="lblPublisher" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px;">
                                    出版时间：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblPublishDate" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px">
                                    作者：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblAuthor" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px;">市场价格：
								</td>
								<td colSpan="3" style="height: 24px">
                                    <asp:Label ID="lblMarketPrice" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="height: 24px; width: 82px;">会员价格：
								</td>
								<td colSpan="3" style="height: 24px">
                                    <asp:Label ID="lblMemberPrice" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="height: 24px; width: 82px;">
                                    书籍图像：
								</td>
								<td colSpan="3" style="height: 24px">
                                    <asp:ImageMap ID="ImageMapPhoto" runat="server" ImageUrl="~/Images/icon_7.gif">
                                    </asp:ImageMap></td>
							</tr>
                            <tr>
								<td align="left" style="width: 82px">
                                    图书描述：
								</td>
								<td style="width: 359px"><asp:textbox id="txtShortDesc" runat="server" Width="307px" Height="89px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="4" style="height: 36px"><br>
									<asp:button id="btnExit" runat="server" Text=" 返回 " OnClick="btnExit_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
</asp:Content>