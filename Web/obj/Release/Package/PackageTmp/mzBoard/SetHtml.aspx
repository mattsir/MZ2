<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetHtml.aspx.cs" Inherits="Web.mzBoard.SetHtml" MasterPageFile="~/mzBoard/Site.Master" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
    <asp:Button ID="Button1" runat="server" Text="生成html" OnClick="Button1_Click" />
    <div class="divh" runat="server" id="txt"></div>
</asp:Content>
