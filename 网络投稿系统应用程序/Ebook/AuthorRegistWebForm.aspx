<%@ register tagprefix="com" tagname="AuthorNavigation" src="AuthorTopBar.ascx"%>
<%@ register tagprefix="com" tagname="bottom" src="bottom.ascx"%>
<%@ Page language="c#" Codebehind="AuthorRegistWebForm.aspx.cs" AutoEventWireup="false" Inherits="Ebook.AuthorRegistWebForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuthorRegistWebForm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Ebook.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<com:AuthorNavigation id="AuthorNavigation" runat="server"></com:AuthorNavigation>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="340" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 31px"><FONT face="宋体">用户名：</FONT></TD>
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
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">证件号：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="card" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">性别：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="sex" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">年龄：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="age" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">住址：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="address" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">邮编：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="zipcode" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">城市：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="city" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">国家：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="country" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 25px"><FONT face="宋体">Email：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 25px">
									<asp:TextBox id="Email" CssClass="textbox" runat="server" Width="116px"></asp:TextBox>
								</TD>
								<TD style="HEIGHT: 25px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">电&nbsp;话：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="phone" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">可为空</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">移动电话：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="mobile" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">可为空</FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">问题：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="question" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">回答：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="answer" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 87px; HEIGHT: 18px"><FONT face="宋体">记录：</FONT></TD>
								<TD style="WIDTH: 114px; HEIGHT: 18px">
									<asp:TextBox id="note" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"></TD>
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
		<com:bottom id="bottom" runat="server"></com:bottom>
	</body>
</HTML>
