<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Manger_Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>支付方式</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div>
     <table  cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<tr>
					<th height="25" align="left" bgcolor="#EFF3FB">
						
						<asp:Label id="lblAction" runat="server"></asp:Label></th>
					
				<tr>
				</tr>
			</table>
			<% if(this.Request.QueryString["Action"] == "Manage"){%>
			<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
				<tr>
					<td height="23" >
                      <asp:GridView ID="gvPay" runat="server" AllowPaging =True  AutoGenerateColumns =False DataKeyNames ="PayID" Width =100% HeaderStyle-HorizontalAlign =center HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvPay_PageIndexChanging" OnRowDeleting="gvPay_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None"  >
                            <Columns>
                                <asp:BoundField DataField="PayID" HeaderText="序号">
                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PayWay" HeaderText="支付方式名称">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                  <asp:TemplateField>
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="30px"></ItemStyle>
									<ItemTemplate>
										<a href='Payment.aspx?Action=Modify&PayID=<%# DataBinder.Eval(Container.DataItem, "PayID") %>'>
											修改</a>
									</ItemTemplate>
                                </asp:TemplateField>
                             
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <RowStyle BackColor="#EFF3FB" />
                          <EditRowStyle BackColor="#2461BF" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <HeaderStyle BackColor="#507CD1" CssClass="summary-title" Font-Bold="True" ForeColor="White"
                              HorizontalAlign="Center" />
                          <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
					</td>
				</tr>
			</table>
			<%}if(this.Request.QueryString["Action"] == "Add" | this.Request.QueryString["Action"] == "Modify"){%>
			<table cellSpacing="0" cellPadding="0" width="400" align="center" border="0" bgcolor="#EFF3FB">
				<tr>
					<td height="23">
						<table class="tableBorder" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
							<tr>
								<td align="left" style="height: 24px">
									支付方式名称：
								</td>
								<td style="height: 24px">
									<asp:TextBox id="txtName" runat="server"></asp:TextBox>
                                    （如：会员卡）</td>
							</tr>
							<tr>
								<td align="center" colspan="2"><br>
									<asp:Button id="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:Button>
									</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<%}%>
    </div>
    </form>
</body>
</html>
