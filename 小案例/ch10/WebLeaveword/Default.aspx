<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
	<title>第10章：留言板===用户登录</title>
	<link href="ASPNET2.0BaseCss.css" type="text/css" rel="stylesheet">
</HEAD>
<body topmargin="0" bottommargin="0">
	<form id="Form1" method="post" runat="server">
		<table width="780" align="center" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td height="100"></td>
			</tr>
			<tr valign="top">
				<td height="270" align="center">
					<table border="0" cellpadding="1" cellspacing="0" width="420">
						<tr>
							<td align="center" height="60" valign="middle" colspan="2"><font class="HeaderText">用户登录 &nbsp; &nbsp; &nbsp;&nbsp;
								<br></font>
							</td>
						</tr>
						<tr>
							<td height="33" width="100" align="right"><font class="GbText">用户名：</font></td>
							<td align="left"><asp:TextBox ID="UserName" Runat="server" CssClass="InputText" Width="150"></asp:TextBox><font color="red" class="Normal">*</font>
								<asp:RequiredFieldValidator id="RFVUserName" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="UserName"
									CssClass="GbText" Display="Dynamic"></asp:RequiredFieldValidator></td>
						</tr>
						<tr>
							<td height="33" width="100" align="right"><font class="GbText">密 码：</font></td>
							<td align="left"><asp:TextBox ID="Password" Runat="server" CssClass="InputText" Width="150" TextMode="Password"></asp:TextBox><font color="red" class="Normal">*</font>
								<asp:RequiredFieldValidator id="RFVPassword" runat="server" ErrorMessage="密码不能为空" ControlToValidate="Password"
									CssClass="GbText" Display="Dynamic"></asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td height="33" width="100" align="right"><font class="GbText">验证码：</font></td>
							<td align="left" valign="bottom"><asp:TextBox ID="Validator" Runat="server" CssClass="InputText" Width="150"></asp:TextBox><font color="red" class="Normal">*</font>
								<asp:Image ID="ValidateImage" runat="server" Height="25px" Width="100px" ImageAlign="AbsBottom" />
								<asp:RequiredFieldValidator id="rfv" runat="server" ErrorMessage="验证码不能为空" ControlToValidate="Validator"
									CssClass="GbText" Display="Dynamic"></asp:RequiredFieldValidator>
							</td>
						</tr>
					</table>
					<table border="0" cellpadding="1" cellspacing="0" width="420">
						<tr>
							<td align="right" width="180">
								<asp:Button ID="LoginBtn" Runat="server" Text="登录" CssClass="ButtonCss" Width="80px" OnClick="LoginBtn_Click"></asp:Button>
							</td>
							<td align="center" width="100">
								<asp:Button ID="CancelBtn" Runat="server" Text="取消" CssClass="ButtonCss" CausesValidation="False"
									Width="80px" OnClick="CancelBtn_Click"></asp:Button></td>
							<td width="80">
								<asp:Button ID="GuestBtn" runat="server" CssClass="ButtonCss" Text="游客，我要留言！" CausesValidation="False" OnClick="GuestBtn_Click" />&nbsp;</td>
						</tr>
						<tr>
							<td colspan="3" align="center" height="20"><asp:Label ID="Message" Runat="server" CssClass="GbText" Width="100%" ForeColor="Red"></asp:Label></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td></td>
			</tr>
		</table>
	</form>
</body>
</HTML>
