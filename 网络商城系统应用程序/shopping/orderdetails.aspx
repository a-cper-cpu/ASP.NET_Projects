<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="orderdetails.aspx.cs" AutoEventWireup="false" Inherits="shopping.orderdetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>orderdetails</title>
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
				<td valign="top">
					<T:Type id="Type1" runat="server" />
					<img height="1" src="images/1x1.gif" width="145">
				</td>
				<td align="left" valign="top" width="100%" nowrap>
					<table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
						<tr valign="top">
							<td nowrap><FONT face="宋体"></FONT>
								<br>
								<img align="left" width="24" src="images/1x1.gif">
								<table cellspacing="0" cellpadding="0" width="100%" border="0">
									<tr>
										<td class="ContentHead">
											<img align="left" height="32" width="60" src="images/1x1.gif"> 订单详细信息&nbsp;
											<br>
										</td>
									</tr>
								</table>
								<img align="left" height="15" width="86" src="images/1x1.gif" border="0">
								<asp:Label id="MyError" CssClass="ErrorText" EnableViewState="false" runat="Server" />
								<table id="detailsTable" height="100%" cellspacing="0" cellpadding="0" width="550" border="0"
									EnableViewState="false" runat="server">
									<tr valign="top">
										<td width="100%" class="Normal">
											<P>
												<br>
												<b><FONT size="3">订单编号:</FONT> </b>
												<asp:Label ID="lblOrderNumber" EnableViewState="false" runat="server" /></P>
											<STRONG><FONT size="3"></FONT></STRONG>
											<P>
												<br>
												<b><FONT size="3">订单日期:</FONT> </b>
												<asp:Label ID="lblOrderDate" EnableViewState="false" runat="server" />
												<br>
												<br>
												<asp:DataGrid id="GridControl1" width="90%" BorderColor="Black" GridLines="Vertical" cellpadding="4"
													Font-Name="Verdana" Font-Size="16pt" ShowFooter="True" HeaderStyle-CssClass="CartListHead"
													FooterStyle-CssClass="cartlistfooter" ItemStyle-CssClass="CartListItem" AlternatingItemStyle-CssClass="CartListItemAlt"
													AutoGenerateColumns="False" runat="server" Font-Names="Verdana">
													<AlternatingItemStyle CssClass="CartListItemAlt"></AlternatingItemStyle>
													<ItemStyle CssClass="CartListItem"></ItemStyle>
													<HeaderStyle Font-Size="Medium" CssClass="CartListHead"></HeaderStyle>
													<FooterStyle CssClass="cartlistfooter"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="ModelName" HeaderText="产品名称"></asp:BoundColumn>
														<asp:BoundColumn DataField="ModelNumber" HeaderText="类别编号"></asp:BoundColumn>
														<asp:BoundColumn DataField="wareQuantity" HeaderText="数量"></asp:BoundColumn>
														<asp:BoundColumn DataField="UnitCost" HeaderText="价格" DataFormatString="{0:c}"></asp:BoundColumn>
														<asp:BoundColumn DataField="ExtendedAmount" HeaderText="小计" DataFormatString="{0:c}"></asp:BoundColumn>
													</Columns>
												</asp:DataGrid>
												<br>
												<b><FONT size="4">总额</FONT>: </b>
												<asp:Label ID="lblTotal" EnableViewState="false" runat="server" /></P>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<TR>
							<TD noWrap><FONT face="宋体">
									<F:Footer id="Footer" runat="server" /></FONT></TD>
						</TR>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
