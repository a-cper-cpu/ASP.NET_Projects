<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="bid.WebForm1" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Header" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���羺��ϵͳ</title>
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
						E-Mail��
						<asp:textbox id="txtEmail" Width="94px" Runat="server" CssClass="textbox"></asp:textbox><br>
						��&nbsp;&nbsp;&nbsp;&nbsp;�
						<asp:textbox id="Pwd" Width="94px" Runat="server" CssClass="textbox" TextMode="Password"></asp:textbox>
						<br>
						<asp:label id="lblMsg" Runat="server" ForeColor="red"></asp:label><br>
						<asp:button id="btnOK" Runat="server" CssClass="button" Text="ȷ ��"></asp:button>&nbsp;
						<asp:button id="btnreg" Runat="server" CssClass="button" Text="ע ��"></asp:button>&nbsp;
						
					</td>
					<td align=right valign=bottom><asp:button id="btnsel" Runat="server" CssClass="button" Text="�����Ʒ�б�"></asp:button></td>
				</tr>
			</table>
		</form>
		<br>
		<table cellSpacing="0" cellPadding="0" width="500" align="center"  border="0" bgcolor=Silver>
			<TR>
				<td bgcolor=Gainsboro>
					��ӭ�������Ͼ���ϵͳ���ڸ�ϵͳ��������������¹�����
					<ol>
						<li>
						���������Ʒ��Ϣ��
						<li>
						������Ʒ��
						<li>
							������Ʒ��</li>
					</ol>
					<p align="justify">
						������ע���¼�ȿ������ϵͳ��������Ʒ�б�<br>
						�������Ҫ���뾺����Ʒ��<br>
						������������Լ�����Ʒ��<br>
						��ô������ע��Ϊ��ϵͳ�û���
					</p>
				</td>
			</TR>
		</table>
		<center><F:Header id="Footer" runat="server" /></center>
	</body>
</HTML>
