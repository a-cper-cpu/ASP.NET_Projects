<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="UserManage.aspx.cs" Inherits="UserManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第八章：网络用户管理系统===用户管理页面</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">用户管理</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="UserView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="#3B6BD1" BorderWidth="1px" BackColor="White" 
					CellPadding="4" OnRowCommand="UserView_RowCommand" OnRowDeleting="UserView_RowDeleting">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#330099" BackColor="White" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>	
				<Columns>
					<asp:TemplateField HeaderText="用户名称">
						<ItemTemplate>
							<a href='ViewUser.aspx?UserID=<%#DataBinder.Eval(Container.DataItem,"UserID") %>'><%#DataBinder.Eval(Container.DataItem,"UserName") %></a>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField  HeaderText="电子邮件">
						<ItemTemplate>
							<a href='mailto:<%# DataBinder.Eval(Container.DataItem,"Email") %>'><%#DataBinder.Eval(Container.DataItem,"Email") %></a>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="是否为管理员">
						<ItemTemplate>							
							<asp:CheckBox ID="IsAdminCheck" Enabled="false" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem,"IsAdmin") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="用户操作">
						<ItemTemplate>
							<a href='EditUser.aspx?UserID=<%#DataBinder.Eval(Container.DataItem,"UserID") %>'>编辑</a>&nbsp;&nbsp;&nbsp;<a href='EditPwd.aspx?UserID=<%# DataBinder.Eval(Container.DataItem,"UserID") %>'>修改密码</a>&nbsp;&nbsp;&nbsp;
							<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" ImageUrl="~/Images/delete.gif" AlternateText="删除该用户" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserID") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="管理员设置">
						<ItemTemplate>
							<asp:Button ID="SetAdminBtn" CommandName="admin" Width="120" Text='<%# (bool)DataBinder.Eval(Container.DataItem,"IsAdmin")  == true ? "取消管理员权限" : "设为管理员"%>' CssClass="ButtonCss" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"UserID") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
				</Columns>
					<AlternatingRowStyle BorderColor="CornflowerBlue" />
				</asp:GridView>
			</td>
		</tr>
		<tr>
			<td><asp:Button ID="AddBtn" runat="server" Text="添加新的用户" Width="160" CssClass="ButtonCss" OnClick="AddBtn_Click" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
