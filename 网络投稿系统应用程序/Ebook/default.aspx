<%@ register tagprefix="com" tagname="bottom" src="bottom.ascx"%>
<%@ register tagprefix="com" tagname="AuthorNavigation" src="AuthorTopBar.ascx"%>
<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="Ebook.Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Ebook.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="AuthorBeginWebForm" method="post" runat="server">
			<com:AuthorNavigation id="AuthorNavigation" runat="server"></com:AuthorNavigation>
			<TABLE cellSpacing="0" cellPadding="0" border="0" align="center" width="100%">
				<TR>
					<TD align="center" bgColor="mintcream" width="220" style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: darkgray 1px solid; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: black; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: black; BORDER-TOP-COLOR: black">
						<FONT face="����"><FONT face="����">&nbsp;</FONT>
							<TABLE style="BORDER-TOP: gray 1px solid; BORDER-BOTTOM: gray 1px solid" cellSpacing="0"
								cellPadding="4" width="100%" border="0">
								<TR>
									<TD align="center" bgColor="#99cccc">
										<asp:Label id="lbWelcomeMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
									</TD>
								</TR>
							</TABLE>
							<BR>
						</FONT>
						<TABLE cellSpacing="1" cellPadding="3">
							<TR>
								<TD>
									<FONT face="����"></FONT>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:HyperLink id="FrontPageHL" runat="server" Font-Bold="True" NavigateUrl="AuthorInfo.aspx" Font-Underline="True">
					�鿴�������뵥</asp:HyperLink>
								</TD>
							</TR>							
							<TR>
								<TD>
									<asp:HyperLink id="AuthorPublishEbookHL" runat="server" Font-Bold="True" NavigateUrl="PublishApplyWebForm.aspx"
										Font-Underline="True">
					�������</asp:HyperLink>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:hyperlink id="EditInfoHL" runat="server" Font-Bold="True" NavigateUrl="AuthorEditPersonalInfo.aspx"
										Font-Underline="True">
					�鿴���޸ĸ�����Ϣ</asp:hyperlink>
								</TD>
							</TR>
							<TR>
								<TD>
									<FONT face="����">&nbsp;</FONT>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<FONT face="����">&nbsp;</FONT>
									<asp:HyperLink id="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="AuthorLoginWebForm.aspx">�˳�</asp:HyperLink>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="right" bgColor="mintcream" valign="top">
						<DIV align="center">
																			
							<CENTER>
								<TABLE cellSpacing="0" cellPadding="0" width="80%" bgColor="#cccccc" border="0">
									<TR>
										<TD width="100%">
											<TABLE class="" cellSpacing="1" width="100%" border="0">
												<TR>
													<TD bgColor="#99cccc" height="22" align="center" colspan="2">
														<FONT face="����" color="#cc0000"><STRONG style="FONT-SIZE: 10pt">
											
										�������뵥����</STRONG></FONT>
													</TD>
												</TR>
												<TR>
													<TD width="40%" bgColor="#ffffff" height="20">
														��δ����ĳ������뵥��
													</TD>
													<TD align="center" width="20%" bgColor="#ffffff">
														<asp:Label id="Status1NumberLabel" runat="server"></asp:Label>
													</TD>
												</TR>
												<TR>
													<TD bgColor="#ffffff" height="20">
														�������Ѿ����ɵĳ������뵥��
													</TD>
													<TD align="center" width="20%" bgColor="#ffffff">
														<asp:Label id="Status2NumberLabel" runat="server"></asp:Label>
													</TD>
												</TR>
												<TR>
													<TD bgColor="#ffffff" height="20">
														�����̲����ɵĳ������뵥��
													</TD>
													<TD align="center" width="20%" bgColor="#ffffff">
														<asp:Label id="Status3NumberLabel" runat="server"></asp:Label>
													</TD>
												</TR>
												<TR>
													<TD bgColor="#ffffff" height="20">
														˫����ȷ�ϵĳ������뵥��
													</TD>
													<TD align="center" width="20%" bgColor="#ffffff">
														<asp:Label id="Status4NumberLabel" runat="server"></asp:Label>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
								<FONT face="����">
									<BR>
									&nbsp;</FONT>
							</CENTER>
						</DIV>
					</TD>
				</TR>
			</TABLE>
			<com:bottom id="bottom" runat="server"></com:bottom>
		</form>
	</body>
</HTML>
