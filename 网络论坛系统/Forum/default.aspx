<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="Forum.WebForm1" %>
<%@ register tagprefix="T" tagname="Top" src="Top.ascx"%>
<%@ register tagprefix="H" tagname="header" src="Header.ascx"%>
<%@ register tagprefix="F" tagname="Fooler" src="Fooler.ascx"%>
<%@ OutputCache Duration="5" VaryByParam="Beg" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY leftMargin="100" topMargin="0">
		<T:TOP id="Top" runat="server"></T:TOP><H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server" >
			<table cellSpacing="1" cellPadding="0" width="95%" align="center" border="0">
			<tr><td>
			”√ªß√˚£∫<asp:textbox id="username" runat="server" Width="60px"></asp:textbox>
			√‹¬Î£∫<asp:textbox id="pass" runat="server" Width="60px" TextMode="Password"></asp:textbox>
			<asp:button id="Login"  runat="server" Text="µ«¬º"></asp:button>
			</td></tr>
			</table>
			</form>
		<hr color="darkgray" SIZE="2">
		<br>
		<table cellSpacing="1" cellPadding="0" width="95%" align="center" border="0">
			<%
			   Display();
            %>
		</table>
		<br>
		<hr color="darkgray" SIZE="2">
		<p><F:FOOLER id="Fooler" runat="server"></F:FOOLER></p>
	</BODY>
</HTML>
