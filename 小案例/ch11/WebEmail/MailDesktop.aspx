<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MailDesktop.aspx.cs" Inherits="MailDesktop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第11章：网络邮件管理系统===邮件平台</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body style="margin-left:0;margin-top:0;margin-left:0">
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellpadding="2" width="100%" border="1">		
		<tr valign="top">
			<td colspan="2">
				<asp:GridView ID="FolderView" runat="server" AutoGenerateColumns="False" CssClass="GbText"
					Width="100%" OnRowCommand="FolderView_RowCommand" OnRowDataBound="FolderView_RowDataBound" OnRowDeleting="FolderView_RowDeleting" DataKeyNames="FolderID" Caption="邮件列表详细信息" CaptionAlign="Left" HorizontalAlign="Left" ShowFooter="True">
					<FooterStyle ForeColor="White" BackColor="#3B6BD1" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>
					<Columns>						
						<asp:TemplateField HeaderText="文件夹名称">
							<ItemTemplate>
								<a href='ViewMail.aspx?FolderID=<%#DataBinder.Eval(Container.DataItem,"FolderID") %>'><%#DataBinder.Eval(Container.DataItem,"Name") %></a>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="40%" />
							<FooterTemplate>
								总计
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="邮件总数">
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem,"Total") %>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="新邮件数量">
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem,"NoReader") %>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="文件夹大小">
							<ItemTemplate>
								<%# (int)DataBinder.Eval(Container.DataItem,"Contain")/1024 %>KB
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>					
						<asp:TemplateField HeaderText="操作">
							<ItemTemplate>
								<asp:HyperLink ID="EditBtn" Text="重命名" Target="Desktop" runat="server" Visible='<%# (bool)DataBinder.Eval(Container.DataItem,"Flag") %>' NavigateUrl='<%# "RenameFolder.aspx?FolderID=" + DataBinder.Eval(Container.DataItem,"FolderID")%>'></asp:HyperLink>&nbsp;&nbsp;&nbsp;
								<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" Visible='<%# (bool)DataBinder.Eval(Container.DataItem,"Flag") && ((int)DataBinder.Eval(Container.DataItem,"Total") > 0 ? false : true) %>' ImageUrl="~/Images/delete.gif" AlternateText="删除文件夹" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FolderID") %>' />&nbsp;&nbsp;&nbsp;
								</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="30%" HorizontalAlign="Center" />
						</asp:TemplateField>					
					</Columns>
					<AlternatingRowStyle BorderColor="CornflowerBlue" BackColor="White" BorderStyle="Solid" BorderWidth="1px" />
					<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
					<EditRowStyle BorderColor="CornflowerBlue" BorderWidth="1px" />
				</asp:GridView>
			</td>			
		</tr>
		<tr>
			<td><asp:Button ID="NewFolderBtn" runat="server" Text="新建文件夹" Width="100px" CssClass="ButtonCss" OnClick="NewFolderBtn_Click" /></td>
		</tr>		
    </table>
    </form>
</body>
</html>
