<%@ Page language="c#" Codebehind="find_class2.aspx.cs" AutoEventWireup="false" Inherits="school.find_class2" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>find_class2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="school.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="find_cl2" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER>
				<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="760" align="center" border="0">
					<TBODY>
						<TR>
							<TD align="right" bgColor="#f5f5dc"><FONT color="#000000">校友录系统——&gt; 班级注册</FONT>
							</TD>
						</TR>
						<TR>
							<TD align="center" bgColor="#fffff4"><br>
								<br>
								<table cellSpacing="0" cellPadding="0" width="640" border="0">
									<tr>
										<td align="left" bgColor="#fffff4">第二步：寻找学校：<br>
											<asp:label id="lblNoSchool" Visible="False" text="没有找到符合您要求的学校！" ForeColor="red" Runat="server"></asp:label><br>
											<FONT color="#000000">请从下面列表中选择学校信息：</FONT>
										</td>
									</tr>
								</table>
								<br>
								<asp:datagrid id="dgdSch" ForeColor="Black" Runat="server" GridLines="None" BorderWidth="1px"
									BorderColor="Tan" AutoGenerateColumns="False" HeaderStyle-BackColor="#E8F4FF" BackColor="LightGoldenrodYellow"
									AlternatingItemStyle-BackColor="#ccccff" CellPadding="2" Width="640px">
									<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="Tan"></HeaderStyle>
									<FooterStyle BackColor="Tan"></FooterStyle>
									<Columns>
										<asp:HyperLinkColumn DataNavigateUrlField="sch_id" DataNavigateUrlFormatString="find_class3.aspx?schid={0}"
											DataTextField="sch_name" HeaderText="学 校 名 字">
											<ItemStyle Width="215px"></ItemStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="sch_num" HeaderText="班级数">
											<ItemStyle Width="45px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="pro_name" HeaderText="省 份">
											<ItemStyle Width="60px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="city_name" HeaderText="地   区">
											<ItemStyle Width="60px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="sch_erea" HeaderText="县 市">
											<ItemStyle Width="70px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="type_name" HeaderText="学校类型">
											<ItemStyle Width="203px"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
								</asp:datagrid>
								<table borderColor=Beige cellSpacing="0" cellPadding="0" width="640" border="1">
									<TBODY>
										<tr>
											<td colSpan="2">
												<P align="left"><BR>
													如果上表中还没有你的学校，请从下面注册：</P>
											</td>
										</tr>
										<tr>
											<td style="WIDTH: 294px" width="294">
												<FONT color="#800080">校名：<br><asp:textbox id="txtSchname" Runat="server" Width="175px" CssClass="textbox"></asp:textbox>*
												<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtSchname" ErrorMessage="您还没有输入校名"></asp:requiredfieldvalidator><br>
												<FONT color="#800080">学校所在县市：<BR>
												<asp:textbox id="txtScherea" Runat="server" Width="206px" CssClass="textbox"></asp:textbox>*
												<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtScherea" ErrorMessage="请输入县市名"></asp:requiredfieldvalidator><BR>
												学校邮政编码：<br>
												<asp:textbox id="txtSchzip" Runat="server" Width="89px" CssClass="textbox"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtSchzip" ErrorMessage="应该是六位编码"
													ValidationExpression="\d{6}"></asp:regularexpressionvalidator><BR>
												学校网址：<BR>
												<asp:textbox id="txtSchhttp" Runat="server" Width="206px" CssClass="textbox" ToolTip="请按照如下格式输入：http://www.126.com"
													Text=""></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtSchhttp" ErrorMessage="格式错误"
													ValidationExpression="http://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:regularexpressionvalidator></FONT></FONT></td>
											<td align=right><FONT color="#800080">
													<TABLE id="Table2" style="WIDTH: 380px; HEIGHT: 56px" cellSpacing="0" cellPadding="0" width="340"
														align="center" border="0">
														<TR>
															<TD width="100%"><FONT color="#ff0000">注意：</FONT><br>
																<FONT color="#800080">校名的填写必须遵守以下规范，否则有可能被删除！<BR>
																	1、校名必须用全称，不用使用简称；<BR>
																	2、校名用中文不用英文和数字，且文字之间不能有空格；<BR>
																	<P>
																	学校所在县市的填写，必须以“县”、“市”或“旗”结尾。</FONT></TD>
														</TR>
													</TABLE>
												</FONT>
			</FONT>
			<p><asp:button id="btnNext" Runat="server" CssClass="button" Text="下一步"></asp:button>
			</TD></TR>
			
			</TBODY></TABLE></TD></TR>
			<TR>
				<TD style="HEIGHT: 10px" bgColor="#ccccff"></TD>
			</TR>
			</TBODY></TABLE></FONT></form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
