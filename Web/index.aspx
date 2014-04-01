<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/lanrenzhijia.css" type="text/css" rel="stylesheet" />
<script src="http://www.lanrenzhijia.com/images/jquery.js" type="text/javascript"></script>
<script src="js/lanrenzhijia.js" type="text/javascript"></script>
    <style type="text/css">
        div
        {
            font-size: 12px;
            line-height: 120%;
        }
        .divfloat
        {
            float: left;
        }
        .divh
        {
            height: 30px;
            line-height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="border-bottom: #e1e1e1 1px solid;box-shadow: #e1e1e1 0 0 5px; margin-bottom:50px;">
            <div style="height: 40px; text-align: left; line-height: 40px; width: 1080px; margin:0 auto; ">
                <div class="divfloat" style="width:90px;vertical-align:top;height:40px; line-height:40px;"><img src="images/1.png" alt="" /></div>
                <div class="divfloat" style="width:990px;vertical-align:top;height:40px; line-height:40px; font-size:12px;">Marsz.name</div>
                

                <div class="divfloat" style="width:90px;vertical-align:top;height:40px; line-height:40px;">&nbsp;</div>
                <div class="divfloat" style="width:990px;vertical-align:top;height:40px; line-height:40px; text-align:left;"><img src='/images/makewebnotwar.png' style="margin-top:15px;" /></div>
                

            </div>
        </div>
        <div id="lanrenzhijia">
<a class="pre" title="Previous"></a>
<div id="wai_box">
<div class="lanrenzhijia_box">
    <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <%--<li>
		        <a href="<%# "html/"+DateTime.Parse(Eval("addtime").ToString()).Year+ "/" +Eval("id")+ ".html" %>" target="_blank">
			        <div class="toll_img"><img alt="" src="<%# Eval("cover") %>" /></div>
			        <div class="toll_info"><%# Eval("title") %><br />via <%# Eval("boardname") %></div>
		        </a>
	        </li>--%>

                    <li><a href="<%# "html/"+DateTime.Parse(Eval("addtime").ToString()).Year+ "/" +Eval("id")+ ".html" %>" class="images"><img alt="" src="<%# Eval("cover") %>" /></a><span class="title"><%# Eval("title") %></span><span class="title2"><%# Eval("addtime","{0:yy-MM-dd}") %></span></li>
                </ItemTemplate>
            </asp:Repeater>
    </div>
</div>
<a class="next" title="Next"></a>
	<div class="nav">
	<a class="now"></a>
	<a ></a>
	<a ></a>
	</div>
    </div>
        <div style="text-align:center; vertical-align: top; width:100%; float:left; vertical-align:top; margin-top: 20px; border-top:#e1e1e1 1px solid;">
                <div class="divh">Marsz.name@<asp:Label ID="year" runat="server" Text=""></asp:Label>  沪ICP备10017466号</div>
                <div class="divh">
                    <img alt="" src="images/icon_weibo.jpg" border="0" align="absmiddle" /> @_Marsz
                    <img alt="" src="images/icon_qq.jpg" border="0" align="absmiddle" /> 121992814
                    <img alt="" src="images/icon_mail.jpg" border="0" align="absmiddle" /> m@marsz.name 
                </div>
            <div class="divh">
                推荐使用
                <a href="http://www.google.cn/intl/zh-CN/chrome/browser/index.html#eula" target="_blank"><img src="/images/icon_chrome.png" align="absmiddle" alt="" /></a> ，<img src="/images/icon_ie.png"  align="absmiddle" border='0' />呵呵
            </div>
            </div>
    </form>
</body>
</html>
