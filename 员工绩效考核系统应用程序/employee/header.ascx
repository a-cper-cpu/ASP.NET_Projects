<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="employee.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td vAlign="middle">
			<table id="Header_holder" cellSpacing="0" cellPadding="0" width="700" border="0" runat="Server">
				<tr>
					<td align="center"><asp:hyperlink id="Header_Field3" runat="server" NavigateUrl="Default.aspx">
							<h1>员工绩效考核系统</h1>
						</asp:hyperlink></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center">
						<table height="100%" cellSpacing="3" cellPadding="0" width="100%" align="center" border="0">
							<tr vAlign="middle" align="center">
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Header_Field2" runat="server" NavigateUrl="Emp.aspx">
					员工信息
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Header_Field1" runat="server" NavigateUrl="loginedit.aspx">
					日志添加信息
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="sellogin.aspx">
					日志查询信息
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="team.aspx">
					项目维护信息
					</asp:hyperlink></td>
								<td><img src="images/point2.gif" align="absMiddle"></td>
								<td>
									<asp:HyperLink NavigateUrl="updatepwd.aspx" id="Hyperlink5" runat="server">
					修改密码
					</asp:HyperLink>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<br>
