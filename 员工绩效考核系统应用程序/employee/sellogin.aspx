<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="sellogin.aspx.cs" AutoEventWireup="false" Inherits="employee.sellogin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>sellogin</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="employee.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="Form1" method="post" runat="server" action="sellogin.aspx">
			<TABLE id="Table2" style="WIDTH: 600px" width="600" align="center" border="0" bgcolor="#f5f5f5">
				<TR>
					<TD style="WIDTH: 80px"><FONT face="宋体">开始时间：</FONT></TD>
					<TD>
						<asp:TextBox id="begin" CssClass="textbox" runat="server"></asp:TextBox><FONT face="宋体"></FONT></TD>
					<TD><FONT face="宋体">结束时间：</FONT></TD>
					<TD>
						<asp:TextBox id="end" CssClass="textbox" runat="server"></asp:TextBox><FONT face="宋体"></FONT></TD>
					<TD><asp:Button id="Btn_ok" CssClass="Button" runat="server" Text="确定"></asp:Button></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" style="WIDTH: 544px; HEIGHT: 251px" cellSpacing="1" cellPadding="1"
				width="544" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 174px">
						<asp:datagrid id="datagrid1" runat="server"  AutoGenerateColumns="False"
							PageSize="5" AllowPaging="True" Width="100%" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
							BackColor="White" CellPadding="3" GridLines="Horizontal">
							<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Sysdate" HeaderText="填写时间"></asp:BoundColumn>
								<asp:BoundColumn DataField="Work_date" HeaderText="工作时间"></asp:BoundColumn>
								<asp:BoundColumn DataField="Team_name" HeaderText="项目组"></asp:BoundColumn>
								<asp:BoundColumn DataField="status" HeaderText="工作情况"></asp:BoundColumn>
								<asp:BoundColumn DataField="show" HeaderText="备注信息"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
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
