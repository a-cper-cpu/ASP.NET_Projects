<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReplyManage.aspx.cs" Inherits="ReplyManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>第10章：留言板===回复管理</title>
	<link href="ASPNET2.0BaseCss.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">回复管理</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td>
				<asp:DropDownList ID="LeavewordList" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="LeavewordList_SelectedIndexChanged">
				</asp:DropDownList>请选择所属留言。</td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="ReplyView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="#3B6BD1" BorderWidth="1px" BackColor="White" 
					CellPadding="4" OnRowDataBound="ReplyView_RowDataBound" OnRowDeleting="ReplyView_RowDeleting" OnRowCommand="ReplyView_RowCommand" CssClass="GbText" DataKeyNames="ReplyID">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#330099" BackColor="White" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>	
				<Columns>										
					<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="回复主体内容">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"Body") %>
						</ItemTemplate>						
						<HeaderStyle Width="80%" />
					</asp:TemplateField>					
					<asp:TemplateField HeaderText="操作">
						<ItemTemplate>
							<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" ImageUrl="~/Images/delete.gif" AlternateText="删除该留言" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ReplyID") %>' />
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
			<td></td>
		</tr>		
    </table>
    </form>
</body>
</html>
