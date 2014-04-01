<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Web.mzBoard.Insert" ValidateRequest="false" MasterPageFile="~/mzBoard/Site.Master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <script type="text/javascript" src="../incObj/smooth.js"></script>
    <script type="text/javascript">
        function Setag(id) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_tags").value == "") {
                document.getElementById("ctl00_ContentPlaceHolder1_tags").value = id + ",";
            }
            else {
                if (document.getElementById("ctl00_ContentPlaceHolder1_tags").value.indexOf(id) == -1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_tags").value += id + ",";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_tags").value = document.getElementById("ctl00_ContentPlaceHolder1_tags").value.replace(id + ",", "");
                }
            }
        }

    </script>
    <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
        <tr>
            <td class="divh" id="tops" style="width:100px;">
                标题 <a href="#bottoms" title="保存"><img src="../images/down_arrow.png" border="0" align="absmiddle" /></a></td>
            <td>
                <input id="title" runat="server" class="textbox" type="text" /> <span id="titlespan" class="fontred"></span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="请输入标题" ControlToValidate="title"></asp:RequiredFieldValidator>
            </td>
        </tr>
<%--        <tr>
            <td class="divh">
                分类</td>
            <td>
                <asp:RadioButtonList ID="board" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server">
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="请选择分类" ControlToValidate="board" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
        </tr>--%>
        <tr>
            <td class="divh">
                内容</td>
            <td>
               &nbsp;
                </td>
        </tr>
        <tr>
            <td class="divh" colspan="2">
 <script type="text/javascript" charset="utf-8" src="../incObj/editor/editor_config.js"></script>

    <script type="text/javascript" charset="utf-8" src="../incObj/editor/editor_all.js"></script>
    <link rel="stylesheet" type="text/css" href="../incObj/editor/themes/default/ueditor.css"/>

<script type="text/plain" id="myEditor"><%= GetContent()%></script>

<script type="text/javascript">
    var editorOption = {
        //这里可以选择自己需要的工具按钮名称,此处仅选择如下五个
        initialStyle: 'body{font-size:12px;line-height:150%;}',
        toolbars: [['FullScreen', 'Source', 'Undo', 'Redo', 'Bold', 'Italic', 'Underline', 'PastePlain', 'InsertOrderedList', 'InsertUnorderedList', 'Link', 'Unlink', 'InsertImage', 'Attachment', 'HighlightCode']],
        //focus时自动清空初始化时的内容
        autoClearinitialContent: false,
        //关闭字数统计
        wordCount: false,
        //关闭elementPath
        elementPathEnabled: false
        //更多其他参数，请参考editor_config.js中的配置项
    };
    var editor_a = new baidu.editor.ui.Editor(editorOption);
    editor_a.render('myEditor');

</script>
<span class="fontred" id="editorspan"></span>
  </td>
        </tr>
<%--        <tr>
            <td class="divh">
                简要</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="divh" colspan="2">
                <textarea id="summary" runat="server" class="textfield" cols="20" name="S1" rows="2" style="height:80px; width:85%;"></textarea> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="请填写简要" ControlToValidate="summary"></asp:RequiredFieldValidator></td>
        </tr>--%>
        <tr>
            <td class="divh">
                封面</td>
            <td>
                <input id="cover" runat="server" class="textbox" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请上传封面" ControlToValidate="cover"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="divh">
                标签</td>
            <td>
                <input id="tags" runat="server" class="textbox" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="请填写标签" ControlToValidate="tags"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="divh">
                &nbsp;</td>
            <td>
                <asp:DataList ID="taglist" CellPadding="0" CellSpacing="0" Width="100%" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                <ItemTemplate>
                <div class="divfloat"><a href="javascript:void(0);" onclick=Setag('<%# Eval("name") %>')><%# Eval("name")%></a>&nbsp;&nbsp;</div>
                </ItemTemplate>
                </asp:DataList>
                </td>
        </tr>
        <tr>
            <td class="divh">
                 <a href="#tops" title="置顶"><img src="../images/up_arrow.png" border="0" align="absmiddle" /></a>
                <asp:Label ID="id" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="addtime" runat="server" Text="" Visible="false"></asp:Label> 
                </td>
            <td>
                <div class="btn1"><img src="../images/icon_save.gif" /></div>
                <div class="btn2" id="bottoms">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" OnClientClick="return chkform()">保存</asp:LinkButton></div>
                <div class="btn3"></div>
                </td>
        </tr>
    </table>
    <script type="text/javascript">
        function chkform() {
            if (editor_a.hasContents()) {
                editor_a.sync();
                document.getElementById("editorspan").innerHTML = "";
                return true;
            }
            else {
                document.getElementById("editorspan").innerHTML = "请输入内容";
                return false;
            }
        }
        function Setag(str) {
            var clientid = "<%= tags.ClientID %>";
            document.getElementById(clientid).value = document.getElementById(clientid).value + str + ",";
        }
    </script>
                </td>
</asp:Content>
