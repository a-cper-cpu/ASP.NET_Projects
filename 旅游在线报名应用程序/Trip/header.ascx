<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="Trip.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td vAlign="middle">
			<table id="Header_holder" cellSpacing="0" cellPadding="0" width="500" border="0" runat="Server">
				<tr>
					<td align="center"><asp:hyperlink id="Header_Field3" runat="server" NavigateUrl="Default.aspx">
							<h1>旅行社在线报名系统</h1>
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
								<td><asp:hyperlink id="Header_Field2" runat="server" NavigateUrl="Default.aspx">
					景点推荐
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Header_Field1" runat="server" NavigateUrl="Plan.aspx">
					行程安排
					</asp:hyperlink></td>	
					<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="AddTrip.aspx">
					网络订单
					</asp:hyperlink></td>								
								<td><img src="images/point2.gif" align="absMiddle"></td>
								<td>
									<asp:HyperLink NavigateUrl="" id="Hyperlink5" runat="server">
					系统管理员登录
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
