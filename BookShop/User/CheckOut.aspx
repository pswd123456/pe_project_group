<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="User_CheckOut" Title="会员结帐" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<!DOCTYPE html>
<script src="https://how2j.cn/study/js/jquery/2.0.0/jquery.min.js"></script>
<link href="https://how2j.cn/study/css/bootstrap/3.3.6/bootstrap.min.css" rel="stylesheet">
<script src="https://how2j.cn/study/js/bootstrap/3.3.6/bootstrap.min.js"></script>

<table class="table table-striped table-bordered table-hover  table-condensed" cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :Microsoft YaHei;">
					<th  align="left" height="25px" colspan="2px">
						&nbsp;&nbsp;
						<asp:label id="lblTitleInfo" Runat="server">Please filling the information</asp:label>
					</th>
				</table>
			<table class="table table-striped table-bordered table-hover  table-condensed" cellSpacing="1" cellPadding="1" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :Microsoft YaHei;">
					<td>
						<table class="table table-striped table-bordered table-hover  table-condensed" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left" width="100" style="height: 28px">
                                    Name：</td>
								
								<td style="width: 359px; height: 28px;" align =left ><asp:textbox id="txtReciverName" runat="server"></asp:textbox><font color="red">*</font></td>
								
								
							</tr>
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left">
                                    Address：
								</td>
								<td style="width: 359px" align =left >
									<asp:textbox id="txtReceiverAddress" runat="server"></asp:textbox><font color="red">*</font></td>
							</tr>

							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left" style="height: 24px">
                                    Phone Number：
								</td>
								<td style="width: 359px; height: 24px;"  align =left ><asp:textbox id="txtReceiverPhone" runat="server"></asp:textbox><font color="red"></font></td>
							</tr>
							
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left">
									Zip code：
								</td>
								<td style="width: 359px" align =left ><asp:textbox id="txtReceiverPostCode" runat="server"></asp:textbox><font color="red">*<asp:RegularExpressionValidator
                                        ID="revPostCode" runat="server" ControlToValidate="txtReceiverPostCode" Font-Size="9pt"
                                        ValidationExpression="\d{6}" Width="134px">Your zip code was entered incorrectly</asp:RegularExpressionValidator></font></td>
							</tr>
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left" height="17">
                                    Email：
								</td>
								<td height="17" style="width: 359px" align =left ><asp:textbox id="txtReceiverEmails" runat="server"></asp:textbox><font color="red">*<asp:RegularExpressionValidator
                                        ID="revEmail" runat="server" ControlToValidate="txtReceiverEmails" Font-Size="9pt"
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="132px">The E-mail address you entered is not in the correct format, please re-enter</asp:RegularExpressionValidator></font></td>
							</tr>
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left" height="19">
                                    Delivery city：
								</td>
								<td colSpan="3" height="19" align =left ><asp:DropDownList id="ddlShipCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShipCity_SelectedIndexChanged">
                                </asp:DropDownList>
                                    <asp:Label ID="labKM" runat="server" Text=""></asp:Label>kilometer</td>
							</tr>
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left" height="19">
                                    Delivery methods：
								</td>
								<td colSpan="3" height="19" align =left ><asp:DropDownList id="ddlShipType" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                                    <asp:LinkButton ID="lnkbtnSee" runat="server" OnClick="lnkbtnSee_Click">View Shipping Fees</asp:LinkButton></td>
							</tr>
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="left">
                                    Payment method：
								</td>
								<td colSpan="3" align =left ><asp:DropDownList id="ddlPayType" runat="server" AutoPostBack="True">
                                </asp:DropDownList></td>
							</tr>
							<tr style =" font :9pt; font-family :Microsoft YaHei;">
								<td align="center" colSpan="4"><br>
									<asp:button id="btnSave" runat="server" Text="checkout" OnClick="btnSave_Click" ></asp:button>&nbsp;<asp:button id="btnReset" runat="server" Text="quit" OnClick="btnReset_Click"  ></asp:button>
                                    </td>
							</tr>
						</table>
					</td>
				</tr>
			</table>

</asp:Content>