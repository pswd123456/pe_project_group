<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RHDBook.aspx.cs" Inherits="User_RHDBook" Title="图书信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
   <table style=" font-size: 9pt; font-family: 宋体;" runat =server id="tabRefine"  >
        <tr>
            <td align="left" style ="width :560px; height :22px;" background ="../Images/index/精品推荐.jpg">
              </td>
        </tr>
        <tr>
            <td align="left" style ="width :560px; " background="../Images/index/图书展销---最底部.jpg"  >
                <asp:DataList ID="DLrefinement" DataKeyField ="BookID" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DLrefinement_ItemCommand">
                    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;" >
                            <tr align =center   style =" width :135px; height:65px;font-size: 9pt; font-family: 宋体;" >
                                <td colspan="2" >
                                    <asp:Image ID="imageRefine" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/></td>
                            </tr>
                            <tr align =center  valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center   valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    市场价格</td>
                                <td align="left" >￥
                                    <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice").ToString())%></td>
                            </tr>
                            <tr align =center   valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    会员价格</td>
                                <td align="left" >￥
                                    <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice").ToString())%></td>
                            </tr>
                            <tr align =center   valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2">
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MemberPrice") %>'>购买</asp:LinkButton></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList></td>
        </tr>
    </table>
    <table style="font-size: 9pt; font-family: 宋体;" runat =server id ="tabHot"　>
        <tr>
            <td align="left" style ="width :560px; height :22px;" background ="../Images/index/热销图书.jpg">
               </td>
        </tr>
        <tr>
            <td style ="width :560px; height :157px;" background ="../Images/index/精品推荐下面部分.jpg"  align="left">
                <asp:DataList ID="DLHot" DataKeyField ="BookID" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DLHot_ItemCommand">
                    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;">
                            <tr align =center style =" width :135px; height:65px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center" > <asp:Image ID="imageHot" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/>
                                </td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;" align =center>
                                <td colspan="2" align="center">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    市场价格</td>
                                <td align="left">￥
                                    <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice").ToString())%></td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    会员价格</td>
                                <td align="left">￥
                                    <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice").ToString())%></td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2">
                                     &nbsp; &nbsp;
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MemberPrice") %>'>购买</asp:LinkButton></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList></td>
        </tr>
    </table>
     <table style="font-size: 9pt; font-family: 宋体;" runat=server id="tabDiscount">
        <tr>
            <td align="left" style ="width :560px; height :22px;" background ="../Images/index/特价图书.jpg">
               </td>
        </tr>
        <tr>
            <td align="left" style ="width :560px; height :157px;" background ="../Images/index/精品推荐下面部分.jpg">
                <asp:DataList ID="DLDiscount" DataKeyField ="BookID" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DLDiscount_ItemCommand">
                    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;">
                            <tr align =center  style =" width :135px; height:65px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center" ><asp:Image ID="imageDiscount" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/>
                                </td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;" align =center>
                                <td colspan="2">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    市场价格</td>
                                <td align="left">￥
                                    <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice").ToString())%></td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    会员价格</td>
                                <td align="left">￥
                                    <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice").ToString())%></td>
                            </tr>
                            <tr valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2">
                                     &nbsp; &nbsp;
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"MemberPrice") %>'>购买</asp:LinkButton></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList></td>
        </tr>
    </table>
</asp:Content>

