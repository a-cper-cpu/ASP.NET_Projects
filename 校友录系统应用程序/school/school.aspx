<%@ Page language="c#" Codebehind="school.aspx.cs" AutoEventWireup="false" Inherits="school.school" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>school</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="welcome" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER><FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="760" align="center" border="0">
					<TR>
						<TD align="left" width="20%" height="18"><FONT color="#004080">班级信息区域：</FONT></TD>
					</TR>
				</TABLE>
				<asp:datagrid id="DataGrid1" runat="server" GridLines="None" CellPadding="2" BorderWidth="1px"
					Font-Size="9pt" AutoGenerateColumns="False" BorderColor="Tan" BackColor="LightGoldenrodYellow"
					Width="760px" HorizontalAlign="Center" ForeColor="Black">
					<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<AlternatingItemStyle HorizontalAlign="Center" BackColor="PaleGoldenrod"></AlternatingItemStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Tan"></HeaderStyle>
					<FooterStyle BackColor="Tan"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="A1"></asp:BoundColumn>
						<asp:BoundColumn DataField="A3" HeaderText="班级名称"></asp:BoundColumn>
						<asp:BoundColumn DataField="A2" HeaderText="班级管理员"></asp:BoundColumn>
						<asp:HyperLinkColumn Text="&gt;&gt;&gt;&gt;" DataNavigateUrlField="class_id" DataNavigateUrlFormatString="addlist.aspx?clid={0}"
							HeaderText="通讯录"></asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="&gt;&gt;&gt;&gt;" DataNavigateUrlField="class_id" DataNavigateUrlFormatString="info.aspx?clid={0}"
							HeaderText="留言本"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
				</asp:datagrid>
				<table cellSpacing="0" width="760" align="center" border="0">
					<tr bgColor=Silver>
						<td align="left" width="22%" height="18"><FONT color="#004080">注 册 新 班 级：</FONT></td>
						<td align="right"><asp:label id="lblNo" Runat="server" ForeColor="red" text="" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table cellSpacing="0" cellPadding="2" width="760" align="center" border="1">
					<tr bgColor="lavender">
						<td align="center" width="33%">第一步:找到您的班级</td>
						<td align="center" width="33%">学校所在省份<asp:dropdownlist id="ddlProve" Runat="server" CssClass="textbox"></asp:dropdownlist></td>
						<td align="center"><asp:button id="btnNext" Runat="server" CssClass="button" Text="下一步"></asp:button></td>
					</tr>
				</table>
			</FONT>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
