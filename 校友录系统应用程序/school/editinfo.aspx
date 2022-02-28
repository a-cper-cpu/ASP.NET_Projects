<%@ Page language="c#" Codebehind="editinfo.aspx.cs" AutoEventWireup="false" Inherits="school.editinfo" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>editinfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="editinfo" method="post" runat="server">
		<H:HEADER id="Header" runat="server"></H:HEADER>
			<FONT face="宋体">
				<TABLE id="Table1" align="center" cellSpacing="0" cellPadding="0" width="70%" border="0">
					<TR bgColor="#f1f0f4">
						<TD><FONT color="#ff0000" size="3">留言信息编辑：</FONT>
						</TD>
					</TR>
					<TR bgColor="#f1f0f4">
						<TD><BR>
							<FONT color="#004080">留言主题：
								<asp:TextBox id="txtTheme" TextMode="SingleLine" Runat="server" Width="100%" MaxLength="40"></asp:TextBox></FONT></TD>
					</TR>
					<TR bgColor="#f1f0f4">
						<TD>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" BackColor="#F1F0F4" ErrorMessage="主题不能为空！"
								ControlToValidate="txtTheme"></asp:RequiredFieldValidator><BR>
							<BR>
							<FONT color="#004080">留言内容：<BR>
								<asp:TextBox id="txtContent" TextMode="MultiLine" Runat="server" Width="100%" Height="250"></asp:TextBox></FONT><BR>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" BackColor="#F1F0F4" ErrorMessage="内容不能为空！"
								ControlToValidate="txtContent"></asp:RequiredFieldValidator></TD>
					</TR>
					<tr>
						<td bgcolor="#f1f0f4" align="right">留言人：
							<asp:Label id="lblName" runat="server" BackColor="#F1F0F4" ForeColor="#3300FF"></asp:Label>
							</td>
					</tr>
					<tr>
						<td align="center" bgcolor="#f1f0f4">
							<asp:Button id="btnOK" runat="server" Text="确 认" CssClass="button"></asp:Button>
							<asp:Button id="btnReturn" runat="server" Text="取 消" CssClass="button"></asp:Button></td>
					</tr>
				</TABLE>
			</FONT>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
