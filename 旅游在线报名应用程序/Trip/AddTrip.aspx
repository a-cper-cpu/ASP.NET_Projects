<%@ Page language="c#" Codebehind="AddTrip.aspx.cs" AutoEventWireup="false" Inherits="Trip.AddTrip" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddTrip</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="Trip.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="Addtrip" method="post" runat="server" action="Addtrip.aspx">
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="700" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<TABLE id="Table2" style="WIDTH: 340px; HEIGHT: 120px" cellSpacing="1" cellPadding="1"
							width="600" align="center" border="0" bgcolor="#f5f5f5">
							<TR>
								<TD><FONT face="宋体">姓&nbsp;名：</FONT></TD>
								<TD>
									<asp:TextBox id="name" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">线&nbsp;路：</FONT></TD>
								<TD>
									<asp:DropDownList id="line" DataTextField="name" DataValueField="team_name" runat="server" />
								</TD>
								<TD style="HEIGHT: 26px"><FONT color="#ff0000" size="2" face="宋体">必选</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">人&nbsp;数：</FONT></TD>
								<TD>
									<asp:TextBox id="Num" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">可为空</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">电&nbsp;话：</FONT></TD>
								<TD>
									<asp:TextBox id="Tell" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">必填</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">地&nbsp;址：</FONT></TD>
								<TD>
									<asp:TextBox id="Address" CssClass="textbox" runat="server" Width="116px"></asp:TextBox></TD>
								<TD style="HEIGHT: 18px"><FONT color="#ff0000" size="2" face="宋体">可为空</FONT></TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">描&nbsp;述：</FONT></TD>
								<TD>
									<asp:TextBox id="show" CssClass="textbox" runat="server" Width="180" Height="60"></asp:TextBox></TD>
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
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
