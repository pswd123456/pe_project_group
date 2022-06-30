<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CommitBook.aspx.cs" Inherits="User_CommitBook" Title="购物车" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
  <table  cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :宋体;">
					<th  align="left" height="25" colspan="2">
						&nbsp;&nbsp;
						<asp:label id="lblTitleInfo" Runat="server">购物车</asp:label>
					</th>
				<tr>
				</tr>
			</table>
			<table  cellSpacing="1" cellPadding="1" width="480" align="center" border="0">
				<tr style =" font :9pt; font-family :宋体;">
					<td>
						<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr style =" font :9pt; font-family :宋体;">
							<td align="left" style="height: 135px">
							 <asp:GridView ID="gvShopCart" DataKeyNames ="CartID" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvShopCart_PageIndexChanging" OnRowCancelingEdit="gvShopCart_RowCancelingEdit" OnRowDeleting="gvShopCart_RowDeleting" OnRowEditing="gvShopCart_RowEditing" OnRowUpdating="gvShopCart_RowUpdating" Width="477px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                 <Columns>
                                     <asp:BoundField DataField="BookName" HeaderText="图书名称" ReadOnly="True">
                                         <ItemStyle HorizontalAlign="Center" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>
                                  
                                     <asp:TemplateField HeaderText =市场价>
                                     <HeaderStyle HorizontalAlign=Center />
                                     <ItemStyle HorizontalAlign =Center />
                                     <ItemTemplate >
                                     ￥ <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                     </ItemTemplate>    
                                     </asp:TemplateField>
                                    <asp:TemplateField HeaderText =会员价>
                                     <HeaderStyle HorizontalAlign=Center />
                                     <ItemStyle HorizontalAlign =Center />
                                     <ItemTemplate >￥
                                     <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
                                     </ItemTemplate>    
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="Num" HeaderText="数量">
                                         <ItemStyle HorizontalAlign="Center" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>
                                     
                                     <asp:TemplateField HeaderText =小计>
                                     <HeaderStyle HorizontalAlign=Center />
                                     <ItemStyle HorizontalAlign =Center />
                                     <ItemTemplate >￥
                                     <%#GetSPStr(DataBinder.Eval(Container.DataItem, "SumPrice", "{0:f2}").ToString())%>
                                     </ItemTemplate>    
                                     </asp:TemplateField>
                                     <asp:CommandField ShowDeleteButton="True" />
                                     <asp:CommandField ShowEditButton="True" />
                                 </Columns>
                                 <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <RowStyle BackColor="#EFF3FB" />
                                 <EditRowStyle BackColor="#2461BF" />
                                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                 <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                 <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
							</td>
							</tr>
							<tr align =left >
							<td align="center">
                                <asp:Label ID="lbLag" runat="server" Text="现购物车为空" Visible="False"></asp:Label></td>
							</tr>
							<tr align =left>
							<td style="height: 14px">
                                合计： &nbsp; ￥<asp:Label ID="lbSumPrice" runat="server"></asp:Label></td>
							</tr>
							<tr align =left>
							<td>
                                图书数量：
                                <asp:Label ID="lbSumNum" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td align="center" >
                                    <asp:LinkButton ID="lnkbtnClear" runat="server" OnClick="lnkbtnClear_Click">清空购物车</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnContinue" runat="server" OnClick="lnkbtnContinue_Click">继续购物</asp:LinkButton>  
                                    <asp:LinkButton ID="lnkbtnCheck" runat="server" OnClick="lnkbtnCheck_Click">结账</asp:LinkButton>
									</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
</asp:Content>

