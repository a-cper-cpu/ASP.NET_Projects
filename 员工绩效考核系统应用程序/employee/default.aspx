<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="employee.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="employee.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="HEIGHT: 251px" cellSpacing="0" cellPadding="0" width="96%" align="center"
				border="0">
				<TR>
					<TD style="HEIGHT: 40px" >
						<P align="center"><FONT face="宋体" size="6"><STRONG>员工绩效考核系统</STRONG></FONT></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 169px">
						<TABLE id="Table2" style="WIDTH: 230px; HEIGHT: 110px" cellSpacing="0" cellPadding="0"
							width="230" align="center" border="0">
							<TR>
								<TD><FONT face="宋体">用户号：</FONT></TD>
								<TD><asp:textbox id="Tbx_id" CssClass="textbox" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">密&nbsp; 码：</FONT></TD>
								<TD><asp:textbox id="Tbx_pwd" runat="server" CssClass="textbox" TextMode="Password"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><FONT face="宋体"></FONT><FONT face="宋体">
										<asp:button id="Btn_login" CssClass="button" runat="server" Text="登录"></asp:button>
										<asp:label id="Lbl_note" runat="server"></asp:label></FONT></TD>
							</TR>
						</TABLE>
						<FONT face="宋体"></FONT>
					</TD>
				</TR>
				<TR>
					<TD bgColor="#cccccc"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
