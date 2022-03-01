<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="bid.WebForm1" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Header" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>网络竞标系统</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="bid.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout"  bgcolor=Gainsboro>
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
				<tr>
					<td style="FONT-SIZE: 9pt" vAlign="top" align="right" width="306">
						E-Mail：
						<asp:textbox id="txtEmail" Width="94px" Runat="server" CssClass="textbox"></asp:textbox><br>
						口&nbsp;&nbsp;&nbsp;&nbsp;令：
						<asp:textbox id="Pwd" Width="94px" Runat="server" CssClass="textbox" TextMode="Password"></asp:textbox>
						<br>
						<asp:label id="lblMsg" Runat="server" ForeColor="red"></asp:label><br>
						<asp:button id="btnOK" Runat="server" CssClass="button" Text="确 认"></asp:button>&nbsp;
						<asp:button id="btnreg" Runat="server" CssClass="button" Text="注 册"></asp:button>&nbsp;
						
					</td>
					<td align=right valign=bottom><asp:button id="btnsel" Runat="server" CssClass="button" Text="浏览商品列表"></asp:button></td>
				</tr>
			</table>
		</form>
		<br>
		<table cellSpacing="0" cellPadding="0" width="500" align="center"  border="0" bgcolor=Silver>
			<TR>
				<td bgcolor=Gainsboro>
					欢迎访问网上竞标系统。在该系统中您可以完成如下工作：
					<ol>
						<li>
						浏览待售商品信息；
						<li>
						竞标商品；
						<li>
							出售商品。</li>
					</ol>
					<p align="justify">
						您无需注册登录既可浏览本系统的所有商品列表。<br>
						如果您想要参与竞标商品，<br>
						或者您想出售自己的商品，<br>
						那么请您先注册为本系统用户。
					</p>
				</td>
			</TR>
		</table>
		<center><F:Header id="Footer" runat="server" /></center>
	</body>
</HTML>
