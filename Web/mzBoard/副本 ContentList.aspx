<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentList.aspx.cs" Inherits="Web.mzBoard.ContentList" MasterPageFile="~/mzBoard/Site.Master" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <link rel="stylesheet" type="text/css" href="../css/lrtk.css" />
    <script type="text/javascript" src="../incobj/jquery.js"></script>
<script type="text/javascript" src="../incobj/js.js"></script>
<%--加载fancybox--%>
<script src="../IncObj/fancybox/jquery-1.4.3.min.js" type="text/javascript"></script>
<script src="../IncObj/fancybox/fancybox/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
<link href="../IncObj/fancybox/fancybox/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <script src="../incObj/mzblog.js" type="text/javascript"></script>

        <script type="text/javascript">
            $(document).ready(function () {
                $("#AddCate").fancybox({
                    'autoScale': false,
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'type': 'iframe',
                    'height': 150,
                    'width': 400,
                    'padding': '0'
                });

                $("#ctl00_ContentPlaceHolder1_EditLink").fancybox({
                    'autoScale': false,
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'type': 'iframe',
                    'height': 150,
                    'width': 400,
                    'padding': '0'
                });
                $("#ctl00_ContentPlaceHolder1_DeleLink").fancybox({
                    'autoScale': false,
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'type': 'iframe',
                    'height': 150,
                    'width': 400,
                    'padding': '0'
                });
                
            });  
    </script>

    <div id="alert" runat="server" class="divall" style="display:none;">参数错误</div>
    <div class="divh" style="width:100%;">
    <div class="divfloat divbottom" style="width:80%;">
    <asp:DataList ID="DataList2" CellPadding="0" CellSpacing="0" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
    <ItemTemplate>
    <%# Eval("id").ToString()==Request.QueryString["id"].ToString()?"<b>"+Eval("boardname")+"</b>":"<a href='ContentList.aspx?id="+Eval("id")+"'>"+Eval("boardname")+"</a>" %> | 
    </ItemTemplate>
    </asp:DataList>
    </div>
    <div class="divfloat divbottom" style="width:20%; text-align:right;">
    <a href="Insert.aspx">添加文章</a> <a id="AddCate" href="CategoryUpdate.aspx?id=0">添加分类</a>
    </div>
    </div>
    <div class="divh" style="width:100%; margin-bottom:20px;">
    <img src="../images/icon_article.gif" align="absmiddle" />该分类下共<asp:Label ID="number" runat="server" Text=""></asp:Label>篇文章&nbsp;&nbsp;<img src="../images/icon_edit.gif" align="absmiddle" /><asp:HyperLink
        ID="EditLink" runat="server">编辑分类</asp:HyperLink>&nbsp;&nbsp;<img src="../images/icon_trash.gif" align="absmiddle" /><asp:HyperLink
            ID="DeleLink" runat="server">删除分类</asp:HyperLink>&nbsp;&nbsp;
            <img src="../images/icon_tools.gif" align="absmiddle" /><asp:LinkButton ID="LinkButton1"
                runat="server" onclick="LinkButton1_Click" OnClientClick="return confirm('确认清空内容？');">清空内容</asp:LinkButton>
            </div>
        <ul class="box">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li>
		        <a href="<%# "html/"+DateTime.Parse(Eval("addtime").ToString()).Year+ "/" +Eval("id")+ ".html" %>" target="_blank">
			        <div class="toll_img"><img alt="" src="<%# Eval("cover") %>" /></div>
			        <div class="toll_info"><%# Eval("title") %><br />via <%# Eval("boardname") %> <%# Eval("addtime","{0:yyyy-MM-dd}")%></div>
                    
		        </a>
	        </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>


<asp:DataList ID="DataList1" CellPadding="0" CellSpacing="0" Width="100%" runat="server">
    <ItemTemplate>
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td class="divh">
                    <a href="/html/<%# Eval("addtime","{0:yyyy}")%>/<%# Eval("id") %>.html" target="_blank"><%# Eval("title") %></a>
                </td>
                <td style="width:80px;">
                    <%# Eval("boardname")%>
                </td>
                <td style="width:100px;">
                    <%# Eval("addtime","{0:yyyy-MM-dd}")%>
                </td>
                <td style="width:80px;">
                   <a href="Insert.aspx?id=<%# Eval("id") %>">编辑</a> <a href="ContentDelete.aspx?id=<%# Eval("id") %>&file=<%# DateTime.Parse(Eval("addtime").ToString()).Year %>" onclick="return confirm('确认删除')";>删除</a>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    </asp:DataList>
<webdiyer:aspnetpager id="AspNetPager1" runat="server" urlpaging="True" PageSize="15" numericbuttoncount="5" horizontalalign="Left" PageButtonCount="4" width="100%"></webdiyer:aspnetpager>
</asp:Content>