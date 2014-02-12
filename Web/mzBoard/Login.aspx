<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.mzBoard.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../incObj/css.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#fff;">
    <form id="form1" runat="server">
    <div>
    <center>
        <table cellpadding="0" cellspacing="0" class="border" style="width: 500px; margin-top:80px; background-color:#fff;box-shadow: #999999 0 0 10px;">
            <tr>
                <td colspan="2" style="padding:10px;text-align:left;background-color:#fff;"><img src="../images/marsz.gif" /></td>
            </tr>
            <tr>
                <td class="divh" style="width:80px; text-align:center;background-color:#fff;">用户</td>
                <td style="text-align:left;background-color:#fff;">
                    <input id="name" runat="server" class="textbox" type="text" /> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="divh" style="text-align:center;background-color:#fff;">密码</td>
                <td style="text-align:left;background-color:#fff;">
                    <input id="pin" runat="server" class="textbox" type="password" /> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="pin"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="divh" style="background-color:#fff;">&nbsp;</td>
                <td style="text-align:left;background-color:#fff;">
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
