<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemProfile.aspx.cs" Inherits="SystemProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.Drawing" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第十三章：网络在线投票系统===投票系统配置</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">投票系统配置：</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>		
		<tr>
			<td>
				<asp:GridView ID="TopicView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="#3B6BD1" BorderWidth="1px" BackColor="White" 
					CellPadding="4" CssClass="GbText" DataKeyNames="TopicID">
					<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#330099" BackColor="White" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>	
				<Columns>
					<asp:TemplateField HeaderText="主题名称">
						<ItemTemplate>
							<%#DataBinder.Eval(Container.DataItem,"Name") %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle Width="20%" />
					</asp:TemplateField>
					<asp:TemplateField  HeaderText="详细说明">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"Body") %>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Left" />
						<HeaderStyle Width="50%" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="当前主题">
						<ItemTemplate>							
							<asp:RadioButton ID="IsCurrent" ForeColor="red" BackColor='<%# (bool)DataBinder.Eval(Container.DataItem,"IsCurrent") ? Color.Blue : Color.White %>'  GroupName="TopicGroup" Enabled="false" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem,"IsCurrent") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderStyle HorizontalAlign="Center" Width="10%" />
					</asp:TemplateField>									
					<asp:CommandField HeaderText="选择该行" SelectText="选择该行" ShowSelectButton="True" >
						<HeaderStyle Width="20%" HorizontalAlign="Center" />
						<ItemStyle HorizontalAlign="Center" />
					</asp:CommandField>
				</Columns>
					<AlternatingRowStyle BorderColor="CornflowerBlue" />
				</asp:GridView>
			</td>
		</tr>
		<tr>
			<td align="right"><asp:Button ID="SetCurrentBtn" runat="server" Text="设置选择的行为当前投票主题" Width="200px" CssClass="ButtonCss" OnClick="SetCurrentBtn_Click" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
		<tr>
			<td>
				<asp:DropDownList ID="RepeatList" runat="server" Width="200px">
					<asp:ListItem Selected="True" Value="0">不能重复投票</asp:ListItem>
					<asp:ListItem Value="1">可以重复投票</asp:ListItem>
				</asp:DropDownList>
				<asp:Button ID="SetRepeatBtn" runat="server" CssClass="ButtonCss" Text="设置" Width="50px" OnClick="SetRepeatBtn_Click" /></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
