<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewLeaveword.aspx.cs" Inherits="ViewLeaveword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="ASPNET2.0BaseCss.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellPadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">查看留言</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;" valign="top">
			<td style="width:150" align="right">需要回复留言的标题:</td>
			<td>
				<asp:Label ID="Title" runat="server" CssClass="GbText" Width="100%" Enabled="False"></asp:Label></td>
		</tr>
		<tr style="line-height:2;" valign="top">
			<td style="width:150" align="right">需要回复留言的主体内容:</td>
			<td>
				<asp:Label ID="LeavewordBody" runat="server" CssClass="GbText" Width="100%" Enabled="False"></asp:Label></td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:150" width="150" align="right"></TD>
			<td align="left"><FONT face="宋体"></FONT><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>