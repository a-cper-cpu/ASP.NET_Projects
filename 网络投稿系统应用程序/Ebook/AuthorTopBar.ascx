<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AuthorTopBar.ascx.cs" Inherits="Ebook.AuthorTopBar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE height="68" cellSpacing="0" cellPadding="0" width="100%" border="0" bgColor="royalblue">
	<TR>
		<TD><FONT face="�����п�" color="white" size="7"><STRONG>&nbsp; ����Ͷ��</STRONG></FONT>
		</TD>
	</TR>
</TABLE>
<asp:panel id="AuthorAfterLoginPanel1" BackColor="WhiteSmoke" BorderStyle="None" Width="100%"
	HorizontalAlign="Center" runat="server">
	<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD><FONT style="FONT-SIZE: 10pt" face="Vernada" color="white">&nbsp;</FONT></TD>
			<TD align="right">
				<asp:HyperLink id="HyperLink4" runat="server" NavigateUrl="AuthorBeginWebForm.aspx" Font-Underline="True"
					Font-Bold="True" ForeColor="#C00000">
					������Ϣ</asp:HyperLink>&nbsp;&nbsp;
				<asp:HyperLink id="FrontPageHL" runat="server" NavigateUrl="AuthorInfo.aspx" Font-Underline="True"
					Font-Bold="True" ForeColor="#C00000">
					�鿴�������뵥</asp:HyperLink>&nbsp;&nbsp;
				<asp:HyperLink id="AuthorPublishEbookHL" runat="server" NavigateUrl="PublishApplyWebForm.aspx"
					Font-Underline="True" Font-Bold="True" ForeColor="#C00000">
					�������</asp:HyperLink>&nbsp; &nbsp;
				<asp:hyperlink id="EditInfoHL" runat="server" NavigateUrl="AuthorEditPersonalInfo.aspx" Font-Underline="True"
					Font-Bold="True" ForeColor="#C00000">
					�鿴���޸ĸ�����Ϣ</asp:hyperlink>&nbsp;&nbsp;
			</TD>
		</TR>
	</TABLE>
	<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD bgColor="ghostwhite">
				<asp:hyperlink id="HyperLink2" runat="server" NavigateUrl="AuthorRegistWebForm.aspx" Font-Underline="True"
					Font-Bold="True" ForeColor="#C00000" DESIGNTIMEDRAGDROP="12" Target="_self">
					��û��ע�᣿</asp:hyperlink><FONT color="gray">&nbsp;</FONT><FONT color="dimgray">&nbsp;&nbsp;&nbsp;&nbsp;</FONT>&nbsp; 
				&nbsp;
			</TD>
		</TR>
	</TABLE>
</asp:panel>
