<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemManage.aspx.cs" Inherits="ItemManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第十三章：网络在线投票系统===投票项目的选择项管理</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">投票项目的选择项管理</font></td>
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
				<asp:DropDownList ID="SubjectList" runat="server" Width="300px" OnSelectedIndexChanged="SubjectList_SelectedIndexChanged" AutoPostBack="True">
				</asp:DropDownList>请选择所属投票项目。</td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="ItemView" Width="100%" runat="server" AutoGenerateColumns="False" 
					CellPadding="4" OnRowCommand="ItemView_RowCommand" OnRowDataBound="ItemView_RowDataBound" OnRowDeleting="ItemView_RowDeleting" ForeColor="#333333" GridLines="Both">
					<FooterStyle ForeColor="White" BackColor="#990000" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>	
				<Columns>
					<asp:TemplateField HeaderText="项目名称">
						<ItemTemplate>
							<%#DataBinder.Eval(Container.DataItem,"Name") %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Left" />
						<HeaderStyle Width="60%" />
					</asp:TemplateField>
					<asp:TemplateField  HeaderText="当前票数">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"VoteCount") %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle Width="20%" />
					</asp:TemplateField>					
					<asp:TemplateField HeaderText="用户操作">
						<ItemTemplate>
							<a href='UpdateItem.aspx?ItemID=<%#DataBinder.Eval(Container.DataItem,"ItemID") %>'>编辑</a>&nbsp;&nbsp;&nbsp;
							<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" ImageUrl="~/Images/delete.gif" AlternateText="删除该用户" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ItemID") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle Width="20%" />
					</asp:TemplateField>					
				</Columns>
					<AlternatingRowStyle BorderColor="CornflowerBlue" BackColor="White" BorderStyle="Solid" BorderWidth="1px" />
					<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
					<EditRowStyle BorderColor="CornflowerBlue" BorderWidth="1px" />
				</asp:GridView>
			</td>
		</tr>
		<tr>
			<td><asp:Button ID="AddBtn" runat="server" Text="添加新的选择项" Width="160" CssClass="ButtonCss" OnClick="AddBtn_Click" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
