<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchFile.aspx.cs" Inherits="SearchFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>第九章：网络硬盘===搜索文件</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellPadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">搜索文件</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:150" align="right">目录:</td>
			<td><asp:DropDownList ID="DirList" runat="server" Width="305px"></asp:DropDownList></td>
		</tr>	
		<tr style="line-height:2;">
			<td style="width:150" align="right">文件名称关键字:</td>
			<td><asp:textbox id="Name" runat="server" Width="300px" CssClass="InputCss"></asp:textbox>		
				<asp:RequiredFieldValidator ID="rfN" runat="server" ControlToValidate="Name"
					CssClass="GbText" Display="Dynamic" ErrorMessage="关键字不能为空！"></asp:RequiredFieldValidator></td>
		</tr>		
		<tr style="line-height:2;">
			<td style="width:150" align="right"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT></td>
		</tr>
		<tr style="line-height:2;">
			<td style="width:150" width="150" align="right"></TD>
			<TD align="left"><FONT face="宋体">&nbsp;</FONT><asp:Button ID="SearchBtn" runat="server" Text="搜索" Width="100px" CssClass="ButtonCss" OnClick="SearchBtn_Click" /><FONT face="宋体">&nbsp;</FONT><asp:Button ID="ReturnBtn" runat="server" Text="返回" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" CausesValidation="False" /></td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:GridView ID="FileView" runat="server" AutoGenerateColumns="False" Width="100%">
					<FooterStyle ForeColor="White" BackColor="#990000" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1" HorizontalAlign="Left"></HeaderStyle>
					<Columns>						
						<asp:TemplateField HeaderText="目录名称">
							<ItemTemplate>
								<asp:Image ID="FlagImage" runat="server" ImageUrl='<%#FormatImageUrl((bool)DataBinder.Eval(Container.DataItem,"Flag"),DataBinder.Eval(Container.DataItem,"Type").ToString()) %>' />&nbsp;
								<a href='<%#FormatHerf((int)DataBinder.Eval(Container.DataItem,"DirID"),(int)DataBinder.Eval(Container.DataItem,"ParentID"),(bool)DataBinder.Eval(Container.DataItem,"Flag"))%>'><%#DataBinder.Eval(Container.DataItem,"Name") %></a>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="40%" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="创建时间">
							<ItemTemplate>
								<%# DataBinder.Eval(Container.DataItem,"CreateDate") %>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="目录/文件大小">
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
    </table>
    </form>
</body>
</html>
