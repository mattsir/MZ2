<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContentList.aspx.cs" Inherits="Web.mzBoard.ContentList" MasterPageFile="~/mzBoard/Site.Master" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <link rel="stylesheet" type="text/css" href="../css/lrtk.css" />
    <script type="text/javascript" src="../incobj/jquery.js"></script>
<script type="text/javascript" src="../incobj/js.js"></script>


    <div class="divfloat" style="width:100%;">该分类下共<asp:Label ID="number" runat="server" Text=""></asp:Label>篇文章</div>

    <div style="margin-top:15px;">

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="divfloatbottom" style="width:100%;">
                    <div class="divfloat" style="width:500px;"><%# Eval("Title") %></div>
                     <div class="divfloat" style="width:150px;"><%# Eval("Addtime","{0:yyyy-MM-dd}") %></div>
                    <div class="divfloatright">编辑</div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>

<webdiyer:aspnetpager id="AspNetPager1" runat="server" urlpaging="True" PageSize="15" numericbuttoncount="5" horizontalalign="Left" PageButtonCount="4" width="100%"></webdiyer:aspnetpager>

</asp:Content>