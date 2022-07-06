<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ClassBook.aspx.cs" Inherits="User_ClassBook" Title="图书分类" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
<table style=" font-size: 9pt; font-family: 宋体;"  >
        <tr>
            <td align="left"  style ="width :560px; height :19px;"  background ="../Images/index/名字空白.JPG" >
                &nbsp;&nbsp; &nbsp;<asp:Label ID="lbClassName" runat="server" Text="Label" Font-Names="宋体" Font-Bold="True" ></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style ="width :560px; " background="../Images/index/图书展销---最底部.jpg" >
                <asp:DataList ID="DLClass" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" DataKeyField ="BookID" OnItemCommand="DLClass_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="left"  cellpadding=0 cellspacing=0 style =" width :135px; height:158px;" >
                            <tr align =center  style =" width :135px; height:65px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" >
                                    <asp:Image ID="imageRefine" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%> Height="100px" Width="70px"/></td>
                            </tr>
                            <tr align=center     valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    市场价格</td>
                                <td align="left" >
                                    ￥ <%#GetVarMKP(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    会员价格</td>
                                <td align="left" >
                                    ￥ <%#GetVarMBP(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="left">
                                    &nbsp; &nbsp;
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>' >购买</asp:LinkButton></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:DataList></td>
        </tr>
    </table>
</asp:Content>

