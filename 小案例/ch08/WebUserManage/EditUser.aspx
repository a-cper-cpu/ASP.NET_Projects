<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="EditUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第八章：网络用户管理系统===修改用户页面</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellPadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">修改用户</font></td>
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
			<td align="left"><asp:textbox id="Email" runat="server" Width="150px" CssClass="InputCss"></asp:textbox>
				<asp:RequiredFieldValidator id="rfE" runat="server" ErrorMessage="电子邮件不能为空！" ControlToValidate="Email" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                <asp:RegularExpressionValidator ID="reE" runat="server" ControlToValidate="Email"
                    ErrorMessage="电子邮件格式不正确！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" align="right"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" width="150" align="right"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT><asp:Button ID="UpdateBtn" runat="server" Text="修改" Width="100px" CssClass="ButtonCss" OnClick="UpdateBtn_Click" /><FONT face="宋体">&nbsp;</FONT><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
