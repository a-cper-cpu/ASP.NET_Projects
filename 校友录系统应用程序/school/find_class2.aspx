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
							<TD align="right" bgColor="#f5f5dc"><FONT color="#000000">У��¼ϵͳ����&gt; �༶ע��</FONT>
							</TD>
						</TR>
						<TR>
							<TD align="center" bgColor="#fffff4"><br>
								<br>
								<table cellSpacing="0" cellPadding="0" width="640" border="0">
									<tr>
										<td align="left" bgColor="#fffff4">�ڶ�����Ѱ��ѧУ��<br>
											<asp:label id="lblNoSchool" Visible="False" text="û���ҵ�������Ҫ���ѧУ��" ForeColor="red" Runat="server"></asp:label><br>
											<FONT color="#000000">��������б���ѡ��ѧУ��Ϣ��</FONT>
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
											DataTextField="sch_name" HeaderText="ѧ У �� ��">
											<ItemStyle Width="215px"></ItemStyle>
										</asp:HyperLinkColumn>
										<asp:BoundColumn DataField="sch_num" HeaderText="�༶��">
											<ItemStyle Width="45px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="pro_name" HeaderText="ʡ ��">
											<ItemStyle Width="60px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="city_name" HeaderText="��   ��">
											<ItemStyle Width="60px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="sch_erea" HeaderText="�� ��">
											<ItemStyle Width="70px"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="type_name" HeaderText="ѧУ����">
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
													����ϱ��л�û�����ѧУ���������ע�᣺</P>
											</td>
										</tr>
										<tr>
											<td style="WIDTH: 294px" width="294">
												<FONT color="#800080">У����<br><asp:textbox id="txtSchname" Runat="server" Width="175px" CssClass="textbox"></asp:textbox>*
												<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtSchname" ErrorMessage="����û������У��"></asp:requiredfieldvalidator><br>
												<FONT color="#800080">ѧУ�������У�<BR>
												<asp:textbox id="txtScherea" Runat="server" Width="206px" CssClass="textbox"></asp:textbox>*
												<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtScherea" ErrorMessage="������������"></asp:requiredfieldvalidator><BR>
												ѧУ�������룺<br>
												<asp:textbox id="txtSchzip" Runat="server" Width="89px" CssClass="textbox"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtSchzip" ErrorMessage="Ӧ������λ����"
													ValidationExpression="\d{6}"></asp:regularexpressionvalidator><BR>
												ѧУ��ַ��<BR>
												<asp:textbox id="txtSchhttp" Runat="server" Width="206px" CssClass="textbox" ToolTip="�밴�����¸�ʽ���룺http://www.126.com"
													Text=""></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="txtSchhttp" ErrorMessage="��ʽ����"
													ValidationExpression="http://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:regularexpressionvalidator></FONT></FONT></td>
											<td align=right><FONT color="#800080">
													<TABLE id="Table2" style="WIDTH: 380px; HEIGHT: 56px" cellSpacing="0" cellPadding="0" width="340"
														align="center" border="0">
														<TR>
															<TD width="100%"><FONT color="#ff0000">ע�⣺</FONT><br>
																<FONT color="#800080">У������д�����������¹淶�������п��ܱ�ɾ����<BR>
																	1��У��������ȫ�ƣ�����ʹ�ü�ƣ�<BR>
																	2��У�������Ĳ���Ӣ�ĺ����֣�������֮�䲻���пո�<BR>
																	<P>
																	ѧУ�������е���д�������ԡ��ء������С����족��β��</FONT></TD>
														</TR>
													</TABLE>
												</FONT>
			</FONT>
			<p><asp:button id="btnNext" Runat="server" CssClass="button" Text="��һ��"></asp:button>
			</TD></TR>
			
			</TBODY></TABLE></TD></TR>
			<TR>
				<TD style="HEIGHT: 10px" bgColor="#ccccff"></TD>
			</TR>
			</TBODY></TABLE></FONT></form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
