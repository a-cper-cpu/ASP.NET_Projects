<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="bid.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td valign="middle">
			<table id="Table1" runat="Server" border="0" cellspacing="0" cellpadding="0" width="500">
				<tr>
					<td align="center">
						<asp:HyperLink NavigateUrl="Default.aspx" id="Hyperlink1" runat="server">
							<h1>���羺�����ϵͳ</h1>
						</asp:HyperLink>
					</td>
					<td width="50"></td>
					<td align="center">
						<table width="100%" border="0" cellspacing="3" cellpadding="0" height="100%" align="center">
							<tr align="center" valign="middle">
								<td><img src="img/point2.gif" align="absMiddle"></td>
								<td><a href="Default.aspx#" onClick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://localhost/bid/Default.aspx')">��Ϊ��ҳ</a></td>
							</tr>
							<tr align="center" valign="middle">
								<td><img src="img/point2.gif" align="absMiddle"></td>
								<td>
									<a onclick="javascript:window.external.AddFavorite('http://localhost/bid/Default.aspx', '���羺��ϵͳ')">
										�����ղ� </a>
								</td>
							</tr>
							<tr align="center" valign="middle">
								<td><img src="img/point2.gif" align="absMiddle"></td>
								<td>
									<asp:HyperLink NavigateUrl="Default.aspx" id="Hyperlink2" runat="server">
					������ҳ
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
