<%@ Page language="c#" Codebehind="client.aspx.cs" AutoEventWireup="false" Inherits="client.client" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>client</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="client.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="98%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 39px" bgColor="#cccccc" colSpan="2">
						<P align="center"><FONT face="����" size="4">�ͻ�����</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center"><FONT face="����"><asp:datagrid id="Dgd_client" runat="server" DataKeyField="client_id" OnUpdateCommand="DataGrid_update"
								OnEditCommand="DataGrid_edit" OnDeleteCommand="DataGrid_delete" OnCancelCommand="DataGrid_cancel" Width="100%" AutoGenerateColumns="False"
								PageSize="5" AllowPaging="True" OnPageIndexChanged="DataGrid_Page" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White"
								CellPadding="3" GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="client_id" HeaderText="�ͻ����"></asp:BoundColumn>
									<asp:BoundColumn DataField="client_name" HeaderText="�ͻ�����"></asp:BoundColumn>
									<asp:BoundColumn DataField="client_charge" HeaderText="������"></asp:BoundColumn>
									<asp:BoundColumn DataField="client_level" HeaderText="�ͻ�����"></asp:BoundColumn>
									<asp:BoundColumn DataField="client_email" HeaderText="�ͻ�EMail"></asp:BoundColumn>
									<asp:BoundColumn DataField="client_tell" HeaderText="�ͻ��绰"></asp:BoundColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="client_id" DataNavigateUrlFormatString="client_information.aspx?client_id={0}"
										DataTextField="client_id" HeaderText="���" DataTextFormatString="{0}���"></asp:HyperLinkColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" CancelText="ȡ��" EditText="�༭"></asp:EditCommandColumn>
									<asp:ButtonColumn Text="ɾ��" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<P><FONT face="����"><asp:label id="Lbl_note" runat="server"></asp:label><BR>
									<BR>
									<asp:linkbutton id="Lbtn_add" runat="server">����¿ͻ�</asp:linkbutton><BR>
								</FONT>
							</P>
						</FONT>
					</TD>
				</TR>
				<TR>
					<td align="center" bgColor="#cccccc" colSpan="2"><asp:button id="Btn_back" runat="server" Text="����" CssClass="button"></asp:button></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
