<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="wareList.aspx.cs" AutoEventWireup="false" Inherits="shopping.wareList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wareList</title>
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
							<td nowrap>
								<br>
								<asp:DataList id="MyList" RepeatColumns="2" runat="server">
									<ItemStyle Font-Size="Medium"></ItemStyle>
									<ItemTemplate>
										<table border="0" width="300">
											<tr>
												<td width="25">
													&nbsp
												</td>
												<td width="100" valign="middle" align="right">
													<a href='wareDetails.aspx?wareID=<%# DataBinder.Eval(Container.DataItem, "wareID") %>'>
														
													</a>
												</td>
												<td width="200" valign="middle">
													<a href='wareDetails.aspx?wareID=<%# DataBinder.Eval(Container.DataItem, "wareID") %>'>
														<span class="ProductListHead">
															<%# DataBinder.Eval(Container.DataItem, "ModelName") %>
														</span>
														<br>
													</a><span class="ProductListItem"><b>价格： </b>
														<%# DataBinder.Eval(Container.DataItem, "SalePrice", "{0:c}") %>
													</span>
													<br>
													<a href='AddToCart.aspx?wareID=<%# DataBinder.Eval(Container.DataItem, "wareID") %>'>
														<span class="ProductListItem"><font color="#9D0000"><b>放入购物车<b></font></span> </a>
												</td>
											</tr>
										</table>
									</ItemTemplate>
									<HeaderStyle Font-Size="Medium"></HeaderStyle>
								</asp:DataList>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<TR>
				<TD vAlign="top"></TD>
				<TD vAlign="top" noWrap align="center" width="100%">
					<asp:HyperLink id="BackHyperLink" runat="server" NavigateUrl="Default.aspx">返回</asp:HyperLink></TD>
			</TR>
			<TR>
				<TD vAlign="top"></TD>
				<TD vAlign="top" noWrap align="left" width="100%"><FONT face="宋体">
						</FONT></TD>
			</TR>
		</table>
	</body>
</HTML>
