<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="EmpEdit.aspx.cs" AutoEventWireup="false" Inherits="employee.EmpEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EmpEdit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="employee.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="EmpEdit" method="post" runat="server" action="EmpEdit.aspx">
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="340" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 31px"><FONT face="宋体">用户号：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 31px">
									<asp:TextBox id="Tbx_id" CssClass="textbox" runat="server" Width="116px"></asp:TextBox><FONT face="宋体"></FONT></TD>
								<TD style="HEIGHT: 31px"><FONT face="宋体">* </FONT><FONT size="2">
										<asp:RequiredFieldValidator id="Rfv_id" runat="server" ErrorMessage="不能为空" ControlToValidate="Tbx_id"></asp:RequiredFieldValidator>
										<asp:CustomValidator id="Cv_id" runat="server" ErrorMessage="已存在" ControlToValidate="Tbx_id"></asp:CustomValidator><FONT face="宋体"></FONT></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">姓名：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="Tbx_name" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">Email：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="Tbx_Email" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 26px"><FONT face="宋体">用户类型：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 26px">
									<asp:DropDownList CssClass="DropDownList" id="Ddl_kind" runat="server">
										<asp:ListItem Value="0">系统管理员</asp:ListItem>
										<asp:ListItem Value="1">企业员工</asp:ListItem>
										<asp:ListItem Value="2">企业领导</asp:ListItem>
									</asp:DropDownList>
								</TD>
								<TD style="HEIGHT: 26px"><FONT color="#ff0000" size="2" face="宋体">必选</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">电&nbsp;话：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="tell" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">可为空</FONT></TD>
							</TR>
							<TR>
								<TD colSpan="3" align="center">
									<asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="确定"></asp:Button><FONT face="宋体">&nbsp;&nbsp;&nbsp;
									</FONT>
									<asp:Button id="Btn_cancel" CssClass="Button" runat="server" Text="取消"></asp:Button>
									<asp:Label id="Lbl_note" runat="server"></asp:Label><FONT face="宋体"></FONT></TD>
							</TR>
						</TABLE>
						<P align="center"><FONT face="宋体" color="#ff0000" size="2">默认密码与用户名相同</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" bgcolor="#cccccc"><FONT face="宋体"><a href="users.aspx">返回</a> </FONT>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
