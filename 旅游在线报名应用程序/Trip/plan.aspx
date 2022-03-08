<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="plan.aspx.cs" AutoEventWireup="false" Inherits="Trip.plan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>plan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Trip.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="Form1" method="post" runat="server" action="plan.aspx">
			<TABLE id="Table2" style="WIDTH: 300px" width="300" align="center" border="0" >
				<TR>					
					<TD>
						<asp:DropDownList CssClass="DropDownList" id="Ddl_kind" runat="server">
							<asp:ListItem Value="一日">一日游</asp:ListItem>
							<asp:ListItem Value="两日">两日游</asp:ListItem>
							<asp:ListItem Value="三日">三日游</asp:ListItem>
							<asp:ListItem Value="五日">五日游</asp:ListItem>
							<asp:ListItem Value="七日">七日游</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD><asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="确定"></asp:Button></TD>
				</TR>
			</TABLE>
			<p>
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<asp:datagrid id="datagrid1" runat="server" AutoGenerateColumns="False" PageSize="30" AllowPaging="False"
							Width="100%" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" BackColor="White"
							CellPadding="3" GridLines="Horizontal">
							<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="line" HeaderText="旅游线路"></asp:BoundColumn>
								<asp:BoundColumn DataField="sight_Name" HeaderText="旅游景点"></asp:BoundColumn>								
							</Columns>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
