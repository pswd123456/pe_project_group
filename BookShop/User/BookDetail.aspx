<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BookDetail.aspx.cs" Inherits="User_BookDetail" Title="图书详细信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<!DOCTYPE html>
<script src="https://how2j.cn/study/js/jquery/2.0.0/jquery.min.js"></script>
<link href="https://how2j.cn/study/css/bootstrap/3.3.6/bootstrap.min.css" rel="stylesheet">
<script src="https://how2j.cn/study/js/bootstrap/3.3.6/bootstrap.min.js"></script>

<table class="table table-striped table-bordered table-hover  table-condensed" cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :Microsoft YaHei;">
					<th  align="left" height="25px" colspan="2px">
						&nbsp;&nbsp;
						<asp:label id="lblTitleInfo" Runat="server">Book Details Information</asp:label>
					</th>
				</table>
			<table class="table table-striped table-bordered table-hover  table-condensed" cellSpacing="1" cellPadding="1" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :Microsoft YaHei;">
					<td>
						<table class="table table-striped table-bordered table-hover  table-condensed" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left" width="100" style="height: 28px">
                                    Book name：</td>
								
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblName" runat="server" Height="18px"></asp:Label></td>
								  
								
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px">
                                    Categories：
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
                                    Page：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblPageNum" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" height="24" style="width: 82px">
                                    Press：
								</td>
								<td height="24" style="width: 359px">
                                    <asp:Label ID="lblPublisher" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px;">
                                    Published date：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblPublishDate" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px">
                                    Author：
								</td>
								<td style="width: 359px; height: 24px;">
                                    <asp:Label ID="lblAuthor" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="width: 82px; height: 24px;">Market Price：
								</td>
								<td colSpan="3" style="height: 24px">
                                    <asp:Label ID="lblMarketPrice" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="height: 24px; width: 82px;">Member Price：
								</td>
								<td colSpan="3" style="height: 24px">
                                    <asp:Label ID="lblMemberPrice" runat="server" Height="18px"></asp:Label></td>
							</tr>
							<tr>
								<td align="left" style="height: 24px; width: 82px;">
                                    Cover image：
								</td>
								<td colSpan="3" style="height: 24px">
                                    <asp:ImageMap ID="ImageMapPhoto" runat="server" ImageUrl="~/Images/icon_7.gif">
                                    </asp:ImageMap></td>
							</tr>
                            <tr>
								<td align="left" style="width: 82px">
                                    Book Description：
								</td>
								<td style="width: 359px"><asp:textbox id="txtShortDesc" runat="server" Width="307px" Height="89px" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td align="center" colSpan="4" style="height: 36px"><br>
									<asp:button id="btnExit" runat="server" Text=" Back " OnClick="btnExit_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
</asp:Content>