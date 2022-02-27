<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="student1.Default" %>
<HTML>
	<HEAD>
		<title>学生资料</title>
		<Link href="student.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body text="#000000" link="#000080" vlink="#000080" alink="#000080">
		<form method="post" runat="server" ID="Form1">
			<H:Header id="Header" runat="server" />
			<table align="center" width="720">
				<tr>
					<td width="170" align="left" valign="top">
						<table id="Login_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" class="tableBorder1"
							width="100%">
							<tr>
								<th align="center" height="26" background="images/sds01_r2_c8.gif">
									<asp:label id="LoginForm_Title" runat="server"> 用户登录</asp:label></th>
							</tr>
							<tr id="AdminList_Title" runat="server">
								<td align="center" bgcolor="#ffffff"><font size="4" color="#003399">学生信息管理</font></td>
							</tr>
							<tr id="AdminStu_Title" runat="server">
								<td align="center" bgcolor="#ffffff">
									<asp:HyperLink NavigateUrl="student.aspx" id="Form_Field2" runat="server">学生管理</asp:HyperLink></td>
							</tr>
							<tr id="AdminClass_Title" runat="server">
								<td align="center" bgcolor="#ffffff">
									<asp:HyperLink NavigateUrl="class.aspx" id="Form_Field1" runat="server">班级管理</asp:HyperLink></td>
							</tr>
							<tr>
								<td background="images/sds01_r2_c8.gif">
									<table width="100%">
										<tr id="Login_trname" runat="server">
											<td width="35%">帐 号：</td>
											<td><asp:TextBox id="Login_name" Width="94px" runat="server" /></td>
										</tr>
										<tr id="Login_trpassword" runat="server">
											<td>密 码：</td>
											<td><asp:TextBox TextMode="Password" Width="94px" id="Login_password" runat="server" /></td>
										</tr>
										<tr>
											<td colspan="2" bgcolor="#ffffff">
												<asp:Label id="Login_labelname" runat="server" />
												<asp:Button id="Login_login" runat="server" />
												<asp:Label Text="<br><br>请输入账号密码!" id="Login_message" visible="false" runat="server" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br>
						<table id="Search_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" class="tableBorder1"
							width="100%">
							<tr>
								<th align="center" height="26" background="images/sds01_r2_c8.gif">
									<asp:label id="SearchForm_Title" runat="server">  搜索引擎 </asp:label></th>
							</tr>
							<tr>
								<td background="images/sds01_r2_c8.gif"><table>
										<tr>
											<td>班 级：</td>
											<td>
												<asp:DropDownList id="Search_class_id" DataTextField="name" DataValueField="dep_id" runat="server" />
											</td>
										</tr>
										<tr>
											<td>姓 名：</td>
											<td>
												<asp:TextBox id="Search_name" Columns="15" runat="server" />
											</td>
										</tr>
										<tr>
											<td>职务：</td>
											<td>
												<asp:TextBox id="Search_business" Columns="15" MaxLength="50" runat="server" />
											</td>
										</tr>
										<tr>
											<td align="left" colspan="0">
												<asp:Button id="Search_search_button" Text="提交" runat="server" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td align="center" valign="top">
						<table id="Grid_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" width="100%"
							height="100%" class="tableBorder1">
							<tr>
								<th align="center" height="25" background="images/sds01_r2_c8.gif">
									学生基础信息资料</th>
							</tr>
							<tr>
								<td background="images/sds01_r2_c8.gif"><table width="100%">
										<TBODY>
<tr>
												<td bgcolor=LightGrey width="15%">
													姓名</td>
												<td bgcolor=LightGrey width="15%">
													职务</td>
												<td bgcolor=LightGrey width="25%">
													班级</td>
												<td bgcolor=LightGrey>
													电话</td>
												<td bgcolor=LightGrey>
													Email</td>
											</tr>
<tr id="Grid_no_records" runat="server">
												<td colspan="5">
													<font style="FONT-SIZE: 10pt; COLOR: #000000; FONT-FAMILY: Arial, Tahoma, Verdana, Helvetica">
														没有记录！</font></td>
											</tr>
	<tr>
												<td>
													<asp:Repeater id="Grid_Repeater" onitemdatabound="Grid_Repeater_ItemDataBound" runat="server">
														<HeaderTemplate>
												</td>
											</tr>
	</HeaderTemplate>
	<ItemTemplate>
												<tr>
													<td>
														<asp:HyperLink id=Grid_name NavigateUrl='<%# "stuDetail.aspx"+"?"+"student_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "e_student_id").ToString()) +"&" +"class_id=" + Server.UrlEncode(Utility.GetParam("class_id")) + "&email=" + Server.UrlEncode(Utility.GetParam("email")) + "&name=" + Server.UrlEncode(Utility.GetParam("name")) + "&"%>'  runat="server">
															<%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_name").ToString()) %>
														</asp:HyperLink>&nbsp;
													</td>
													<td>
														<asp:Label id="Grid_title" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_business").ToString()) %>
														</asp:Label>&nbsp;
													</td>
													<td>
														<asp:Label id="Grid_dep_id" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "d_class").ToString()) %>
														</asp:Label>&nbsp;
													</td>
													<td>
														<asp:Label id="Grid_work_phone" runat="server">
															<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_work_ph").ToString()) %>
														</asp:Label>&nbsp;
													</td>
													<td>
														<asp:Label id="Grid_email" runat="server">
															<%# DataBinder.Eval(Container.DataItem, "e_email") %>
														</asp:Label>&nbsp;
													</td>
												</tr>
											</ItemTemplate>

	<FooterTemplate>
												<tr>
													<td>
											</FooterTemplate>
									</asp:Repeater></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD>
			<td width="130" align="left" valign="top">
				<table id="EmpMonth_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" width="100%"
					class="tableBorder1">
					<tr>
						<th align="center" height="25" background="images/sds01_r2_c8.gif">
							每月之星</th>
					</tr>
					<tr>
						<td width="100%" background="images/sds01_r2_c8.gif">
							<table width="100%">
								<TBODY>
			<tr id="EmpMonth_no_records" runat="server">
										<td colspan="2">
											<font style="FONT-SIZE: 10pt; COLOR: #000000; FONT-FAMILY: Arial, Tahoma, Verdana, Helvetica">
												暂无记录！</font></td>
									</tr>
			<tr>
										<td>
											<asp:Repeater id="EmpMonth_Repeater"  runat="server">
												<HeaderTemplate>
										</td>
									</tr>
	</HeaderTemplate>
	<ItemTemplate>
										<tr>		
											<td><img src="images\2501.jpg"  align=right></td>									
											<td align=left>
												<asp:HyperLink id=EmpMonth_name NavigateUrl='<%# "stuDetail.aspx"+"?"+"student_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "e_student_id").ToString())%>'  runat="server">
													<%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "e_name").ToString()) %>
												</asp:HyperLink>&nbsp;
											</td>
										</tr>
									</ItemTemplate>
	<SeparatorTemplate></SeparatorTemplate>
	<FooterTemplate>
										<tr>
											<td>
									</FooterTemplate>
							</asp:Repeater></td>
					</tr>
				</table>
			</td>
			</TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
		</form>
		<center>
			<F:Footer id="Footer" runat="server" /></center>
	</body>
</HTML>
