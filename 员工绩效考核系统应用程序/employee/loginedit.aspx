<%@ Page language="c#" Codebehind="loginedit.aspx.cs" AutoEventWireup="false" Inherits="employee.loginedit" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>loginedit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="employee.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="Loginedit" method="post" runat="server" action="Loginedit.aspx">
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="700" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="600" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD><FONT face="����">��Ŀ���ƣ�</FONT></TD>
								<TD>
									<asp:DropDownList id="team" DataTextField="name" DataValueField="team_name" runat="server" />
								</TD>
								<TD style="HEIGHT: 26px"><FONT color="#ff0000" size="2" face="����">��ѡ</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="����">ʱ�䣺</FONT></TD>
								<TD>
									<asp:DropDownList CssClass="DropDownList" id="Ddl_kind" runat="server">
										<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
										<asp:ListItem Value="����">����</asp:ListItem>
									</asp:DropDownList>
								</TD>
								<TD style="HEIGHT: 26px"><FONT color="#ff0000" size="2" face="����">��ѡ</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="����">��&nbsp;����</FONT></TD>
								<TD>
									<asp:TextBox id="status" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="����">��Ϊ��</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="����">��&nbsp;����</FONT></TD>
								<TD>
									<asp:TextBox id="show" CssClass="textbox" runat="server" Width="180" Height="60"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="����">��Ϊ��</FONT></TD>
							</TR>
							<TR>
								<TD colSpan="3" align="center">
									<asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="ȷ��"></asp:Button><FONT face="����">&nbsp;&nbsp;&nbsp;
									</FONT>
									<asp:Button id="Btn_cancel" CssClass="Button" runat="server" Text="ȡ��"></asp:Button>
									<asp:Label id="Lbl_note" runat="server"></asp:Label><FONT face="����"></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#cccccc"><FONT face="����"><a href="Sellogin.aspx">����</a> </FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
