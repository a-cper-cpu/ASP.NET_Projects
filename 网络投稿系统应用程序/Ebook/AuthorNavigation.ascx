<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AuthorNavigation.ascx.cs" Inherits="Ebook.AuthorNavigation" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE height="68" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="#3a6ea5">
	<TR>
		<TD><FONT face="�����п�" color="white" size="7"><STRONG>&nbsp; ����Ͷ��</STRONG></FONT>
		</TD>
	</TR>
</TABLE>
<asp:panel id="AuthorAfterLoginPanel1" BackColor="#99CCCC" BorderStyle="None" Width="180px"
	HorizontalAlign="Left" runat="server" Height="100%">
	<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD><FONT face="����">&nbsp;</FONT>
				<asp:HyperLink id="FrontPageHL" runat="server" NavigateUrl="AuthorInfo.aspx" Font-Underline="True"
					Font-Bold="True" ForeColor="#C00000">
					�鿴���뵥</asp:HyperLink></TD>
		</TR>
		<TR>
			<TD><FONT face="����">&nbsp;</FONT>
				<asp:HyperLink id="AuthorPublishEbookHL" runat="server" NavigateUrl="PublishApplyWebForm.aspx"
					Font-Underline="True" Font-Bold="True" ForeColor="#C00000">
					�������</asp:HyperLink></TD>
		</TR>
		<TR>
			<TD><FONT face="����">&nbsp;</FONT>
				<asp:hyperlink id="EditInfoHL" runat="server" NavigateUrl="AuthorEditPersonalInfo.aspx" Font-Underline="True"
					Font-Bold="True" ForeColor="#C00000">
					�鿴���޸ĸ�����Ϣ</asp:hyperlink></TD>
		</TR>
		<TR>
			<TD></TD>
		</TR>
		<TR>
			<TD><FONT face="����">&nbsp;</FONT>
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="AuthorLoginWebForm.aspx" Font-Bold="True">
					��¼ϵͳ</asp:HyperLink></TD>
		</TR>
	</TABLE>
</asp:panel>
