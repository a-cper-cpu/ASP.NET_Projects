<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="school.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>校友录管理系统</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
		<meta content=C# name=CODE_LANGUAGE>
		<meta content=JavaScript name=vs_defaultClientScript>
		<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
		<LINK href="school.css" type=text/css rel=stylesheet >
		</HEAD>
		<body MS_POSITIONING="GridLayout">
			<form id=Form1 method=post runat="server">
			<H:HEADER id=Header runat="server"></H:HEADER>
				<table cellSpacing=0 cellPadding=0 width=500 align=center border=0>
					<tr>
						<td style="FONT-SIZE: 9pt" vAlign=top align=right width=306>
							用户名：
							<asp:textbox id=login Width="94px" Runat="server" CssClass="textbox"></asp:textbox><br>
							口&nbsp;&nbsp;&nbsp;&nbsp;令：
							<asp:textbox id=Pwd Width="94px" Runat="server" CssClass="textbox" TextMode="Password">
							</asp:textbox> 
							<br><asp:label id=lblMsg Runat="server" ForeColor="red"></asp:label><br>
							<asp:button id=btnOK Runat="server" CssClass="button" Text="确 认"></asp:button>&nbsp; 
							<asp:button id=btnreg Runat="server" CssClass="button" Text="注 册"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</FORM>
		<center><F:FOOTER id=Footer runat="server"></F:FOOTER></center>
	</body>
</HTML>
