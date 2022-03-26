<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>第12章:网站流量统计</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellspacing="0"
		cellpadding="2" width="100%" border="1">
		<tr>
			<td align="center" colspan="2" style="background-color: #6699cc;"><font class="HeaderText">第12章:网站流量统计系统</font></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px; text-align: right;" align="right">IP地址</td>
			<td align="left"><asp:Label ID="IP" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px;" align="right">操作系统</td>
			<td align="left"><asp:Label ID="OS" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px" align="right">浏览器</td>
			<td align="left"><asp:Label ID="Browser" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px" align="right">浏览器的版本</td>
			<td align="left"><asp:Label ID="Vision" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px;" align="right">语言</td>
			<td align="left"><asp:Label ID="Language" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px" align="right">是否支持Cookie</td>
			<td align="left"><asp:Label ID="IsCookie" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px" align="right">访问时间</td>
			<td align="left"><asp:Label ID="Date" runat="server" Width="100%"></asp:Label></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px" align="right"></td>
			<td align="left"><a href="StatByOS.aspx">按操作系统统计</a>&nbsp;&nbsp;&nbsp;<a href="StatByBrowser.aspx">按浏览器统计</a></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150px" align="right"></td>
			<td align="left"><a href="StatByYear.aspx">按年统计</a>&nbsp;&nbsp;&nbsp;<a href="StatByMonth.aspx">按月统计</a>&nbsp;&nbsp;&nbsp;<a href="StatByDay.aspx">按日统计</a>&nbsp;&nbsp;&nbsp;<a href="StatByWeek.aspx">按星期统计</a></td>
		</tr>
		<tr>
			<td colspan="2">		
			</td>
		</tr>
    </table>
    </form>
</body>
</html>
