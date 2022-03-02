<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="T" TagName="Type" Src="Type.ascx" %>
<%@ Page language="c#" Codebehind="SearchResults.aspx.cs" AutoEventWireup="false" Inherits="shopping.SearchResults" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SearchResults</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="shopping.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td colSpan="2"><H:Header ID="Header1" runat="server" /></td>
			</tr>
			<tr>
				<td vAlign="top"></td>
				<td vAlign="top" noWrap align="left" width="100%">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
						<tr vAlign="top">
							<td noWrap>
								<form runat="server" ID="Form1">
									<asp:panel id="SearchPanel" runat="server" Width="100%">
										<P><FONT face="宋体"></FONT>&nbsp;</P>
										<P><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											</FONT>
											<asp:TextBox id="Search" runat="server"></asp:TextBox><FONT face="宋体">&nbsp;&nbsp;&nbsp;
											</FONT>
											<asp:Button id="SearchButton" runat="server" Text=" 查 找 "></asp:Button></P>
									</asp:panel></form>
								<br>
								<asp:datalist id="MyList" runat="server" RepeatColumns="2">
									<ItemTemplate>
										<table border="0" width="300">
											<tr>
												<td width="25">
													&nbsp;
												</td>
												<td width="100" valign="middle" align="right">
													<a href='wareDetails.aspx?wareID=<%# DataBinder.Eval(Container.DataItem, "wareID") %>'>
													</a>
												</td>
												<td width="200" valign="middle">
													<a href='wareDetails.aspx?wareID=<%# DataBinder.Eval(Container.DataItem, "wareID")%>'>
														<span class="ProductListHead">
															<%# DataBinder.Eval(Container.DataItem, "ModelName")%>
														</span>
														<br>
													</a><span class="ProductListItem"><b>价格： </b>
														<%# DataBinder.Eval(Container.DataItem, "SalePrice", "{0:c}")%>
													</span>
													<br>
													<a href='AddToCart.aspx?wareID=<%# DataBinder.Eval(Container.DataItem, "wareID")%>'>
														<font color="#9D0000"><b>放入购物车</b></font></a>
												</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:datalist><asp:label class="ErrorText" id="ErrorMsg" runat="server"></asp:label></td>
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
