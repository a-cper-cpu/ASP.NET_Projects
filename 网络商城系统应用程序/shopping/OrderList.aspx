<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Page language="c#" Codebehind="OrderList.aspx.cs" AutoEventWireup="false" Inherits="shopping.OrderList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OrderList</title>
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
								<form runat="server" ID="Form1">
									<img align="left" width="24" src="images/1x1.gif">
									<table cellspacing="0" cellpadding="0" width="100%" border="0">
										<tr>
											<td>
												<img align="left" height="32" width="60" src="images/1x1.gif">&nbsp;&nbsp;<STRONG>所有订单信息</STRONG>
												&nbsp;
												<br>
											</td>
										</tr>
									</table>
									<img align="left" height="4" width="110" src="images/1x1.gif"> <font color="red">
										<asp:Label id="MyError" class="ErrorText" runat="Server" Font-Size="Large" Font-Bold="True" />
									</font>
									<br>
									<img align="left" height="15" width="84" src="images/1x1.gif" border="0">
									<table height="100%" cellspacing="0" cellpadding="0" width="550" border="0">
										<tr valign="top">
											<td width="100%">
												<asp:DataGrid id="MyList" width="90%" BorderColor="Black" GridLines="Vertical" cellpadding="4"
													Font-Name="Verdana" Font-Size="8pt" ShowFooter="True" HeaderStyle-CssClass="CartListHead"
													FooterStyle-CssClass="cartlistfooter" ItemStyle-CssClass="CartListItem" AlternatingItemStyle-CssClass="CartListItemAlt"
													AutoGenerateColumns="False" runat="server" Font-Names="Verdana">
													<AlternatingItemStyle CssClass="CartListItemAlt"></AlternatingItemStyle>
													<ItemStyle CssClass="CartListItem"></ItemStyle>
													<HeaderStyle Font-Size="Medium" CssClass="CartListHead"></HeaderStyle>
													<FooterStyle CssClass="cartlistfooter"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="OrderID" HeaderText="订单编号"></asp:BoundColumn>
														<asp:BoundColumn DataField="OrderDate" HeaderText="订单日期" DataFormatString="{0:d}"></asp:BoundColumn>
														<asp:BoundColumn DataField="OrderTotalCost" HeaderText="订单总金额" DataFormatString="{0:c}"></asp:BoundColumn>
														<asp:HyperLinkColumn Text="显示详细信息" DataNavigateUrlField="OrderID" DataNavigateUrlFormatString="orderdetails.aspx?OrderID={0}"
															HeaderText="显示详细信息"></asp:HyperLinkColumn>
													</Columns>
												</asp:DataGrid>
											</td>
										</tr>
									</table>
								</form>
							</td>
						</tr>
						<TR>
							<TD noWrap>
								<F:Footer ID="footer1" runat="server" />
							</TD>
						</TR>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
