<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="team.aspx.cs" AutoEventWireup="false" Inherits="employee.team" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>team</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="employee.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="Team" method="post" runat="server">
			<TABLE id="Table1" style="HEIGHT: 252px" cellSpacing="1" cellPadding="1" width="60%" align="center"
				border="1">
				<TR>
					<TD style="HEIGHT: 176px" vAlign="top" align="center">
						<asp:datagrid id="Dgd_user" runat="server" DataKeyField="team_id" OnUpdateCommand="DataGrid_update"
							OnEditCommand="DataGrid_edit" OnDeleteCommand="DataGrid_delete" OnCancelCommand="DataGrid_cancel"
							OnPageIndexChanged="DataGrid_page" AutoGenerateColumns="False" PageSize="5" AllowPaging="True"
							Width="100%" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" BackColor="White"
							CellPadding="3" GridLines="Horizontal">
							<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
							<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
							<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="team_id" HeaderText="��Ŀ���"></asp:BoundColumn>
								<asp:BoundColumn DataField="team_name" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="����" CancelText="ȡ��" EditText="�༭"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="ɾ��" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><BR>
						<br>
						</FONT><A href="teamEdit.aspx">�����Ŀ��Ϣ</A></FONT></FONT></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#cccccc" colSpan="2">
						<asp:button id="Btn_exit" CssClass="button" runat="server" Text="�˳�"></asp:button>
						<asp:Label id="Lbl_note" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
