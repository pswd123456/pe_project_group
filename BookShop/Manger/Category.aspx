<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Manger_Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图书类别管理</title>
</head>
<body style ="font-family :宋体; font-size :9pt;">
    <form id="form1" runat="server">
    <div>
    <table class="tableBorder" cellSpacing="0" cellPadding="0" width="450" align="center" border="0" bgcolor="#EFF3FB">
				<tr>
					<th class="tableHeaderText" height="25" align="left">
						图书类别管理</th>
					
				<tr>
				</tr>
			</table>
			<table class="tableBorder" cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td height="23" class="forumRowHighlight">
                        <asp:GridView ID="gvCategoryList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="20" DataKeyNames ="ClassID"  Width="100%" HorizontalAlign="Center"
							HeaderStyle-CssClass="summary-title" OnPageIndexChanging="gvCategoryList_PageIndexChanging" OnRowDeleting="gvCategoryList_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None">
							<HeaderStyle Font-Bold="True" BackColor="#507CD1" CssClass="summary-title" ForeColor="White"></HeaderStyle>
                            <Columns>
                                <asp:BoundField DataField="ClassID" HeaderText="分类ID" >
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ClassName" HeaderText="类别名称" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:CommandField ShowDeleteButton="True" >
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
					</td>
				</tr>
			</table>

    </div>
    </form>
</body>
</html>
