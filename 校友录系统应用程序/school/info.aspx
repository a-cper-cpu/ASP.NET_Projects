<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="info.aspx.cs" AutoEventWireup="false" Inherits="school.info" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>info</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="info" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER>
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="65%" align="center" border="0">
					
					<TR>
						<TD bgcolor="#ccccff"></TD>
					</TR>
					<TR>
						<TD bgcolor="#f1f0f4" align="center">
							<br>
							<asp:DataList ID="dltBoard" Runat="server" BorderStyle="None" BackColor="#F1F0F4" Width="100%">
								<ItemTemplate>
									<table bgcolor="f1f0f4" width="85%" border="0" cellpadding="0" cellspacing="0" align="center"
										bgcolor="f1f0f4">
										<tr bgcolor="f1f0f4">
											<td width="80%">主题：<%# DataBinder.Eval(Container.DataItem,"info_title")%><br></td>
											
										</tr>
										<tr bgcolor="f1f0f4">
											<td align="right" colspan="2"><font color="Silver"><%# DataBinder.Eval(Container.DataItem,"editinfo")%></font></td>
										</tr>
										<tr bgcolor="f1f0f4">
											<td colspan="2"><br>留言内容：<FONT color="#416aaf"><%# DataBinder.Eval(Container.DataItem,"info_cnt","{0}").Replace("<","&lt").Replace(">","&gt").Replace(" ","&nbsp;").Replace("\n","<br>") %></FONT></td>
										</tr>
										<tr bgcolor="f1f0f4">
											<td><br><%# DataBinder.Eval(Container.DataItem,"editurl")%>&nbsp;<%# DataBinder.Eval(Container.DataItem,"delurl")%>&nbsp;</td>
											<td align="right">留言人：<font color="#3300ff"><%# DataBinder.Eval(Container.DataItem,"name")%></font>&nbsp;&nbsp;</td>
										</tr>
										
									</table>
									<hr size="0" width="93%" noshade>
								</ItemTemplate>
							</asp:DataList>
						</TD>
					</TR>
					<TR>
						<TD bgcolor="#ffff99" style="HEIGHT: 10px">
						</TD>
					</TR>					
					<TR>
						<TD bgcolor="#f1f0f4" align="center"><br>
							<table cellpadding="0" cellspacing="0" border="0" width="55%">
								<tr bgcolor="#f1f0f4">
									<td><FONT color="#004080">留言人：
											<asp:Label id="lblName" runat="server" BackColor="#F1F0F4"></asp:Label><br>
										</FONT>
									</td>
								</tr>
								<tr bgcolor="#f1f0f4">
									<td><br>
										<FONT color="#004080">留言主题：<asp:TextBox ID="txtTheme" Runat="server" Width="70%" TextMode="SingleLine" MaxLength="40"></asp:TextBox></FONT></td>
								</tr>
								<tr bgcolor="#f1f0f4">
									<td>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="主题不能为空！" BackColor="#F1F0F4"
											ControlToValidate="txtTheme"></asp:RequiredFieldValidator><br>
										<br>
										<FONT color="#004080">留言内容：<br>
											<asp:TextBox ID="txtContent" Runat="server" Width="80%" Height="120" TextMode="MultiLine"></asp:TextBox></FONT><br>
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" BackColor="#F1F0F4" ErrorMessage="内容不能为空！"
											ControlToValidate="txtContent"></asp:RequiredFieldValidator></td>
								</tr>
							</table>
						</TD>
					</TR>
					<TR>
						<TD bgcolor="#f1f0f4" align="center">
							<asp:Button ID="btnOK" Runat="server" CssClass="button" Text="提 交" Width="60px"></asp:Button></TD>
					</TR>					
				</TABLE>
			</FONT>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
