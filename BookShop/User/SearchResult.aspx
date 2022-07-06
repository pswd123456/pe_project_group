<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="User_SearchResult" Title="图书搜索结果" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="你要找的图书信息如下："></asp:Label><br />
    <asp:DataList ID="DLsearch" runat="server" DataKeyField ="BookID" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="4" ForeColor="#333333" OnItemCommand="DLsearch_ItemCommand">
    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;" >
                            <tr align =center style =" width :135px; height:65px;" >
                                <td colspan="2" align="center" >
                                    <asp:Image ID="imageRefine" Width=70px Height=100px runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/></td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px; font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center">
                                    <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px; font-size: 9pt; font-family: 宋体;">
                                <td align="center" >
                                    市场价格</td>
                                <td align="left" >
                                    ￥ <%#GetVarMKP(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                    </td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center" >
                                    会员价格</td>
                                <td align="left" >
                                    ￥ <%#GetVarMBP(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
                                    </td>
                            </tr>
                            <tr align =left valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center" >
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'
                                        CommandName="buyBook">购买</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>