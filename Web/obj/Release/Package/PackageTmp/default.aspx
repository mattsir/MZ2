<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web._default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marsz.Name</title>
<link rel="stylesheet" type="text/css" href="css/lrtk.css" />
<script type="text/javascript" src="incobj/jquery.js"></script>
<script type="text/javascript" src="incobj/js.js"></script>

    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-32357107-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div style="border-bottom: #e1e1e1 1px solid;box-shadow: #e1e1e1 0 0 5px; margin-bottom:50px;">
            <div style="height: 40px; text-align: left; line-height: 40px; width: 1116px; ">
                <div class="divfloat" style="width:90px;vertical-align:top;height:40px; line-height:40px;"><img src="images/1.png" alt="" /></div>
                <div class="divfloat" style="width:1026px;vertical-align:top;height:40px; line-height:40px;">&nbsp;</div>
                

                <div class="divfloat" style="width:90px;vertical-align:top;height:40px; line-height:40px;">&nbsp;</div>
                <div class="divfloat" style="width:1026px;vertical-align:top;height:40px; line-height:40px; text-align:left;"><img src='/images/makewebnotwar.png' style="margin-top:15px;" /></div>
                

            </div>
        </div>
        <div style="width:1216px;">
        <div id="pageleft" runat="server" style="height:50px; width:50px;float:left;"></div>
        <div style="width: 1116px;background-color:#fff;float:left;">
        <ul class="box">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li>
		        <a href="<%# "html/"+DateTime.Parse(Eval("addtime").ToString()).Year+ "/" +Eval("id")+ ".html" %>" target="_blank">
			        <div class="toll_img"><img alt="" src="<%# Eval("cover") %>" /></div>
			        <div class="toll_info"><%# Eval("title") %><br />via <%# Eval("boardname") %></div>
		        </a>
	        </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        </div>
        <div id="pageright" runat="server" style="height:50px; width:50px;float:left;"></div>
            </div>

            <div style="text-align:center; vertical-align: top; width:100%; float:left; vertical-align:top; margin-top: 10px; border-top:#e1e1e1 1px solid;">
                <div class="divh">Marsz.name@2013  沪ICP备10017466号</div>
                <div class="divh">
                    <img alt="" src="images/icon_weibo.jpg" border="0" align="absmiddle" /> @_Marsz
                    <img alt="" src="images/icon_qq.jpg" border="0" align="absmiddle" /> 121992814
                    <img alt="" src="images/icon_mail.jpg" border="0" align="absmiddle" /> m@marsz.name
                </div>
                <div style="margin-top:10px;">
                推荐使用
                <a href="http://www.google.cn/intl/zh-CN/chrome/browser/index.html#eula" target="_blank"><img src="/images/icon_chrome.png" align="absmiddle" alt="" /></a>
                 <a href='http://download.firefox.com.cn/releases/webins3.0/official/zh-CN/Firefox-latest.exe' target="_blank"><img src="/images/icon_firefox.png" align="absmiddle" alt='Spread Firefox Affiliate Button' border='0' /></a>，只要不是<img src="/images/icon_ie.png"  align="absmiddle" border='0' />就可以
                    </div>
            </div>

    </center>
    </form>
</body>
</html>
