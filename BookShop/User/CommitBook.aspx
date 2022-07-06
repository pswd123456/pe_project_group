<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CommitBook.aspx.cs" Inherits="User_CommitBook" Title="购物车" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
  <table  cellSpacing="0" cellPadding="0" width="480" align="center" border="1">
				<tr style =" font :9pt;">
					<th height="25" colspan="2">
						<asp:label id="lblTitleInfo" Runat="server" Font-Size="18">Cart</asp:label>
					</th>
				</table>
			<table  cellSpacing="1" cellPadding="1" width="480" align="center" border="1">
				<tr style =" font :9pt;">
					<td>
						<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr style =" font :9pt;">
							<td align="left" style="height: 135px">
							 <asp:GridView ID="gvShopCart" DataKeyNames ="CartID" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvShopCart_PageIndexChanging" OnRowCancelingEdit="gvShopCart_RowCancelingEdit" OnRowDeleting="gvShopCart_RowDeleting" OnRowEditing="gvShopCart_RowEditing" OnRowUpdating="gvShopCart_RowUpdating" Width="477px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                 <Columns>
                                     <asp:BoundField DataField="BookName" HeaderText="Book Name" ReadOnly="True">
                                         <ItemStyle HorizontalAlign="Center" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>
                                  
                                     <asp:TemplateField HeaderText = "Original Price">
                                     <HeaderStyle HorizontalAlign=Center />
                                     <ItemStyle HorizontalAlign =Center />
                                     <ItemTemplate >$ 
                                         <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                     </ItemTemplate>    
                                     </asp:TemplateField>
                                    <asp:TemplateField HeaderText = "VIP Price">
                                     <HeaderStyle HorizontalAlign=Center />
                                     <ItemStyle HorizontalAlign =Center />
                                     <ItemTemplate >$
                                     <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
                                     </ItemTemplate>    
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="Num" HeaderText="Number">
                                         <ItemStyle HorizontalAlign="Center" />
                                         <HeaderStyle HorizontalAlign="Center" />
                                     </asp:BoundField>
                                     
                                     <asp:TemplateField HeaderText ="Subtotal">
                                     <HeaderStyle HorizontalAlign=Center />
                                     <ItemStyle HorizontalAlign =Center />
                                     <ItemTemplate >$
                                     <%#GetSPStr(DataBinder.Eval(Container.DataItem, "SumPrice", "{0:f2}").ToString())%>
                                     </ItemTemplate>    
                                     </asp:TemplateField>
                                     <asp:CommandField ShowDeleteButton="True" DeleteText="Delete"/>
                                     <asp:CommandField ShowEditButton="True" EditText="Edit"/>
                                 </Columns>
                                 <FooterStyle BackColor="#80c7d6" Font-Bold="True" ForeColor="White" />
                                 <RowStyle BackColor="#EFF3FB" />
                                 <EditRowStyle BackColor="#2461BF" />
                                 <SelectedRowStyle BackColor="#80c7d6" Font-Bold="True" ForeColor="#333333" />
                                 <PagerStyle BackColor="#80c7d6" ForeColor="White" HorizontalAlign="Center" />
                                 <HeaderStyle BackColor="#80c7d6" Font-Bold="True" ForeColor="White" />
                                 <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
							</td>
							</tr>
							<tr align =left >
							<td align="center">
                                <asp:Label ID="lbLag" runat="server" Text="The Cart Is Empty" Visible="False"></asp:Label></td>
							</tr>
							<tr align =left>
							<td style="height: 14px">
                                Total Price： &nbsp; $<asp:Label ID="lbSumPrice" runat="server"></asp:Label></td>
							</tr>
							<tr align =left>
							<td>
                                Books' Quantity：
                                <asp:Label ID="lbSumNum" runat="server"></asp:Label></td>
							</tr>
							<tr>
								<td align="center" >
                                    <asp:LinkButton ID="lnkbtnClear" runat="server" OnClick="lnkbtnClear_Click">Clear Cart</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnContinue" runat="server" OnClick="lnkbtnContinue_Click" >Keep Shopping</asp:LinkButton>  
                                    <asp:LinkButton ID="lnkbtnCheck" runat="server" OnClick="lnkbtnCheck_Click">Pay</asp:LinkButton>
									</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
</asp:Content>

