<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="adduser.aspx.cs" AutoEventWireup="false" Inherits="client.adduser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adduser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="client.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="adduser" method="post" runat="server" >
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 38px" bgcolor="#cccccc">
						<P align="center"><FONT face="����" size="4">����û�</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="340" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 31px"><FONT face="����">�û��ţ�</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 31px">
									<asp:TextBox id="Tbx_id" CssClass="textbox" runat="server" Width="116px"></asp:TextBox><FONT face="����"></FONT></TD>
								<TD style="HEIGHT: 31px"><FONT face="����">* </FONT><FONT size="2">
										<asp:RequiredFieldValidator id="Rfv_id" runat="server" ErrorMessage="����Ϊ��" ControlToValidate="Tbx_id"></asp:RequiredFieldValidator>
										<asp:CustomValidator id="Cv_id" runat="server" ErrorMessage="�Ѵ���" ControlToValidate="Tbx_id"></asp:CustomValidator><FONT face="����"></FONT></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="����">��&nbsp; ����</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="Tbx_name" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="����">��Ϊ��</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 26px"><FONT face="����">�û����ͣ�</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 26px">
									<asp:DropDownList CssClass="DropDownList" id="Ddl_kind" runat="server">
										<asp:ListItem Value="0">����Ա</asp:ListItem>
										<asp:ListItem Value="1">��ͬ��</asp:ListItem>
										<asp:ListItem Value="2">���۲�</asp:ListItem>
										<asp:ListItem Value="3">�ͻ���</asp:ListItem>
									</asp:DropDownList>
								</TD>
								<TD style="HEIGHT: 26px"><FONT color="#ff0000" size="2" face="����">��ѡ</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="����">��&nbsp;����</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="tell" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
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
						<P align="center"><FONT face="����" color="#ff0000" size="2">Ĭ���������û�����ͬ</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#cccccc"><FONT face="����"><a href="users.aspx">����</a> </FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
