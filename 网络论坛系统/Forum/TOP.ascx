<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TOP.ascx.cs" Inherits="Forum.TOP" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td valign="middle">
			<table id="Header_holder" runat="Server" border="0" cellspacing="0" cellpadding="0" width="600">
				<tr>
					<td align="center" style="WIDTH: 407px; HEIGHT: 65px">
						<asp:HyperLink NavigateUrl="Default.aspx" id="Header_Field3" runat="server">
							<h1>网络论坛系统</h1>
						</asp:HyperLink>
					</td>
					<td align="center" style="HEIGHT: 65px">
						<table width="240" border="0" cellspacing="3" cellpadding="0" height="51" align="center"
							style="WIDTH: 240px; HEIGHT: 51px">
							<tr align="center" valign="middle">
								<td style="HEIGHT: 21px"><img src="images/point2.gif" align="absMiddle"></td>
								<td align="left" style="HEIGHT: 21px">
									<asp:HyperLink NavigateUrl="" id="Header_Field2" runat="server">
					登录
					</asp:HyperLink>
								</td>
								<td style="HEIGHT: 21px"><img src="images/point2.gif" align="absMiddle"></td>
								<td align="left" style="HEIGHT: 21px">
										<asp:HyperLink NavigateUrl="Default.aspx" id="Hyperlink1" runat="server">
					首页
					</asp:HyperLink>
									
								</td>
							</tr>
							<tr align="center" valign="middle">
								<td><img src="images/point2.gif" align="absMiddle"></td>
								<td align="left">
								<asp:HyperLink NavigateUrl="register.aspx?action=reg&amp;UserName=" id="Header_Field1" runat="server">
					注册
					</asp:HyperLink>
								</td>
								<td><img src="images/point2.gif" align="absMiddle"></td>
								<td align="left">
									<asp:HyperLink NavigateUrl="" id="Hyperlink2" runat="server">
					个人资料
					</asp:HyperLink>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<FONT face="宋体" size="2"><STRONG>
					<asp:Label id="Label1" runat="server"></asp:Label>欢迎你！</STRONG></FONT>
		</td>
	</tr>
</table>
