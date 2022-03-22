<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDisk.aspx.cs" Inherits="ShowDisk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>第九章：网络硬盘===网络硬盘主页</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellSpacing="0"
		cellPadding="2" width="100%" border="1">
		<tr>
			<td colspan="2"><font class="HeaderText">网络硬盘主页</font></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td colspan="2" style="line-height:2;">当前目录:<asp:DropDownList ID="DirList" runat="server" Width="305px" AutoPostBack="True" OnSelectedIndexChanged="DirList_SelectedIndexChanged"></asp:DropDownList>&nbsp;<a href="AddFolder.aspx">[新建文件夹]</a>&nbsp;<a href="SearchFile.aspx">[搜索文件]</a></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr valign="top">
			<td colspan="2">
				<asp:GridView ID="DiskView" runat="server" AutoGenerateColumns="False" CssClass="GbText"
					Width="100%" OnRowCommand="DiskView_RowCommand" OnRowDataBound="DiskView_RowDataBound" OnRowDeleting="DiskView_RowDeleting" DataKeyNames="DirID">
					<FooterStyle ForeColor="White" BackColor="#990000" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1" HorizontalAlign="Left"></HeaderStyle>
					<Columns>
						<asp:TemplateField>
							<ItemTemplate>
								<asp:CheckBox ID="DirCheck" runat="server" Checked="false" />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="5%" />
						</asp:TemplateField>
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
						<asp:TemplateField HeaderText="操作">
							<ItemTemplate>
								<a href='<%#(bool)DataBinder.Eval(Container.DataItem,"Flag") == true ? "EditFolder.aspx" : "EditFile.aspx" %>?DirID=<%#DataBinder.Eval(Container.DataItem,"DirID") %>'>编辑</a>&nbsp;&nbsp;&nbsp;																
								<asp:HyperLink ID="DownBtn"  Target="_blank" runat="server" ImageUrl="~/Images/down.gif" Visible='<%# !(bool)DataBinder.Eval(Container.DataItem,"Flag") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"Url")%>'></asp:HyperLink>&nbsp;&nbsp;&nbsp;
								<asp:ImageButton ID="DeleteBtn" runat="server" CommandName="delete" Visible='<%# (bool)DataBinder.Eval(Container.DataItem,"Flag") && ((int)DataBinder.Eval(Container.DataItem,"DirCount") + (int)DataBinder.Eval(Container.DataItem,"FileCount")) > 0 ? false : true %>' ImageUrl="~/Images/delete.gif" AlternateText="删除该数据项" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DirID") %>' />&nbsp;&nbsp;&nbsp;
								<asp:HyperLink ID="HerfUpload" Text="上载文件" Target="_blank" runat="server" Visible='<%#(bool)DataBinder.Eval(Container.DataItem,"Flag") %>' NavigateUrl='<%# "UploadFile.aspx?DirID=" + DataBinder.Eval(Container.DataItem,"DirID") %>'></asp:HyperLink>
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
			<td><asp:Button ID="ReturnBtn" runat="server" Text="返回上级目录" Width="100px" CssClass="ButtonCss" OnClick="ReturnBtn_Click" /></td>
		</tr>
		<tr>
			<td colspan="2"><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr style="line-height:2;">			
			<td align="right"><asp:Button ID="MoveBtn" runat="server" Text="移动到" Width="100px" CssClass="ButtonCss" OnClick="MoveBtn_Click" /><asp:DropDownList ID="MoveDirList" runat="server" Width="305px"></asp:DropDownList></td>
		</tr>	
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>
