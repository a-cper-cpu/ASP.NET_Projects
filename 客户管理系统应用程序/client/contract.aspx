<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="contract.aspx.cs" AutoEventWireup="false" Inherits="client.contract" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>contract</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="client.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="98%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 39px" bgColor="#cccccc" colSpan="2">
						<P align="center"><FONT face="����" size="4">��ͬ����</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center"><FONT face="����">
							<asp:datagrid id="Dgd_contract" runat="server" DataKeyField="contract_id" OnUpdateCommand="DataGrid_update"
								OnEditCommand="DataGrid_edit" OnDeleteCommand="DataGrid_delete" OnCancelCommand="DataGrid_cancel"
								Width="100%" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" OnPageIndexChanged="DataGrid_Page"
								BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
								GridLines="Vertical">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="contract_id" HeaderText="��ͬ���"></asp:BoundColumn>
									<asp:BoundColumn DataField="Client_id" HeaderText="�ͻ����"></asp:BoundColumn>
									<asp:BoundColumn DataField="Contract_state" HeaderText="��ͬ״��"></asp:BoundColumn>
									<asp:BoundColumn DataField="Contract_start" HeaderText="ǩ������"></asp:BoundColumn>
									<asp:BoundColumn DataField="Contract_send" HeaderText="ִ������"></asp:BoundColumn>
									<asp:BoundColumn DataField="Contract_finish" HeaderText="�������"></asp:BoundColumn>
									<asp:BoundColumn DataField="Contract_person" HeaderText="������"></asp:BoundColumn>
									<asp:BoundColumn DataField="Contract_price" HeaderText="�ܽ��"></asp:BoundColumn>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" CancelText="ȡ��" EditText="�༭"></asp:EditCommandColumn>
									<asp:ButtonColumn Text="ɾ��" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<P><FONT face="����"><asp:label id="Lbl_note" runat="server"></asp:label><BR>
									��ͬ״��: 1.δ����  2.ִ��  3.����
									<p>
									<asp:linkbutton id="Lbtn_add" runat="server"> ����º�ͬ </asp:linkbutton><BR>
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
