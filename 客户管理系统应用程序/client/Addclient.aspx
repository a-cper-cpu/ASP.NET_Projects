<%@ Page language="c#" Codebehind="Addclient.aspx.cs" AutoEventWireup="false" Inherits="client.Addclient" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Addclient</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="client.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="addclient" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 539px; HEIGHT: 244px" cellSpacing="1" cellPadding="1"
				width="539" align="center" border="0">
				<TR>
					<TD bgcolor="#cccccc">
						<P align="center"><FONT face="宋体" size="4">添加新客户</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 181px"><FONT face="宋体">
							<TABLE id="Table2" width="94%" align="center" border="0" bgcolor="#f5f5f5">
								<TR>
									<TD>客户编号</TD>
									<TD>
										<asp:TextBox id="Tbx_id" CssClass="TextBox" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>客户名称</TD>
									<TD>
										<asp:TextBox id="Tbx_name" CssClass="TextBox" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>负责人</TD>
									<TD>
										<asp:TextBox id="Tbx_person" CssClass="TextBox" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>客户级别</TD>
									<TD>
										<asp:DropDownList id="Ddl_level" runat="server">
											<asp:ListItem Value="4">4</asp:ListItem>
											<asp:ListItem Value="3">3</asp:ListItem>
											<asp:ListItem Value="2">2</asp:ListItem>
											<asp:ListItem Value="1">1</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>Email</TD>
									<TD>
										<asp:TextBox id="Email" CssClass="TextBox" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>联系电话</TD>
									<TD>
										<asp:TextBox id="Tell" CssClass="TextBox" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>客户简介</TD>
									<TD>
										<asp:TextBox id="Tbx_introduce" CssClass="TextBox" height="60" Width="260" runat="server" TextMode="MultiLine"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<asp:Button id="Btn_add" CssClass="Button" runat="server" Text="添加"></asp:Button>
										<asp:Button id="Btn_reset" CssClass="Button" runat="server" Text="重置"></asp:Button>
										<asp:Label id="Lbl_note" runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
						</FONT>
						<asp:CustomValidator id="Cv_id" runat="server" ErrorMessage="此用户已存在" ControlToValidate="Tbx_id"></asp:CustomValidator>
					</TD>
				</TR>
				<TR>
					<TD bgcolor="#cccccc" align="center"><FONT face="宋体">
							<asp:Button id="Btn_exit" CssClass="Button" runat="server" Text="退出"></asp:Button></FONT></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
