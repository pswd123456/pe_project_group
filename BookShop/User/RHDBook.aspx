<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RHDBook.aspx.cs" Inherits="User_RHDBook" Title="图书信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">
   
    <div id="tabRefine" runat="server">
    <div style ="width:840px;">
        <h3 style ="border-bottom: 2px solid #eee">Recommendation</h3>
    </div>
              <asp:DataList ID="DLrefinement" DataKeyField ="BookID" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"  OnItemCommand="DLrefinement_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="center" cellpadding="10" cellspacing="10" style =" width :280px; height:200px;" >
                            <tr align =center style ="  height:150px;" >
                                <td colspan="2" align="center" >
                                    <asp:Image ID="imageRefine" width=105px height=150px runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/>

                                </td>
                            </tr>
                            <tr align =center valign =bottom style =" height:10px; font-size: 10pt; ">
                                <td colspan="2" align="center">
                                    <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center style ="  color: gray;" >
                                <td colspan="2" align="center" >
                                    Market Price: ￥<%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%></td>
                            </tr>
                           <tr align =center style =" color: red; font-weight: bold;" >
                                <td colspan="2" align="center" >
                                   Member Price: ￥<%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align="center" style ="height:15px;font-size: 12pt; ">
                                <td style="width:120px">
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">Details</asp:LinkButton>
                                </td>
                                <td style="width:160px">
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'
                                        CommandName="buyBook">Add to Cart</asp:LinkButton>
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
        </div>


    <%--<table style="font-size: 9pt; font-family: 宋体;" runat =server id ="tabHot"　>
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
    </table>--%>

    <div id="tabHot" runat="server">
    <div style ="width:840px;">
        <h3 style ="border-bottom: 2px solid #eee">Hot-Sale</h3>
    </div>
                <asp:DataList ID="DLHot" runat="server" DataKeyField ="BookID" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DLHot_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="center" cellpadding=0 cellspacing=0 style =" width :280px; height:180px;" >
                            <tr align =center style =" width : 200px; height:65px;">
                                <td colspan="2" align="center"> 
                                    <asp:Image ID="imageHot" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%> Height="150px" Width="105px"/>
                                </td>
                            </tr>
                            <tr align =center valign =bottom  style =" width :135px; height:11px;font-size: 9pt;">
                                <td colspan="2" align="center">
                                <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center style =" width :200px; color:gray;">
                                <td align="center" colspan="2">
                                    Market Price: ￥<%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align =center style =" width :200px; font-weight: bold; color: red">
                                <td colspan="2" align="center">
                                    Member Price: ￥<%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align="center"  style =" height:15px;font-size: 12pt;">
                                <td style="width:120px">
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">Details</asp:LinkButton>
                                </td>
                                <td style="width:160px">
                                   <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'>
                                       Add to Cart</asp:LinkButton>
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
        </div>

     <%--<table style="font-size: 9pt; font-family: 宋体;" runat=server id="tabDiscount">
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
</asp:Content>--%>

    <div id="tabDiscount" runat="server">
    <div style ="width:840px;">
        <h3 style ="border-bottom: 1px solid #eee">Discount</h3>
    </div>
                <asp:DataList ID="DLDiscount" runat="server" DataKeyField ="BookID" RepeatColumns="3" RepeatDirection="Horizontal" OnItemCommand="DLDiscount_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="center" cellpadding="10" cellspacing="10" style =" width :280px; height:200px;" >
                            <tr align =center style ="  height:150px;" >
                                <td colspan="2" align="center" >
                                    <asp:Image ID="imageRefine" width=105px height=150px runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%>/></td>
                            </tr>
                            <tr align =center valign =bottom style =" height:10px; font-size: 10pt; ">
                                <td colspan="2" align="center">
                                    <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align =center style ="  color: gray;" >
                                <td colspan="2" align="center" >
                                    Market Price: ￥<%#GetMKPStr(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                </td>
                            </tr>
                           <tr align =center style =" color: red; font-weight: bold; width :200px;" >
                                <td colspan="2" align="center" >
                                   Member Price: ￥<%#GetMBPStr(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
                                </td>
                            </tr>
                            <tr align="center" style ="height:15px;font-size: 12pt; ">
                                <td style="width:120px">
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee">Details</asp:LinkButton>
                                </td>
                                <td style="width:160px">
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>'
                                        CommandName="buyBook">Add to Cart</asp:LinkButton>
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
        </div>
    <br/>
</asp:Content>



