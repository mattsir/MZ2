<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryDelete.aspx.cs" Inherits="Web.mzBoard.CategoryDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../incObj/css.css" rel="stylesheet" type="text/css" />
</head>
<body class="pagepad20">
    <form id="form1" runat="server">
    <div>
    <div id="alert" runat="server" class="divall" style="display:none;">参数错误</div>
        <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td class="divh" style="width:100px;">
                    删除分类</td>
                <td>
                    <asp:Label ID="catename" runat="server" Text=""></asp:Label>
                    <asp:Label ID="id" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="divh" style="width:100px;">
                    转移分类</td>
                <td>
                    <asp:DropDownList ID="changecate" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="divh" style="width:100px;">
                    &nbsp;</td>
                <td>
                    <div class="btn1"><img src="../images/icon_save.gif" /></div>
                <div class="btn2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">保存</asp:LinkButton></div>
                <div class="btn3"></div></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
