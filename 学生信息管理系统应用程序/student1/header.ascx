<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="student1.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td valign="middle">
			<table id="Header_holder" runat="Server" border="0" cellspacing="0" cellpadding="0" width="500">
				<tr>
					<td align="center">
						<asp:HyperLink NavigateUrl="Default.aspx" id="Header_Field3" runat="server">
							<h1>学生信息管理系统</h1>
						</asp:HyperLink>
					</td>
					<td width="50"></td>
					<td align="center">
						<table width="100%" border="0" cellspacing="3" cellpadding="0" height="100%" align="center">
							<tr align="center" valign="middle">
								<td><img src="images/point2.gif" align="absMiddle"></td>
								<td>
									<asp:HyperLink NavigateUrl="speak.aspx" id="Header_Field2" runat="server">
					信息留言
					</asp:HyperLink>
								</td>
							</tr>
							<tr align="center" valign="middle">
								<td><img src="images/point2.gif" align="absMiddle"></td>
								<td>
									<asp:HyperLink NavigateUrl="Default.aspx" id="Header_Field1" runat="server">
					返回主页
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
