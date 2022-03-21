<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="ViewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第八章：网络用户管理系统===查看用户信息</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellPadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">查看用户信息</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" align="right">用户名称:</td>
			<td><asp:textbox id="UserName" runat="server" Width="150px" CssClass="InputCss" Enabled="False"></asp:textbox>		</td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" align="right">电子邮件:</td>
			<td align="left"><asp:textbox id="Email" runat="server" Width="150px" CssClass="InputCss" Enabled="False"></asp:textbox>
				&nbsp;
			</td>
		</tr>
		<tr style="line-height:2;">
			<TD align="right" width="150"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT></td>
		</tr>
		<tr style="line-height:2;">
			<TD align="right" width="150"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
