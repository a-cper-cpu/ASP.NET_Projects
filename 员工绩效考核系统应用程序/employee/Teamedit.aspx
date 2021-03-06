<%@ Page language="c#" Codebehind="Teamedit.aspx.cs" AutoEventWireup="false" Inherits="employee.Teamedit" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Teamedit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="employee.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="teamEdit" method="post" runat="server" action="TeamEdit.aspx">
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="340" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 31px"><FONT face="宋体">项目名称：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 31px">
									<asp:TextBox id="team_name" CssClass="textbox" runat="server" Width="116px"></asp:TextBox><FONT face="宋体"></FONT></TD>
								<TD style="HEIGHT: 31px"><FONT face="宋体">* </FONT><FONT size="2">
										<asp:RequiredFieldValidator id="Rfv_id" runat="server" ErrorMessage="不能为空" ControlToValidate="team_name"></asp:RequiredFieldValidator></FONT>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3" align="center">
									<asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="确定"></asp:Button><FONT face="宋体">&nbsp;&nbsp;&nbsp;
									</FONT>
									<asp:Button id="Btn_cancel" CssClass="Button" runat="server" Text="取消"></asp:Button>
									<asp:Label id="Lbl_note" runat="server"></asp:Label><FONT face="宋体"></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#cccccc"><FONT face="宋体"><a href="team.aspx">返回</a> </FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
