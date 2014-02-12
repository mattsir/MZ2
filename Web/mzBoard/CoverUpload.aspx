<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoverUpload.aspx.cs" Inherits="Web.mzBoard.CoverUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../incObj/css.css" rel="stylesheet" type="text/css" />
</head>
<body class="pagepad20" style="background-color:#fff;">
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <span class="fontgary">建议尺寸125px * 125px，建议格式jpg、png</span>
    <asp:Label ID="errMessage" runat="server" CssClass="fontred" Text=""></asp:Label>
    <div>
<div class="btn1"><img src="../images/icon_save.gif" /></div>
                <div class="btn2">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">上传</asp:LinkButton></div>
                <div class="btn3"></div>
        </div>
    </div>
    </form>
</body>
</html>
