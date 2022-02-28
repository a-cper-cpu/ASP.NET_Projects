<%@ Page language="c#" Codebehind="addlist.aspx.cs" AutoEventWireup="false" Inherits="school.addlist" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>通讯录</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
			<H:HEADER id="Header" runat="server"></H:HEADER><FONT face="宋体">
				<asp:datagrid id="DataGrid1" ForeColor="Black" Runat="server" GridLines="None" BorderWidth="1px"
					BorderColor="Tan" AutoGenerateColumns="False" HeaderStyle-BackColor="#E8F4FF" BackColor="LightGoldenrodYellow"
					AlternatingItemStyle-BackColor="#ccccff" CellPadding="2" Width="640px">
					<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="Tan"></HeaderStyle>
					<FooterStyle BackColor="Tan"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="name" HeaderText="姓名">
							<ItemStyle Width="45px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="job" HeaderText="工作单位">
							<ItemStyle Width="200px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="email" HeaderText="Email">
							<ItemStyle Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="work_tell" HeaderText="工作电话">
							<ItemStyle Width="70px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="mobile_tell" HeaderText="移动电话">
							<ItemStyle Width="203px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="address" HeaderText="家庭住址">
							<ItemStyle Width="203px"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
				</asp:datagrid>
			</center>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
