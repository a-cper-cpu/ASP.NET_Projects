<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="users.aspx.cs" AutoEventWireup="false" Inherits="client.users" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>users</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<Link href="client.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server" />
		<form id="users" method="post" runat="server">
			<TABLE id="Table1" style="HEIGHT: 252px" cellSpacing="1" cellPadding="1" width="98%" align="center"
				border="1">
				<TR>
					<TD style="HEIGHT: 176px" vAlign="top" align="center">
						<asp:datagrid id="Dgd_user" runat="server" DataKeyField="Userid" OnUpdateCommand="DataGrid_update"
							OnEditCommand="DataGrid_edit" OnDeleteCommand="DataGrid_delete" OnCancelCommand="DataGrid_cancel"
							OnPageIndexChanged="DataGrid_page" AutoGenerateColumns="False" PageSize="5" AllowPaging="True"
							Width="100%" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" BackColor="White"
							CellPadding="3" GridLines="Vertical">
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
							<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Userid" HeaderText="用户号"></asp:BoundColumn>
								<asp:BoundColumn DataField="password" ReadOnly="True" HeaderText="密码" DataFormatString="******"></asp:BoundColumn>
								<asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="branch" HeaderText="用户类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="tell" HeaderText="联系电话"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><BR>
						<br>
						</FONT><A href="adduser.aspx">添加新用户</A></FONT></FONT></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="#cccccc" colSpan="2">
						<asp:button id="Btn_exit" CssClass="button" runat="server" Text="退出"></asp:button>
						<asp:Label id="Lbl_note" runat="server"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
