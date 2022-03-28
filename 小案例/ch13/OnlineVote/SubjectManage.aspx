<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubjectManage.aspx.cs" Inherits="SubjectManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第十三章：网络在线投票系统===投票项目管理</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">投票项目管理</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td>
				<asp:DropDownList ID="TopicList" runat="server" Width="300px" OnSelectedIndexChanged="TopicList_SelectedIndexChanged" AutoPostBack="True">
				</asp:DropDownList>请选择所属投票主题。</td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="SubjectView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="#3B6BD1" BorderWidth="1px" BackColor="White" 
					CellPadding="4" CssClass="GbText" OnRowCommand="SubjectView_RowCommand" OnRowDataBound="SubjectView_RowDataBound" OnRowDeleting="SubjectView_RowDeleting">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#330099" BackColor="White" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>	
				<Columns>
					<asp:TemplateField HeaderText="项目名称">
						<ItemTemplate>
							<%#DataBinder.Eval(Container.DataItem,"Name") %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Left" />
						<HeaderStyle Width="60%" />
					</asp:TemplateField>
					<asp:TemplateField  HeaderText="显示模式">
						<ItemTemplate>
							<%# (bool)DataBinder.Eval(Container.DataItem,"Mode") ? "多选模式" : "单选模式" %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle Width="20%" />
					</asp:TemplateField>					
					<asp:TemplateField HeaderText="用户操作">
						<ItemTemplate>
							<a href='UpdateSubject.aspx?SubjectID=<%#DataBinder.Eval(Container.DataItem,"SubjectID") %>'>编辑</a>&nbsp;&nbsp;&nbsp;
							<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" ImageUrl="~/Images/delete.gif" AlternateText="删除该用户" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SubjectID") %>' />
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
			<td><asp:Button ID="AddBtn" runat="server" Text="添加新的项目" Width="160" CssClass="ButtonCss" OnClick="AddBtn_Click" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>