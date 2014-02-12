<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentList.aspx.cs" Inherits="Web.mzBoard.ContentList" MasterPageFile="~/mzBoard/Site.Master" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <link rel="stylesheet" type="text/css" href="../css/lrtk.css" />
    <script type="text/javascript" src="../incobj/jquery.js"></script>
<script type="text/javascript" src="../incobj/js.js"></script>


    <div id="alert" runat="server" class="divall" style="display:none;">参数错误</div>
    <div class="divh" style="width:100%;">
    <div class="divfloat" style="width:80%;">
    <asp:DataList ID="DataList2" CellPadding="0" CellSpacing="0" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
    <ItemTemplate>
    <%# Eval("id").ToString()==Request.QueryString["id"].ToString()?"<b>"+Eval("boardname")+"</b>":"<a href='ContentList.aspx?id="+Eval("id")+"'>"+Eval("boardname")+"</a>" %> | 
    </ItemTemplate>
    </asp:DataList>
    </div>
    <div class="divfloat" style="width:20%; text-align:right;">
    该分类下共<asp:Label ID="number" runat="server" Text=""></asp:Label>篇文章
    </div>
    </div>
    <div style="margin-top:15px;">
        <ul class="box">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <li>
		        <a href="Insert.aspx?id=<%# Eval("id") %>">
			        <div class="toll_img"><img alt="" src="<%# Eval("cover") %>" /></div>
			        <div class="toll_info"><%# Eval("title") %><br />via <%# Eval("boardname") %><br /> at <%# Eval("addtime","{0:yyyy-MM-dd}")%></div>
		        </a>
	        </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>

<webdiyer:aspnetpager id="AspNetPager1" runat="server" urlpaging="True" PageSize="15" numericbuttoncount="5" horizontalalign="Left" PageButtonCount="4" width="100%"></webdiyer:aspnetpager>

</asp:Content>