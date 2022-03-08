<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Trip.WebForm1" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="Trip.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="Default" method="post" runat="server">
			<TABLE id="Table1" style="HEIGHT: 252px" cellSpacing="1" cellPadding="1" width="98%" align="center"
				border="1">
				<TR>
					<TD style="HEIGHT: 176px" vAlign="top" align="center">
						<asp:datagrid id="Dgd_user" runat="server" DataKeyField="sight_id" OnPageIndexChanged="DataGrid_page"
							AutoGenerateColumns="False" PageSize="4" AllowPaging="True" Width="100%" BorderColor="#999999"
							BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="sight_Name" HeaderText="名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="place" HeaderText="地理位置"></asp:BoundColumn>
								<asp:BoundColumn DataField="show" HeaderText="景点介绍"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><BR>
						<br>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
