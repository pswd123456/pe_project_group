<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="User_SearchResult" Title="Search result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Info of the book you finding："></asp:Label><br />
    <asp:DataList ID="DLsearch" runat="server" DataKeyField ="BookID" RepeatColumns="3" RepeatDirection="Horizontal" CellPadding="4" ForeColor="#333333" OnItemCommand="DLsearch_ItemCommand">
    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;" >
                            <tr align =center style =" width :135px; height:65px;" >
                                <td colspan="2" align="center" >
                                    <asp:Image ID="imageRefine" Width=70px Height=100px runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/></td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px; font-size: 9pt; font-family: Microsoft YaHei;">
                                <td colspan="2" align="center">
                                    <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px; font-size: 9pt; font-family: Microsoft YaHei;">
                                <td align="center" >
                                    Market Price</td>
                                <td align="left" >
                                    ￥ <%#GetVarMKP(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                    </td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: Microsoft YaHei;">
                                <td align="center" >
                                    Member Price</td>
                                <td align="left" >
                                    ￥ <%#GetVarMBP(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
                                    </td>
                            </tr>
                            <tr align =left valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: Microsoft YaHei;">
                                <td colspan="2" align="center" >
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">Detail</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'
                                        CommandName="buyBook">Buy</asp:LinkButton>
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