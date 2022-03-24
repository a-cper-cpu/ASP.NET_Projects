<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMail.aspx.cs" Inherits="ViewMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第11章：网络邮件管理系统===查看邮件列表</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body style="margin-left:0;margin-top:0;margin-left:0">
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellpadding="2" width="100%" border="1">		
		<tr valign="top">
			<td colspan="2">
				<asp:GridView ID="MailView" runat="server" AutoGenerateColumns="False" CssClass="GbText"
					Width="100%" DataKeyNames="MailID">
					<FooterStyle ForeColor="White" BackColor="#990000" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1" HorizontalAlign="Left"></HeaderStyle>
					<Columns>
						<asp:TemplateField>
							<ItemTemplate>
								<asp:CheckBox ID="checkMail" runat="server" Checked="false" />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="5%" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="发件人">
							<ItemTemplate>
								<a href='Reader.aspx?MailID=<%# DataBinder.Eval(Container.DataItem,"MailID") %>&FolderID=<%# DataBinder.Eval(Container.DataItem,"FolderID") %>'><%=AliasName%>&nbsp;<%=Email %></a>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="30%" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="创建时间">
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem,"SenderDate")%>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="主题">
							<ItemTemplate>
								<a href='Reader.aspx?MailID=<%# DataBinder.Eval(Container.DataItem,"MailID") %>&FolderID=<%# DataBinder.Eval(Container.DataItem,"FolderID") %>'><%# DataBinder.Eval(Container.DataItem,"Title") %></a>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="35%" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="邮件大小">
							<ItemTemplate>
								<%# (int)DataBinder.Eval(Container.DataItem,"Contain")/1024 %>KB&nbsp;<asp:Image runat="server" ID="AttachmentFlag" ImageUrl="Images/attach.gif" visible='<%# (bool)DataBinder.Eval(Container.DataItem,"AttachmentFlag") %>' />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>	
					</Columns>
					<AlternatingRowStyle BorderColor="CornflowerBlue" BackColor="White" BorderStyle="Solid" BorderWidth="1px" />
					<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
					<EditRowStyle BorderColor="CornflowerBlue" BorderWidth="1px" />
				</asp:GridView>
			</td>			
		</tr>		
		<tr style="line-height:2;">
			<td align="left" style="height: 25px"><asp:CheckBox ID="CheckMail" runat="server" Text="选择所有邮件" Width="100%" /></td>		
			<td align="right" style="height: 25px"><asp:Button ID="DeleteBtn" runat="server" Text="删除" Width="60px" CssClass="ButtonCss" OnClick="DeleteBtn_Click" />
				<asp:Button ID="MoveBtn" runat="server" Text="移动到" Width="60px" CssClass="ButtonCss" OnClick="MoveBtn_Click" /><asp:DropDownList ID="FolderList" runat="server" Width="200px"></asp:DropDownList></td>
		</tr>
    </table>
    </form>
</body>
</html>
