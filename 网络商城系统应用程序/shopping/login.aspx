<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="shopping.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="shopping.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table cellspacing="0" cellpadding="0" width="100%" border="0">
			<TBODY>
				<tr>
					<td colspan="2">
						<H:Header ID="Header1" runat="server" />
					</td>
				</tr>
				<tr>
					<td valign="top">
						<img height="1" src="images/1x1.gif" width="145">
					</td>
					<td align="left" valign="top" width="100%" nowrap>
						<table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr valign="top">
								<td nowrap><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
									<br>
									<form runat="server" ID="Form1">
										<img align="left" width="24" height="1" src="images/1x1.gif"> <img align="left" height="1" width="92" src="images/1x1.gif">
										<table height="100%" cellspacing="0" cellpadding="0" border="0">
											<tr valign="top">
												<td width="550">
													<asp:Label id="Message" class="ErrorText" runat="server" />
													<br>
													<br>
													用户名&nbsp;<asp:TextBox size="25" id="email" runat="server" Width="174px" />
													<asp:RequiredFieldValidator id="UserNameRequired" ControlToValidate="email" Display="dynamic" Font-Name="verdana"
														Font-Size="9pt" ErrorMessage="请填写，不能为空" runat="server" /><p>
														密&nbsp;&nbsp; 码&nbsp;<asp:TextBox id="password" textmode="password" size="25" runat="server" />
														<asp:RequiredFieldValidator id="passwordRequired" ControlToValidate="password" Display="Static" Font-Name="verdana"
															Font-Size="9pt" ErrorMessage="请填写，不能为空" runat="server" />
														<br>
														<br>
														<asp:ImageButton id="LoginBtn" ImageURL="images/sign_in_now.gif" runat="server" />
														<a href="register.aspx"><img border="0" src="images/register.gif"></a></p>
												</td>
											</tr>
										</table>
									</form>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD vAlign="top"></TD>
					<TD vAlign="top" noWrap align="center" width="100%">
						<asp:HyperLink id="BackHyperLink" runat="server" NavigateUrl="Default.aspx">返回</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD vAlign="top"></TD>
					<TD vAlign="top" noWrap align="left" width="100%">
						<F:Footer id="Footer" runat="server" /></TD>
				</TR>
			</TBODY>
		</table>
		</TR></TBODY></TABLE>
	</body>
</HTML>
