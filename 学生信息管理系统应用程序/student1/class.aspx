<%@ Page language="c#" Codebehind="class.aspx.cs" AutoEventWireup="false" Inherits="student1._class" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<HTML>
	<HEAD>
		<title>班级管理</title>
		<link href="student.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body text="#000000" link="#000080" vlink="#000080" alink="#000080">
		<form method="post" runat="server" ID="Form1">
			<H:Header id="Header" runat="server" />
			<table align="center" width="400">
				<tr>
					<td valign="top" align="center">
						<table id="class_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" class="tableBorder1"
							width="60%">
							<TBODY>
								<tr>
									<th background="images/sds01_r2_c8.gif" align="center" height="35" colspan="2">
										<asp:label id="ClassForm_Title" runat="server"> 班级信息管理</asp:label></th>
								</tr>								
								<tr id="class_no_records" runat="server">
									<td bgcolor="#ffffff" colspan="2">
										暂无记录！</td>
								</tr>
								<tr>
									<td bgcolor="#ffffff" colspan="2">
										<asp:Repeater id="class_Repeater" runat="server">
											<HeaderTemplate>
									</td>
								</tr>
								</HeaderTemplate>
								<ItemTemplate>
									<tr>
										<td bgcolor="Silver" height="28" width="8%">
											<asp:HyperLink id=class_name 
											NavigateUrl='<%# "classEdit.aspx"+"?"+"class_id="+Server.UrlEncode(DataBinder.Eval(Container.DataItem, "d_class_id").ToString()) +"&" +""%>'  
											runat="server">
												编辑
											</asp:HyperLink>
										</td>
										<td bgcolor="#FFFFFF">&nbsp;&nbsp;&nbsp;&nbsp;<%#Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "d_name").ToString()) %></td>
									</tr>
								</ItemTemplate>
								<FooterTemplate>
									<tr>
										<td bgcolor="#FFFFFF" colspan="2">
								</FooterTemplate>
						</asp:Repeater></td>
				</tr>
				<tr>
					<td align="center" bgcolor="silver" colspan="2">
						<asp:LinkButton id="class_insert" runat="server">创建新数据</asp:LinkButton>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE>
		</form>
		<center>
			<F:Footer id="Footer" runat="server" /></center>
	</body>
</HTML>
