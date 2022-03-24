<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reader.aspx.cs" Inherits="Reader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第11章：网络邮件管理系统===查看邮件</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body style="margin-left:0;margin-top:0;margin-left:0">
    <form id="form1" runat="server" method="post">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellspacing="0"
		cellpadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">查看邮件:</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px" align="right">收件人:</td>
			<td><asp:textbox id="To" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		</td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px" align="right">抄送:</td>
			<td><asp:textbox id="CC" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		</td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:155px" align="right">主题:</td>
			<td><asp:textbox id="Title" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		</td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:155px" align="right">邮件格式:</td>
			<td><input id="HtmlCB" type="checkbox" runat="server" class="GbText" disabled="disabled" />HTML格式</td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:155px" align="right" valign="top">内容:</td>
			<td><asp:textbox id="Body" runat="server" Width="400px" CssClass="InputCss" Height="200px" TextMode="MultiLine"></asp:textbox>		</td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px" align="right" valign="top">邮件附件:</td>
			<td><asp:GridView ID="AttachView" runat="server" AutoGenerateColumns="False" CssClass="GbText"
					Width="100%" DataKeyNames="AttachmentID" HorizontalAlign="Left">
					<FooterStyle ForeColor="White" BackColor="#3B6BD1" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1"></HeaderStyle>
					<Columns>						
						<asp:TemplateField HeaderText="文件名称">
							<ItemTemplate>
								<a href='<%#DataBinder.Eval(Container.DataItem,"Url") %>' target="_blank"><%#DataBinder.Eval(Container.DataItem,"Name") %></a>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="70%" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="文件类型">
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem,"Type") %>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>						
						<asp:TemplateField  HeaderText="文件大小">
							<ItemTemplate>
								<%# (int)DataBinder.Eval(Container.DataItem,"Contain")/1024 %>KB
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
			<td style="width:155px; height: 29px;" align="right"></td>
			<td align="left" style="height: 29px"><font face="宋体">&nbsp;</font></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:155px; height: 29px;" align="right"></td>
			<td align="left" style="height: 29px"><font face="宋体">&nbsp;</font><asp:Button ID="RecieverBtn" runat="server" Text="回复" Width="100px" CssClass="ButtonCss" OnClick="RecieverBtn_Click" /><font face="宋体">&nbsp;</font><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td style="width: 155px"></td>
		</tr>
    </table>
    </form>  
</body>
</html>
