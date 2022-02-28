<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="find_class3.aspx.cs" AutoEventWireup="false" Inherits="school.find_class3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>find_class3</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="find_cl3" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER>
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="760" align="center" border="0">
				<TR>
					<TD align="right" bgColor="silver"><FONT color="#000000"> &nbsp;校友录系统－－&gt; 班级注册</FONT>
					</TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#fffff4"><BR>
						<BR>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="640" border="0">
							<TR>
								<TD align="left" bgColor="#fffff4">第三步：寻找班级：<BR>
									<asp:Label id="lblNoCl" Runat="server" ForeColor="red" text="没有找到符合您要求的学校！" Visible="False">没有查询到符合要求的班级！</asp:Label><BR>
									<FONT color="#800080">请从列表中选择要注册的班级信息： </FONT>
								</TD>
							</TR>
						</TABLE>
						<BR>
						<asp:datagrid id="dgdCl" Runat="server" Width="640px" CellPadding="2" AlternatingItemStyle-BackColor="#ccccff"
							BackColor="LightGoldenrodYellow" HeaderStyle-BackColor="#E8F4FF" AutoGenerateColumns="False"
							BorderColor="Tan" BorderWidth="1px" GridLines="None" ForeColor="Black">
							<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="Tan"></HeaderStyle>
							<FooterStyle BackColor="Tan"></FooterStyle>
							<Columns>
								<asp:HyperLinkColumn DataNavigateUrlField="class_id" DataNavigateUrlFormatString="findend.aspx?clid={0}"
									DataTextField="class_name" HeaderText="班 级 名 称">
									<ItemStyle Width="200px"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="grad" HeaderText="入学年份">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="class_num" HeaderText="成员数">
									<ItemStyle Width="60px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="m1" HeaderText="正管理员">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="m2" HeaderText="副管理员">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="m3" HeaderText="副管理员">
									<ItemStyle Width="70px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="type_id" HeaderText="班级类型">
									<ItemStyle Width="193px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
						</asp:datagrid>
						<TABLE id="Table4" borderColor="silver" cellSpacing="0" cellPadding="0" width="640" border="1">
							<TR>
								<TD colSpan="2" style="HEIGHT: 46px">
									<P align="left">
										如果上表中还没有你要注册的班级，请从下面注册：</P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 413px" width="413"><FONT color="#800080">&nbsp;&nbsp; 班级名：
										<asp:TextBox id="txtClname" Runat="server" Width="115px" CssClass="textbox"></asp:TextBox>
										*&nbsp;
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="您还没有输入班级名" ControlToValidate="txtClname"></asp:RequiredFieldValidator>&nbsp;&nbsp;
									</FONT>
									<br>
									<FONT color="#800080">&nbsp;&nbsp;入学年份：
										<asp:TextBox id="txtGrad" runat="server" Width="44px" CssClass="textbox"></asp:TextBox>年*
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtGrad"></asp:RequiredFieldValidator>
										<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="年份必须在1945到2005之间" ControlToValidate="txtGrad"
											MinimumValue="1945" MaximumValue="2005"></asp:RangeValidator></FONT>
								</TD>
								<TD align="right" valign="bottom"><FONT color="#800080">
										<asp:Button id="btnNext" Runat="server" CssClass="button" Text="下一步"></asp:Button></FONT></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 10px" bgColor="#ccccff"></TD>
				</TR>
			</TABLE>
		</form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
