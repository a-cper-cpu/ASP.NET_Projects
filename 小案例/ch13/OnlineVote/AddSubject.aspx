<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSubject.aspx.cs" Inherits="AddSubject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第十三章：网络在线投票系统===添加投票项目</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellPadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">添加投票项目</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;" valign="top">
			<td style="width:150" align="right">所属主题:</td>
			<td>
				<asp:DropDownList ID="TopicList" runat="server" Width="305px">
				</asp:DropDownList></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" align="right">项目名称:</td>
			<td><asp:textbox id="Name" runat="server" Width="300px" CssClass="InputCss" Height="50px" TextMode="MultiLine"></asp:textbox>		
				<asp:RequiredFieldValidator ID="rfN" runat="server" ControlToValidate="Name"
					CssClass="GbText" Display="Dynamic" ErrorMessage="名称不能为空！"></asp:RequiredFieldValidator></td>
		</tr>
		<tr style="line-height:2;" valign="top">
			<td style="width:150; height: 29px;" align="right">显示模式:</td>
			<td style="height: 29px">
				<asp:DropDownList ID="ModeList" runat="server" Width="305px">
					<asp:ListItem Selected="True" Value="0">单选模式</asp:ListItem>
					<asp:ListItem Value="1">多选模式</asp:ListItem>
				</asp:DropDownList></td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:150" align="right"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" width="150" align="right"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT><asp:Button ID="AddBtn" runat="server" Text="确定" Width="100px" CssClass="ButtonCss" OnClick="AddBtn_Click" /><FONT face="宋体">&nbsp;</FONT><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
