<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="school.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td valign="middle">
			<table id="Header_holder" runat="Server" border="0" cellspacing="0" cellpadding="0" width="500">
				<tr>
					<td align="center">
						<asp:HyperLink NavigateUrl="Default.aspx" id="Header_Field3" runat="server">
							<h1>校友录管理系统</h1>
						</asp:HyperLink>
					</td>
					
					<td align="center">
						<table width="100%" border="0" cellspacing="3" cellpadding="0" height="100%" align="center">
							<tr align="center" valign="middle">	
								<td><img src="img/point2.gif" align="absMiddle"></td>
								<td >
									<a  onclick="javascript:window.external.AddFavorite('http://localhost/school/Default.aspx', '校友录系统')">
									加入收藏</a>
								</td>													
							</tr>
							<tr align="center" valign="middle">
								<td><img src="img/point2.gif" align="absMiddle"></td>
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
