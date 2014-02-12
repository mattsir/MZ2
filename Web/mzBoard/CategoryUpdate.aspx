<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryUpdate.aspx.cs" Inherits="Web.mzBoard.CategoryUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body class="pagepad20">
    <form id="form1" runat="server">
    <div>
    <div id="alert" runat="server" class="divall" style="display:none;">参数错误</div>
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td class="divh" style="width:100px;">
                    分类名称</td>
                <td>
                    <asp:TextBox ID="name" CssClass="textbox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="*" ControlToValidate="name"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="id" runat="server" Visible="false" Text="0"></asp:Label>
                </td>
                <td>
                    <div class="btn1"><img src="../images/icon_save.gif" /></div>
                <div class="btn2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">保存</asp:LinkButton></div>
                <div class="btn3"></div>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
