<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeavewordManage.aspx.cs" Inherits="LeavewordManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第10章：留言板===留言管理</title>
	<link href="ASPNET2.0BaseCss.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">留言管理</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="LeavewordView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="#3B6BD1" BorderWidth="1px" BackColor="White" 
					CellPadding="4" OnRowDataBound="LeavewordView_RowDataBound" OnRowDeleting="LeavewordView_RowDeleting" OnRowCommand="LeavewordView_RowCommand" CssClass="GbText" DataKeyNames="LeavewordID">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#330099" BackColor="White" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>	
				<Columns>
					<asp:TemplateField HeaderText="选择多行">
						<ItemTemplate>
							<asp:CheckBox ID="CheckItem" runat="server" />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="主题名称">
						<ItemTemplate>
							<a href='ViewLeaveword.aspx?LeavewordID=<%#DataBinder.Eval(Container.DataItem,"LeavewordID") %>'><%#DataBinder.Eval(Container.DataItem,"Title") %></a>
						</ItemTemplate>						
						<HeaderStyle Width="20%" />
					</asp:TemplateField>
					<asp:TemplateField  HeaderText="留言主体内容">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"Body") %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Left" />
						<HeaderStyle Width="50%" />
					</asp:TemplateField>					
					<asp:TemplateField HeaderText="操作">
						<ItemTemplate>
							<a href='AddReply.aspx?LeavewordID=<%#DataBinder.Eval(Container.DataItem,"LeavewordID") %>'>直接回复</a>
							<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" ImageUrl="~/Images/delete.gif" AlternateText="删除该留言" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"LeavewordID") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle Width="20%" />
					</asp:TemplateField>					
				</Columns>
					<AlternatingRowStyle BorderColor="CornflowerBlue" />
				</asp:GridView>
			</td>
		</tr>
		<tr>
			<td><asp:Button ID="ReplyBtn" runat="server" Text="回复所有选择的留言" Width="200px" CssClass="ButtonCss" OnClick="ReplyBtn_Click" /></td>
		</tr>		
    </table>
    </form>
</body>
</html>

