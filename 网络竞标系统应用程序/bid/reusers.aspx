<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Header" Src="Footer.ascx" %>
<%@ Page language="c#" Codebehind="reusers.aspx.cs" AutoEventWireup="false" Inherits="bid.reusers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>reusers</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="bid.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server">
			<table align="center" width="60%">
				<TBODY>
					<tr>
						<td align="center" valign="top" width="80%">
							<table border="0" cellspacing="1" cellpadding="0" width="100%" class="tableBorder1" align="center">
								<TBODY>
									
									<tr>
										<td width="100%" >
											<table width="100%" bgcolor="lightskyblue">
												<tr>													
													<td Width="20%" align="center">
														<a href="Browse.aspx">����б�</a>
													</td>
													<td Width="20%" align="center">
														<a href="Saleware.aspx">�༭������Ʒ</a>
													</td>													
													<td Width="10%" align="center">
														<a href="exit.aspx">ע��</a>
													</td>
												</tr>
											</table>
											<br>
											<p><asp:Label id="lblUserName" Runat="server" Font-Size="13px" Font-Name="verdana" /></p>
											
											<p align="justify">
												<b>����������Ʒ�ľ�������ʱ���ȣ�</b>
											</p>
											<asp:Label id="lblStatus" Runat="server" ForeColor="#ff0000" Font-Bold="True" />
											<asp:DataGrid id="myWinningBids" AutoGenerateColumns="False" Width="100%" HeaderStyle-BackColor="LightSkyBlue"
												HeaderStyle-Font-Bold="True" HeaderStyle-Font-Name="Verdana" HeaderStyle-Font-Size="13px"
												HeaderStyle-ForeColor="#ffffff" ItemStyle-BackColor="Beige" ItemStyle-Font-Name="verdana"
												ItemStyle-Font-Size="13px" BorderColor="#CCCCCC" Runat="server" OnItemCreated="myWinningBids_wareCreated"
												BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3">
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
												<ItemStyle Font-Size="13px" Font-Names="verdana" ForeColor="#000066"></ItemStyle>
												<HeaderStyle Font-Size="13px" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
												<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
												<Columns>
													<asp:TemplateColumn HeaderText="������Ʒ����">
														<ItemTemplate>
															<asp:hyperlink id="hypwareName"
															 NavigateUrl= '<%#DataBinder.Eval(Container.DataItem, "wareID") %>' 
															 Text='<%# DataBinder.Eval(Container.DataItem, "wareName") %>' Runat="server" />
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="HighestBid" HeaderText="��ʤ�ľ���"></asp:BoundColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
											</asp:DataGrid>
										</td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
		<center><F:Header id="Footer" runat="server" /></center>
	</body>
</HTML>
