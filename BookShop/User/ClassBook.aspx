<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ClassBook.aspx.cs" Inherits="User_ClassBook" Title="图书分类" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">

   
        <asp:Label ID="lbClassName" runat="server" Text="Label" style=" font-size:24px; border-bottom: 2px solid #eee; width:840px; "></asp:Label>
                <asp:DataList ID="DLClass" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" DataKeyField ="BookID" OnItemCommand="DLClass_ItemCommand" CellPadding="4" ForeColor="#333333">
                    <ItemTemplate>
                        <table align="center"  cellpadding="10" cellspacing="10" style =" width :280px; height:200px;" >
                            <tr align =center  style =" height:150px;">
                                <td colspan="2" align="center">
                                    <asp:Image ID="imageRefine" runat="server"  ImageUrl =<%#DataBinder.Eval(Container.DataItem,"BookUrl")%> Height="150px" Width="105px"/></td>
                            </tr>
                            <tr align=center     valign =bottom style ="height:10px;font-size: 10pt;">
                                <td colspan="2" align="center">
                                    <%#DataBinder.Eval(Container.DataItem, "BookName")%>
                                </td>
                            </tr>
                            <tr align="center" style =" color:gray;">
                                <td align="center" colspan="2">
                                    Market Price: ￥ <%#GetVarMKP(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                </td>
                            </tr>
                            <tr align="center" style =" color:red; font-weight: bold;">
                                <td align="center" colspan="2">
                                    Member Price: ￥<%#GetVarMBP(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%></td>
                            </tr>
                            <tr align="center" style ="height:15px;font-size:12pt;">
                                <td style="width:120px">
                                    <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="detailSee" >Details</asp:LinkButton>
                                </td>
                                <td style="width:160px">
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" CommandName="buyBook"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"MemberPrice") %>' >Add to Cart</asp:LinkButton>
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

