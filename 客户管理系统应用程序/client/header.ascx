<%@ Control Language="c#" AutoEventWireup="false" Codebehind="header.ascx.cs" Inherits="client.header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<br>
<table align="center" border="0">
	<tr>
		<td vAlign="middle">
			<table id="Header_holder" cellSpacing="0" cellPadding="0" width="700" border="0" runat="Server">
				<tr>
					<td align="center"><asp:hyperlink id="Header_Field3" runat="server" NavigateUrl="Default.aspx">
							<h1>客户管理系统</h1>
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
								<td><asp:hyperlink id="Header_Field2" runat="server" NavigateUrl="users.aspx">
					用户信息
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Header_Field1" runat="server" NavigateUrl="client.aspx">
					客户信息
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="product.aspx">
					产品信息
					</asp:hyperlink></td>
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="contract.aspx">
					合同信息
					</asp:hyperlink></td>
					<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink5" runat="server" NavigateUrl="con_mx.aspx">
					合同明细
					</asp:hyperlink></td>
								
								<td><IMG src="images/point2.gif" align="absMiddle"></td>
								<td><asp:hyperlink id="Hyperlink4" runat="server" NavigateUrl="contract_stat.aspx">
					产品销售统计
					</asp:hyperlink></td>
								
							
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<br>
