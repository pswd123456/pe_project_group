  <%@ Control Language="C#" AutoEventWireup="true" CodeFile="navigationControl.ascx.cs" Inherits="UserControl_navigationControl" %>
 <table  style="width: 250px; height: 549px; font-size: 9pt; vertical-align :top ; margin-left:15px; margin-top:100px;"  border="0" cellpadding="0" cellspacing="0" margin="20px" >
    <tr valign =top  align =center >
        <td>
         <asp:DataList ID="DLClass" runat="server" DataKeyField="ClassID" OnEditCommand="DLClass_EditCommand"   >
           
                <ItemTemplate>
                    <table >
                        <tr>
                            <td align =left style ="width :250px; height:30px; font-size: 15px;" > 
                            <asp:LinkButton ID="lnkbtnClass" runat="server" CommandName="Edit" CausesValidation="False" BackColor="WhiteSmoke" Width="250px" Height="30px" BorderWidth="2px" BorderColor="White" Align="Center" ><%# DataBinder.Eval(Container.DataItem, "ClassName") %></asp:LinkButton>
                            </td>
                        </tr>
                        
                    </table>
                    
                </ItemTemplate>
            </asp:DataList>
         
            
            </td>
    </tr>
</table>

