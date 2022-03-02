<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="wareDetails.aspx.cs" AutoEventWireup="false" Inherits="shopping.wareDetails1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>wareDetails</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="shopping.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" marginwidth="0" marginheight="0">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td colSpan="2">
					<H:Header id="Header" runat="server" />
				</td>
			</tr>
			<tr>
				<td vAlign="top" width="145">
					<T:Type id="type" runat="server" />
				</td>
				<td vAlign="top" align="left">
					<table height="100%" cellSpacing="0" cellPadding="0" width="620" align="left" border="0">
						<tr vAlign="top">
							<td>
								<br>
								<img src="images/1x1.gif" width="24" align="left">
								<table cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td class="ContentHead">
											<img height="32" src="images/1x1.gif" width="60" align="left"><asp:label id="ModelName" runat="server" />
											<br>
										</td>
									</tr>
								</table>
								<table cellSpacing="0" cellPadding="0" width="100%" border="0" valign="top">
									<tr vAlign="top">
										<td rowspan="2">
											<img height="1" width="24" src="images/1x1.gif">
										</td>
										<td width="309">
											<img height="15" src="images/1x1.gif">&nbsp;
											<asp:image id="GoodsImage" runat="server" height="277px" width="309" border="0" />
											<br>
											<BR>
											<BR>
											<IMG height="20" src="images/1x1.gif" width="72"><STRONG><FONT face="Verdana" color="#808080">价格</FONT></STRONG><SPAN class="UnitCost"><STRONG>:</STRONG>&nbsp;
												<asp:label id="UnitCost" runat="server"></asp:label></SPAN>
											<BR>
											<IMG height="20" src="images/1x1.gif" width="72"><STRONG><FONT face="Verdana" color="#808080">编码</FONT></STRONG><SPAN class="ModelNumber"><STRONG>:</STRONG>&nbsp;<STRONG>&nbsp;&nbsp;
												</STRONG>
												<asp:label id="ModelNumber" runat="server"></asp:label></SPAN>
											<BR>
											<IMG height="30" src="images/1x1.gif" width="72">
											<asp:hyperlink id="addToCart" runat="server" ImageUrl="images/add_to_cart.gif"></asp:hyperlink>
										</td>
										<TD>
											<TABLE width="300" border="0">
												<TR>
													<TD vAlign="top">
														<asp:label class="NormalDouble" id="desc" runat="server" Font-Bold="True" Font-Size="Larger"></asp:label><BR>
													</TD>
												</TR>
											</TABLE>
											<IMG height="30" src="images/1x1.gif"></TD>
									</tr>
									<TR>
									</TR>
								</table>
								<TABLE border="0">
									<TR>
										<TD><IMG height="20" src="images/1x1.gif" width="89">
										</TD>
										<TD width="100%"><FONT face="宋体">
												<asp:HyperLink id="BackHyperLink" runat="server" NavigateUrl="Default.aspx">返回</asp:HyperLink></FONT></TD>
									</TR>
								</TABLE>
								<F:Footer id="Footer" runat="server" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
