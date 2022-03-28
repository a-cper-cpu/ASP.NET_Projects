<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteDesktop.aspx.cs" Inherits="VoteDesktop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第十三章：网络在线投票系统===系统投票平台</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
		<table class="GbText"  bgcolor="#c0d9e6" style="BORDER-COLLAPSE: collapse" borderColor="#93bee2"
					cellSpacing="0" cellPadding="0" border="1" width="100%">
			<tr>
				<td align="center" height="80" valign="bottom" style="font-size: 30px">网站在线投票系统</td>
			</tr>
			<tr><td style="height:50"></td></tr>
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px">
					<asp:HyperLink ID="hlVote" NavigateUrl="~/Vote.aspx" runat="server" Font-Bold="True">网站在线投票</asp:HyperLink></td>
			</tr>
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px">
					<asp:HyperLink ID="hlShowVote" NavigateUrl="~/ShowVote.aspx" runat="server" Font-Bold="True">以表格形式查看投票结果</asp:HyperLink></td>
			</tr>
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px">
					<asp:HyperLink ID="hlShowVoteByPicture" NavigateUrl="~/ShowVoteByPicture.aspx" runat="server" Font-Bold="True">以图形形式查看投票结果</asp:HyperLink></td>
			</tr>
			<asp:Panel ID="AdminPanel" runat="server" Visible="false">
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px" bgcolor="#cccc00">
				<a href="TopicManage.aspx">投票主题管理</a>
			</tr>	
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px" bgcolor="#cccc00">
				<a href="SubjectManage.aspx">投票项目管理</a>
			</tr>
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px" bgcolor="#cccc00">
				<a href="ItemManage.aspx">投票项目的选择项管理</a>
			</tr>
			<tr>
				<td align="center" width="100%" valign="bottom" style="height: 30px" bgcolor="#cccc00">
				<a href="SystemProfile.aspx">投票系统配置</a>
			</tr></asp:Panel>			
		</table>
    </form>
</body>
</html>
