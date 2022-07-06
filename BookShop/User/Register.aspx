<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register"  MasterPageFile="~/MasterPage/MasterPage.master" Title ="会员注册"%>
<asp:Content ID =Content1 ContentPlaceHolderID =FartherMain runat =server >
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <style>
        .button-save {
        background-color: #4CAF50;
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        width:200px;
}
        .button-return {
        background-color: red;
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
        margin: 4px 2px;
        cursor: pointer;
        width:200px;
}
    </style>

	<div class="container"style="width:60%">
            <div class="panel panel-default">

            <div class="panel-heading">
            <h3>Fill in Your Information</h3>
            </div>

            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Username:" ID="label1"></asp:Label>
            <asp:textbox id="txtName" runat="server"  class="form-control"></asp:textbox>
            <asp:RequiredFieldValidator ID="rfvLoginName" runat="server" ControlToValidate="txtName" Font-Size="9pt"
                Height="20px"  Display="Dynamic">Username cannot be NULL.</asp:RequiredFieldValidator>
            </div>
            </div>

            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Password:" ID="label2"></asp:Label>
            <asp:textbox id="txtPassword" runat="server"  MaxLength="50" TextMode="Password" class="form-control"></asp:textbox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Font-Size="9pt"
                 Height="20px">Password cannot be NULL.</asp:RequiredFieldValidator>
            </div>
            </div>

            
            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Gender:" ID="label3"></asp:Label>
                <br/>
            <asp:dropdownlist id="ddlSex" runat="server" Height="30px" Width="80px" Font-Size = "9pt">
                <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                <asp:ListItem Value="0">Female</asp:ListItem>
            </asp:dropdownlist>
            </div>
            </div>

            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Real Name:" ID="label4"></asp:Label>
            <asp:textbox id="txtTrueName" runat="server"  MaxLength="50" class="form-control"></asp:textbox>
            <asp:RequiredFieldValidator ID="rfvTrueName" runat="server" ControlToValidate="txtName" Font-Size="9pt"
                Height="20px">Real Name cannot be NULL.</asp:RequiredFieldValidator>
            </div>
            </div>

             <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="City:" ID="label5"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlCity" runat="server" Width="127px" Font-Size="9pt">
                                <asp:ListItem>Beijing</asp:ListItem>
                                <asp:ListItem>Fuzhou</asp:ListItem>
                                <asp:ListItem>Xiamen</asp:ListItem>
                                <asp:ListItem>Shanghai</asp:ListItem>
                                <asp:ListItem>Sanming</asp:ListItem>
                                <asp:ListItem>Wuhan</asp:ListItem>
                                <asp:ListItem>Changsha</asp:ListItem>
                                <asp:ListItem>Chengdu</asp:ListItem>
                                <asp:ListItem>Hongkong</asp:ListItem>
                                <asp:ListItem>Selangor</asp:ListItem>
                                <asp:ListItem>Xian</asp:ListItem>
                                <asp:ListItem>Zhangzhou</asp:ListItem>
                                <asp:ListItem>Hangzhou</asp:ListItem>
                            </asp:DropDownList>
            </div>
            </div>

            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Address:" ID="label6"></asp:Label>
            <asp:textbox id="txtAddress" runat="server"  MaxLength="100" class="form-control" TextMode="MultiLine" Height="30px"></asp:textbox>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtName" Font-Size="9pt" Height="20px" >
               Address cannot be NULL</asp:RequiredFieldValidator>
            </div>
            </div>

             <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Post Code:" ID="label8"></asp:Label>
            <asp:textbox id="txtPostCode" runat="server"  MaxLength="50" class="form-control"></asp:textbox>
            <asp:RegularExpressionValidator ID="revPostCode" runat="server" ControlToValidate="txtPostCode" Font-Size="9pt" ValidationExpression="\d{6}">
                Please input correct Post Code.</asp:RegularExpressionValidator>
            </div>
            </div>

            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Phone Number:" ID="label7"></asp:Label>
            <asp:textbox id="txtPhone" runat="server"  MaxLength="50" class="form-control"></asp:textbox>
            <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Wrong Number, Please input again." ValidationExpression="(\d3,4|\d{3,4}-|\s)?\d{7,14}">
                </asp:RegularExpressionValidator>			
            </div>
            </div>

            <div class="panel-body">
            <div class="form-group">
            <asp:Label runat="server" Text="Email:" ID="label9"></asp:Label>
            <asp:textbox id="txtEmail" runat="server"  MaxLength="00" class="form-control"></asp:textbox>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Font-Size="9pt" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="220px">
                Invalid E-mail. Please input again.</asp:RegularExpressionValidator>
            </div>
            </div>

            <div>
                <center>
                <asp:button id="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="button-save"></asp:button>
                <asp:Button ID="btnReturn" runat="server" Text="Return" CausesValidation="False" OnClick="btnReturn_Click" class="button-return"/>
                </center>
             </div>
  

        </div>
        </div>
   
   </asp:Content>

