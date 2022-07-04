<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShipFeeInfo.aspx.cs" Inherits="User_ShipFeeInfo" %>
<%@ OutputCache Duration="60" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Shipping price</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div>
    <table  cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<tr>
					<th height="25" align="left">
						
						Delivery fee (M yuan/km/kg)</th>
					
				<tr>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<tr>
					<td height="23" >
                      <asp:GridView ID="gvShip" runat="server" AllowPaging =True  AutoGenerateColumns =False DataKeyNames ="ShipID" Width =100% HeaderStyle-HorizontalAlign =center HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvShip_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" >
                            <Columns>
                                <asp:BoundField DataField="ShipID" HeaderText="serial number">
                                    <ItemStyle HorizontalAlign="Left" Width="30px" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShipWay" HeaderText="Shipping method name">
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                  <asp:TemplateField HeaderText="Shipping default price">
                                  <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
									<ItemTemplate>
										<%# GetVarStr(DataBinder.Eval(Container.DataItem, "ShipFee").ToString())%>￥
									</ItemTemplate>
                                </asp:TemplateField>
                               
                               
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
                        <asp:Button ID="btnExit" runat="server" Text="关闭" OnClick="btnExit_Click" /></td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
