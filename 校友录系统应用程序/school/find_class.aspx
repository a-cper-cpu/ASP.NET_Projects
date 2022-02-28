<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="find_class.aspx.cs" AutoEventWireup="false" Inherits="school.find_class" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>find_class</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="find_cl" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER>
			<TABLE border="0" id="Table1" cellSpacing="0" cellPadding="0" width="760" align="center">
				<TR>
					<TD bgcolor="beige" align="right">校友录系统——&gt; 班级注册</TD>
				</TR>
				<TR>
					<TD bgcolor="#fffff4"><table border="0" cellpadding="0" align="center" width="640">
							<tr bgcolor="silver">
								<td>第一步： 查询学校所在区域</td>
							</tr>
							<tr bgcolor="#fffff4">
								<td>学校所在地区：&nbsp;
									<asp:DropDownList id="ddlSchcity" runat="server" CssClass="textbox"></asp:DropDownList></FONT></td>
							</tr>
							<tr bgcolor="#fffff4">
								<td>所在学校类型：
									<asp:DropDownList id="ddlSchtype" runat="server" CssClass="textbox"></asp:DropDownList>
									<asp:Label id="lblSchtype" runat="server" ForeColor="Red" Visible="False">您还没有选择学校类型！</asp:Label></FONT></td>
							</tr>
							<tr bgcolor="#fffff4">
								<td>请输入校名以便查找：
									<asp:TextBox ID="txtSchkey" CssClass="textbox" Runat="server" Width="60px"></asp:TextBox>
									</td>
							<tr bgcolor="#fffff4">
								<td align="right">
									<asp:Button id="btnNext1" runat="server" Text="下一步" CssClass="button"></asp:Button></td>
							</tr>
						</table>
					</TD>
				</TR>				
			</TABLE>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
