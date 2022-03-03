<%@ register tagprefix="T" tagname="Top" src="Top.ascx"%>
<%@ Page language="c#" Codebehind="Admin.aspx.cs" AutoEventWireup="false" Inherits="Forum.Admin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Admin</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<T:TOP id="Top" runat="server"></T:TOP>
		<form runat="server" ID="Form1">
			<center>
				<asp:DataGrid id="MyGrid" runat="server" AutoGenerateColumns="False" OnEditCommand="DataGrid_EditCommand"
					OnUpdateCommand="DataGrid_UpdateCommand" OnCancelCommand="DataGrid_CancelCommand" Width="700px"
					BorderColor="#3366CC" style="FONT-SIZE: 9pt" BackColor="White" BorderStyle="None" BorderWidth="1px"
					CellPadding="4">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="PushButton" UpdateText="更新" HeaderText="操作区" CancelText="删除" EditText="修改"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="id" ReadOnly="True" HeaderText="编号"></asp:BoundColumn>
						<asp:BoundColumn DataField="Begin1" ReadOnly="True" HeaderText="分类1"></asp:BoundColumn>
						<asp:BoundColumn DataField="End1" ReadOnly="True" HeaderText="分类2"></asp:BoundColumn>
						<asp:BoundColumn DataField="TopicDes" ReadOnly="True" HeaderText="名称"></asp:BoundColumn>
						<asp:BoundColumn DataField="Des" ReadOnly="True" HeaderText="描述"></asp:BoundColumn>						
						<asp:BoundColumn DataField="Toastmaster" ReadOnly="True" HeaderText="版主"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<table class="font">
					<tr>
						<td  >论坛分类1</td>
						<td  ><asp:TextBox id="td1" runat="server" Columns="10" class="unnamed2" Enabled="False" /></td>
					</tr>
					<tr>
						<td  >论坛分类2</td>
						<td><asp:TextBox id="td2" runat="server" Columns="78" class="unnamed2" Enabled="False" /></td>
					</tr>
					<tr>
						<td  >版块名</td>
						<td><asp:TextBox id="td3" runat="server" Columns="78" class="unnamed2" /></td>
					</tr>
					<tr>
						<td  >描述</td>
						<td><asp:TextBox id="td4" runat="server" Columns="78" class="unnamed2" /></td>
					</tr>
					<tr>
						<td  >logo</td>
						<td><asp:TextBox id="td5" runat="server" Columns="78" class="unnamed2" /></td>
					</tr>
					<tr>
						<td  >版主</td>
						<td><asp:TextBox id="td6" runat="server" Columns="78" class="unnamed2" /></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
