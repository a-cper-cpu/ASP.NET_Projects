<%@ Register TagPrefix="F" TagName="Header" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="Saleware.aspx.cs" AutoEventWireup="false" Inherits="bid.Saleware" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Saleware</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="bid.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server">
			<table width="80%" align="center">
				<TBODY>
					<tr>
						<td vAlign="top" align="center" width="100%">
							<table class="tableBorder1" cellSpacing="1" cellPadding="0" width="100%" align="center"
								border="0">
								<TBODY>
									<tr>
										<td width="50%" background="images/sds01_r2_c8.gif">
											<table width="100%" bgColor="lightskyblue">
												<tr>
													<td align="center" width="25%"><A href="BrowseListing.aspx">浏览商品列表</A>
													</td>
													<td align="center" width="25%"><A href="Items.aspx?action=addnew">添加欲出售商品</A>
													</td>
												</tr>
											</table>
											<br>
											<asp:label id="lblUserName" Runat="server" Font-Size="13px" Font-Name="verdana"></asp:label><asp:label id="lblMsg" Runat="server" Font-Size="14px" Font-Name="verdana" Text="下面是你所希望出售的商品："
												Font-Bold="True" ForeColor="#000099"></asp:label><br>
											<br>
											<asp:label id="lblStatus" Runat="server" Font-Size="11px" Font-Name="verdana" ForeColor="#ff0000"></asp:label><asp:datagrid id="myItems" Runat="server" DataKeyField="ItemID" OnItemCreated="myItems_ItemCreated"
												OnDeleteCommand="myItems_DeleteCommand" OnUpdateCommand="myItems_UpdateCommand" OnEditCommand="myItems_EditCommand" OnCancelCommand="myItems_CancelCommand" BorderColor="#000000" ItemStyle-Font-Size="13px"
												ItemStyle-Font-Name="verdana" ItemStyle-BackColor="Beige" HeaderStyle-ForeColor="#ffffff" HeaderStyle-Font-Size="13px" HeaderStyle-Font-Name="Verdana" HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="LightSkyBlue"
												Width="100%" AutoGenerateColumns="False">
												<Columns>
													<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" />
													<asp:ButtonColumn text="Delete" CommandName="Delete" ItemStyle-Width="50px" />
													<asp:TemplateColumn HeaderText="名称">
														<ItemTemplate>
															<asp:Label ID="lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "wareName") %>' Runat="server" />
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox ID="txtitemName" Width="100" Text='<%# DataBinder.Eval(Container.DataItem, "wareName") %>' Runat="server" />
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="商品描述">
														<ItemTemplate>
															<asp:Label ID="lblDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' Runat="server" />
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox ID="txtDescription" TextMode="MultiLine" Rows="3" Columns="20" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' Runat="server" />
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Asking Price">
														<ItemTemplate>
															<asp:Label ID="lblAskPrice" Text='<%# DataBinder.Eval(Container.DataItem, "AskPrice") %>' Runat="server" />
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox ID="txtAskPrice" Width="65" Text='<%# DataBinder.Eval(Container.DataItem, "AskPrice") %>' Runat="server" />
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Notify Price">
														<ItemTemplate>
															<asp:Label ID="lblNotifyPrice" Text='<%# DataBinder.Eval(Container.DataItem, "NotifyPrice") %>' Runat="server" />
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox ID="txtNotifyPrice" Width="65" Text='<%# DataBinder.Eval(Container.DataItem, "NotifyPrice") %>' Runat="server" />
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Listing Date">
														<ItemTemplate>
															<asp:Label ID="lblListingDate" Text='<%# DataBinder.Eval(Container.DataItem, "ListingDate") %>' Runat="server" />
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</asp:datagrid><br>
											<asp:label id="lblNote1" Runat="server" Font-Size="14px" Text="*" Font-Bold="True" ForeColor="#000099"
												Visible="False"></asp:label><asp:label id="lblNote2" Runat="server" Font-Size="12px" Text=" Item Pending for Buyers Acceptance."
												ForeColor="#ff0000" Visible="False"></asp:label></td>
									</tr>
								</TBODY>
							</table>
						</td>
					</tr>
				</TBODY>
			</table>
		</form>
		<center><F:HEADER id="Footer" runat="server"></F:HEADER></center>
	</body>
</HTML>
