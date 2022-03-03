<%@ Page language="c#" Codebehind="register.aspx.cs" AutoEventWireup="false" Inherits="Forum.register" %>
<%@ register tagprefix="F" tagname="Fooler" src="Fooler.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>userinfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table Width="50%" Align="center" CellPadding="0" CellSpacing="0">
				<tr>
					<td>用户名</td>
					<td><asp:TextBox ID="username" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>密码</td>
					<td><asp:TextBox ID="Pass" TextMode="Password" Runat="server" CssClass="textbox" />
					</td>
				</tr>
				<tr>
					<td>重复密码</td>
					<td>
						<asp:TextBox ID="pass2" TextMode="Password" Runat="server" CssClass="textbox" />
					</td>
				</tr>
				<tr>
					<td>性别</td>
					<td><asp:TextBox ID="sex" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>EMail</td>
					<td><asp:TextBox ID="email" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>QQ</td>
					<td><asp:TextBox ID="QQ" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>个人签名</td>
					<td><asp:TextBox ID="sign" Width="250" Height="70" TextMode="Multiline" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td><asp:Button ID="btnSubmit" Text="确定" Runat="server" CssClass="button" />
					</td>
					<td><input id="btnReset" type="reset" Runat="server" class="button" value="取消" NAME="btnReset">
					</td>
				</tr>
				<tr>
					<td colspan="2"><asp:Label ID="lblMsg" Runat="server" /></td>
				</tr>
			</table>
		</form>
		<hr color="darkgray" SIZE="2">
		<p><F:FOOLER id="Fooler" runat="server"></F:FOOLER></p>
	</body>
</HTML>
