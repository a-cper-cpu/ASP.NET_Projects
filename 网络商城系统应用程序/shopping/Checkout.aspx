<%@ Page language="c#" Codebehind="Checkout.aspx.cs" AutoEventWireup="false" Inherits="shopping.Checkout" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Checkout</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="shopping.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table cellspacing="0" cellpadding="0" width="100%" border="0">
			<tr>
				<td colspan="2">
					<H:Header ID="Header1" runat="server" />
				</td>
			</tr>
			<tr>
				<td valign="top">&nbsp;
				</td>
				<td align="left" valign="top" width="100%" nowrap>
					<table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr valign="top">
							<td nowrap>
								<br>
								<form runat="server" ID="Form1">
									<img align="left" width="24" src="images/1x1.gif">
									<table cellspacing="0" cellpadding="0" width="100%" border="0">
										<tr>
											<td>
												<img align="left" height="32" width="60" src="images/1x1.gif"><asp:Label ID="Header" runat="server" Font-Bold="True"> 查看并递交订单</asp:Label>
												<br>
											</td>
										</tr>
									</table>
									<img align="left" height="1" width="92" src="images/1x1.gif">
									<table height="100%" cellspacing="0" cellpadding="0" width="550" border="0">
										<tr valign="top">
											<td width="100%" class="Normal">
												<P><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
													<br>
													<asp:Label ID="Message" runat="server" Font-Size="12px" Height="18px" Font-Bold="True" Width="316px"> 请核对下面所有的信息</asp:Label>
													<br>
													<br>
													<asp:DataGrid id="MyDataGrid" width="90%" BorderColor="Black" GridLines="Vertical" cellpadding="4"
														Font-Name="Verdana" Font-Size="8pt" ShowFooter="True" HeaderStyle-CssClass="CartListHead"
														FooterStyle-CssClass="cartlistfooter" ItemStyle-CssClass="CartListItem" AlternatingItemStyle-CssClass="CartListItemAlt"
														AutoGenerateColumns="False" runat="server" Font-Names="Verdana">
														<AlternatingItemStyle CssClass="CartListItemAlt"></AlternatingItemStyle>
														<ItemStyle CssClass="CartListItem"></ItemStyle>
														<HeaderStyle CssClass="CartListHead"></HeaderStyle>
														<FooterStyle CssClass="cartlistfooter"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="ModelName" HeaderText="产品名称"></asp:BoundColumn>
															<asp:BoundColumn DataField="ModelNumber" HeaderText="类型编码"></asp:BoundColumn>
															<asp:BoundColumn DataField="wareQuantity" HeaderText="数量"></asp:BoundColumn>
															<asp:BoundColumn DataField="SalePrice" HeaderText="价格" DataFormatString="{0:c}"></asp:BoundColumn>
															<asp:BoundColumn DataField="ExtendedAmount" HeaderText="小计" DataFormatString="{0:c}"></asp:BoundColumn>
														</Columns>
													</asp:DataGrid>
													<br>
													<br>
													<b><FONT face="宋体" size="3">总额:</FONT> </b>
													<asp:Label ID="TotalLbl" runat="server" Font-Bold="True" Font-Size="Small" /></P>
												<p align="center">
													<asp:ImageButton id="SubmitBtn" ImageURL="images/submit.gif" runat="server" Width="80px" Height="23px" />
													<asp:HyperLink id="BackHyperLink" runat="server" Width="35px" Height="19px" NavigateUrl="Default.aspx">返回</asp:HyperLink>
												</p>
											</td>
										</tr>
										<TR>
											<TD class="Normal" width="100%"></TD>
										</TR>
									</table>
								</form>
							</td>
						</tr>
						<TR>
							<TD noWrap>
								<F:Footer ID="footer1" runat="server" /></TD>
						</TR>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
