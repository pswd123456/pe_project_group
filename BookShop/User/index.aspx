<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="网上书店首页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server" >
<table  cellpadding=0 cellspacing=0  style=" font-size: 9pt; font-family: 宋体;width :760px; vertical-align :top ; border-top-style: none; border-right-style: none; border-left-style: none; text-align: left; border-bottom-style: none;"  >
        <tr align="left">
            <td  align="left" style="width :560px;height :22px; vertical-align: top; text-align: left;" colspan="0" rowspan="0" background ="../Images/index/精品推荐.jpg" >
             </td>
        </tr>

        <tr>
            <td align="left" style ="width :560px; " background ="../Images/index/精品推荐下面部分.jpg">
                <asp:DataList ID="DLrefinement" DataKeyField ="BookID" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"  OnItemCommand="DLrefinement_ItemCommand" CellPadding="4" ForeColor="#333333">
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
                                    ￥ <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                    </td>
                            </tr>
                            <tr align =center valign =bottom style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center" >
                                    会员价格</td>
                                <td align="left" >
                                    ￥ <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
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
                    
              
            </td>
        </tr>
    </table>
    <table style="font-size: 9pt; font-family: 宋体;" cellpadding=0 cellspacing=0>
        <tr>
            <td align="left" style="width :560px; height :22px; vertical-align: top; text-align: left;" background ="../Images/index/热销图书.jpg">
                </td>
        </tr>
        <tr>
            <td style ="width :560px; " background ="../Images/index/精品推荐下面部分.jpg" align="left">
                <asp:DataList ID="DLHot" runat="server" DataKeyField ="BookID" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DLHot_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;" >
                            <tr align =center style =" width :135px; height:65px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2"> <asp:Image ID="imageHot" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%> Height="100px" Width="70px"/>
                                </td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    市场价格</td>
                                <td align="left">
                                    ￥ <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    会员价格</td>
                                <td align="left">
                                    ￥ <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align =center >
                                   
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >详细</asp:LinkButton>
                                     <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'>购买</asp:LinkButton>
                                  </td>
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
     <table style=" font-size:9pt; font-family: 宋体; vertical-align: top; text-align: left;"cellpadding=0 cellspacing=0>
        <tr>
             <td align="left" style ="width :560px; height :22px;" background ="../Images/index/特价图书.jpg">
                </td>
        </tr>
        <tr>
            <td align="left" style ="width :560px; " background="../Images/index/图书展销---最底部.jpg" >
                <asp:DataList ID="DLDiscount" runat="server" DataKeyField ="BookID" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DLDiscount_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="left" cellpadding=0 cellspacing=0 style =" width :135px; height:158px;" >
                            <tr align =center valign =bottom  style =" width :135px; height:65px;font-size: 9pt; font-family: 宋体;" >
                                <td colspan="2"><asp:Image ID="imageDiscount" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%> Height="100px" Width="70px"/>
                                </td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td colspan="2" align="center">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    市场价格</td>
                                <td align="left">
                                    ￥ <%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                                <td align="center">
                                    会员价格</td>
                                <td align="left">
                                    ￥ <%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt; font-family: 宋体;">
                              
                                    <td colspan="2" align="center">
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >详细</asp:LinkButton>
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'>购买</asp:LinkButton>
                                  </td>
                                   
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



