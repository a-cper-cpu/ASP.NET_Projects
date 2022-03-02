<%@ Page language="c#" Codebehind="shoppingcart.aspx.cs" AutoEventWireup="false" Inherits="shopping.shoppingcart" %>
<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>shoppingcart</title>
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
											<td>&nbsp;&nbsp;<img id="cartimg" src="images/cart.gif"> <STRONG><FONT size="4">我的购物车</FONT></STRONG>
												<br>
											</td>
										</tr>
									</table>
									<img align="left" height="4" width="110" src="images/1x1.gif"> <font color="red">
										<asp:Label id="MyError" class="ErrorText" EnableViewState="false" runat="Server" Font-Size="Large"
											Font-Bold="True" />
									</font>
									<br>
									<img align="left" height="15" width="24" src="images/1x1.gif" border="0">
									<asp:panel id="DetailsPanel" runat="server">
										<IMG height="1" src="images/1x1.gif" width="50" align="left">
										<TABLE height="100%" cellSpacing="0" cellPadding="0" width="550" border="0">
											<TR vAlign="top">
												<TD width="550">
													<asp:DataGrid id="MyList" runat="server" Font-Size="8pt" Font-Names="Verdana" BorderColor="Black"
														GridLines="Vertical" cellpadding="4" Font-Name="Verdana" ShowFooter="True" HeaderStyle-CssClass="CartListHead"
														FooterStyle-CssClass="CartListFooter" ItemStyle-CssClass="CartListItem" AlternatingItemStyle-CssClass="CartListItemAlt"
														DataKeyField="wareQuantity" AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="CartListItemAlt"></AlternatingItemStyle>
														<ItemStyle CssClass="CartListItem"></ItemStyle>
														<HeaderStyle Font-Size="Medium" CssClass="CartListHead"></HeaderStyle>
														<FooterStyle CssClass="CartListFooter"></FooterStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="产品编号">
																<ItemTemplate>
																	<asp:Label id="wareID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "wareID") %>' />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="ModelName" HeaderText="产品名称"></asp:BoundColumn>
															<asp:BoundColumn DataField="ModelNumber" HeaderText="模型"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="数量">
																<ItemTemplate>
																	<asp:TextBox id="wareQuantity" runat="server" Columns="4" MaxLength="3" Text='<%# DataBinder.Eval(Container.DataItem, "wareQuantity") %>' width="40px" />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="SalePrice" HeaderText="价格" DataFormatString="{0:c}"></asp:BoundColumn>
															<asp:BoundColumn DataField="ExtendedAmount" HeaderText="小计" DataFormatString="{0:c}"></asp:BoundColumn>
															<asp:TemplateColumn HeaderText="删除">
																<ItemTemplate>
																	<center>
																		<asp:CheckBox id="Remove" runat="server" />
																	</center>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid><IMG height="1" src="Images/1x1.gif" width="350"> <SPAN class="NormalBold">
														<FONT face="宋体" size="3">总额:</FONT> </SPAN>
													<asp:Label class="NormalBold" id="lblTotal" runat="server" Font-Size="Small" EnableViewState="false"></asp:Label><BR>
													<BR>
													<IMG height="1" src="Images/1x1.gif" width="60">
													<asp:imagebutton id="UpdateBtn" runat="server" ImageURL="images/update_cart.gif"></asp:imagebutton><IMG height="1" src="Images/1x1.gif" width="15">
													<asp:imagebutton id="CheckoutBtn" runat="server" ImageURL="images/final_checkout.gif"></asp:imagebutton><BR>
												</TD>
											</TR>
										</TABLE>
									</asp:panel>
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
