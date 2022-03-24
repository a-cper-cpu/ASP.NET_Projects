<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemProfile.aspx.cs" Inherits="SystemProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第11章：网络邮件管理系统===邮件系统配置</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body style="margin-left:0;margin-top:0;margin-left:0">
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellspacing="0"
		cellpadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">邮件系统配置(需要重启应用程序！)</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" align="right">
				用户名称:</td>
			<td><asp:textbox id="UserName" runat="server" Width="300px" CssClass="InputCss">Admin</asp:textbox>		
				<asp:RequiredFieldValidator ID="rfN" runat="server" ControlToValidate="UserName"
					CssClass="GbText" Display="Dynamic" ErrorMessage="名称不能为空！"></asp:RequiredFieldValidator></td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:150" align="right">
				邮件别名:</td>
			<td><asp:textbox id="AliasName" runat="server" Width="300px" CssClass="InputCss">Admin</asp:textbox>		
				<asp:RequiredFieldValidator ID="rfA" runat="server" ControlToValidate="AliasName"
					CssClass="GbText" Display="Dynamic" ErrorMessage="名称不能为空！"></asp:RequiredFieldValidator></td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:150; height: 31px;" align="right">
				电子邮件(Email):</td>
			<td style="height: 31px"><asp:textbox id="Email" runat="server" Width="300px" CssClass="InputCss">zhengyd@gucas.ac.cn</asp:textbox>		
				<asp:RequiredFieldValidator ID="rfE" runat="server" ControlToValidate="Email"
					CssClass="GbText" Display="Dynamic" ErrorMessage="电子邮件不能为空！"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="reE" runat="server" ControlToValidate="Email"
					CssClass="GbText" Display="Dynamic" ErrorMessage="电子邮件的格式不正确！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:150; height: 31px;" align="right">
				邮件服务器IP地址:</td>
			<td style="height: 31px"><asp:textbox id="IP" runat="server" Width="300px" CssClass="InputCss">210.77.16.3</asp:textbox>		
				<asp:RequiredFieldValidator ID="rfI" runat="server" ControlToValidate="IP"
					CssClass="GbText" Display="Dynamic" ErrorMessage="IP地址不能为空！"></asp:RequiredFieldValidator></td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:150" align="right">
				邮件服务器端口:</td>
			<td><asp:textbox id="Port" runat="server" Width="300px" CssClass="InputCss">25</asp:textbox>		
				<asp:RequiredFieldValidator ID="rfP" runat="server" ControlToValidate="Port"
					CssClass="GbText" Display="Dynamic" ErrorMessage="端口不能为空！"></asp:RequiredFieldValidator>
				<asp:RangeValidator ID="rvP" runat="server" ControlToValidate="Port" CssClass="GbText"
					Display="Dynamic" ErrorMessage="端口输入范围错误！" MaximumValue="65535" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:150" align="right"></TD>
			<TD align="left"><font face="宋体">&nbsp;</font></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" width="150" align="right"></TD>
			<TD align="left"><font face="宋体">&nbsp;</font><asp:Button ID="SetBtn" runat="server" Text="确定" Width="100px" CssClass="ButtonCss" OnClick="SetBtn_Click" /><font face="宋体"></font></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
