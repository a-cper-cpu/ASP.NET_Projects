<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="student.aspx.cs" AutoEventWireup="false" Inherits="student1.student" %>
<HTML>
	<HEAD>
		<title>学生管理</title>
		<LINK href="student.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body text="#000000" vLink="#000080" aLink="#000080" link="#000080">
		<form id="Form1" method="post" runat="server">
			<H:HEADER id="Header" runat="server"></H:HEADER>
			<table width="580" align="center">
				<tr>
					<td vAlign="top" align="left" width="160">
						<table class="tableBorder1" id="Search_holder" cellSpacing="1" cellPadding="0" width="100%"
							border="0" runat="Server">
							<tr>
								<th align="center" background="images/sds01_r2_c8.gif" height="26">
									<asp:label id="SearchForm_Title" runat="server">  搜索引擎 </asp:label></th></tr>
							<tr>
								<td background="images/sds01_r2_c8.gif">
									<table>
										<tr>
											<td>帐号：</td>
											<td><asp:textbox id="Search_emp_login" runat="server" Width="94px" Columns="10"></asp:textbox></td>
										</tr>
										<tr>
											<td>姓名：</td>
											<td><asp:textbox id="Search_name" runat="server" Width="94px" Columns="15"></asp:textbox></td>
										</tr>
										<tr>
											<td>班级：</td>
											<td><asp:dropdownlist id="Search_class" runat="server" DataValueField="" DataTextField=""></asp:dropdownlist></td>
										</tr>
										<tr>
											<td align="left" colSpan="0"><asp:button id="Search_search_button" runat="server" Text="提交"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td>
						<table class="tableBorder1" id="emps_holder" cellSpacing="1" cellPadding="0" width="100%"
							border="0" runat="Server">
							<tr>
								<th align="center" background="images/sds01_r2_c8.gif" height="26">
									<asp:label id="InfoForm_Title" runat="server">  学生信息 </asp:label></th></tr>
							<tr>
								<td background="images/sds01_r2_c8.gif">
									<table width="100%">
										<TBODY>
              <tr>
												<TD bgColor=Silver><asp:label id="emps_Column_emp_id" runat="server" Text=""></asp:label></TD>
												<td bgColor=Silver>帐号</td>
												<td bgColor=Silver>姓名</td>
												<td bgColor=Silver>性别</td>
												<td bgColor=Silver>职务</td>
											</tr>
              <tr id="emps_no_records" runat="server">
												<td colSpan="5"><font style="FONT-SIZE: 10pt; COLOR: #000000; FONT-FAMILY: Arial, Tahoma, Verdana, Helvetica">没有记录！</font></td>
											</tr>
              <tr>
												<td><asp:repeater id="emps_Repeater" runat="server">
														<HeaderTemplate>
												</td>
											</tr>
	</HeaderTemplate>
	<ItemTemplate>
												<tr>
													<td bgcolor=Silver>
														<asp:HyperLink id=emps_emp_id NavigateUrl='<%# "studentedit.aspx"+"?"+"student_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "e_emp_id").ToString()) +"&" +"emp_login=" + Server.UrlEncode(Utility.GetParam("emp_login")) + "&manmonth=" + Server.UrlEncode(Utility.GetParam("manmonth")) + "&name=" + Server.UrlEncode(Utility.GetParam("name")) + "&"%>'  runat="server">编辑</asp:HyperLink>&nbsp;
													</td>
													<td>
														<asp:Label id="emps_emp_login" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_emp_login").ToString()) %>
														</asp:Label>&nbsp;
													</td>
													<td>
														<asp:Label id="emps_name" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_name").ToString()) %>
														</asp:Label>&nbsp;
													</td>
													<td>
														<asp:Label id="emps_sex" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_sex").ToString()) %>
														</asp:Label>&nbsp;
													</td>
													<td>
														<asp:Label id="emps_business" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_business").ToString()) %>
														</asp:Label>&nbsp;
													</td>
												</tr>
											</ItemTemplate>

	<FooterTemplate>
												<tr>
													<td>
											</FooterTemplate>
									</asp:repeater></td>
							</tr>
							<tr>
								<td bgColor=Silver>
								<asp:label id="Label1" runat="server" Text=""></asp:label></td>
								<td bgColor=Silver colSpan="5" align=center>
								<asp:linkbutton id="emps_insert" runat="server">添加学生</asp:linkbutton>								
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE></form>
		<center><F:FOOTER id="Footer" runat="server"></F:FOOTER></center>
	</body>
</HTML>
