<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RenameFolder.aspx.cs" Inherits="RenameFolder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第11章：网络邮件管理系统===重命名文件夹</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body style="margin-left:0;margin-top:0;margin-left:0">
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellspacing="0"
		cellpadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">重命名文件夹</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" align="right">名称:</td>
			<td><asp:textbox id="Name" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		
				<asp:RequiredFieldValidator ID="rfN" runat="server" ControlToValidate="Name"
					CssClass="GbText" Display="Dynamic" ErrorMessage="名称不能为空！"></asp:RequiredFieldValidator></td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:150" align="right"></TD>
			<TD align="left"><font face="宋体">&nbsp;</font></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" width="150" align="right"></TD>
			<TD align="left"><font face="宋体">&nbsp;</font><asp:Button ID="RenameBtn" runat="server" Text="确定" Width="100px" CssClass="ButtonCss" OnClick="NewBtn_Click" /><font face="宋体">&nbsp;</font><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
