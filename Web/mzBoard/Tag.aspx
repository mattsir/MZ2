<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tag.aspx.cs" Inherits="Web.mzBoard.Tag" MasterPageFile="~/mzBoard/Site.Master" %>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <style type="text/css">
        #div_key a
        {
            font-family: Arial,Helvetica,sans-serif;
            font-size: 11px;
            margin-left: 5px;
            color: #0082CB;
            text-decoration: none;
            background-color: #EDFCFF;
            padding:5px;
        }
        #div_key a:hover
        {
            font-size: 11px;
            font-family: Arial,Helvetica,sans-serif;
            color: White;
            text-decoration: none;
            background-color: #0082CB;
            padding:5px;
        }
    </style>
    
    <div id="div_key">
    <asp:DataList ID="DataList1" runat="server" RepeatLayout="Flow" CellPadding="0" CellSpacing="0" 
        Width="100%" RepeatDirection="Horizontal">
    <ItemTemplate>
        <span style="border: solid 1px #B2D9F0; margin-right:5px; padding-left:5px;"><%# Eval("tagname") %>
            <a href="TagSub.aspx?id=<%# Eval("id") %>">X</a>
        </span>
    </ItemTemplate>
    <ItemStyle Height="35px" />
    </asp:DataList>
    </div>
</asp:Content>
