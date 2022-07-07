<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="User_SearchResult" Title="Search result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FartherMain" Runat="Server">

    <div style ="width:840px;">
        <h3 style ="border-bottom: 2px solid #eee">Search Result</h3>
    </div>
              <asp:DataList ID="DLsearch" DataKeyField ="BookID" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"  OnItemCommand="DLsearch_ItemCommand" CellPadding="4" ForeColor="#333333">
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
                                    Market Price: ￥<%#GetVarMKP(DataBinder.Eval(Container.DataItem, "MarketPrice", "{0:f2}").ToString())%>
                                </td>
                            </tr>
                           <tr align =center style =" color: red; font-weight: bold;" >
                                <td colspan="2" align="center" >
                                   Member Price: ￥<%#GetVarMBP(DataBinder.Eval(Container.DataItem, "MemberPrice", "{0:f2}").ToString())%>
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
</asp:Content>