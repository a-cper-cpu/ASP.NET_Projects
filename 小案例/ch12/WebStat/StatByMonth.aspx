<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatByMonth.aspx.cs" Inherits="StatByMonth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第12章:网站流量统计===按月统计用户访问量</title>
    <link rel="Stylesheet" href="ASPNET2.0BaseCss.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="GbText" style="BORDER-COLLAPSE: collapse; border-right: #ccccff thin solid; border-top: #ccccff thin solid; border-left: #ccccff thin solid; border-bottom: #ccccff thin solid;" borderColor="#93bee2" cellspacing="0"
		cellpadding="2" width="100%" border="1">
		<tr>
			<td colspan="2" style="background-color: #6699cc;"><font class="HeaderText">按月统计用户访问量</font></td>
		</tr>	
		<tr>
			<td>
				请选择时间：<asp:DropDownList ID="YearList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="YearList_SelectedIndexChanged">
					<asp:ListItem Value="0" Selected="True">2006</asp:ListItem>
					<asp:ListItem Value="1">2007</asp:ListItem>
					<asp:ListItem Value="2">2008</asp:ListItem>
					<asp:ListItem Value="3">2009</asp:ListItem>
					<asp:ListItem Value="4">2010</asp:ListItem>
					<asp:ListItem Value="5">2011</asp:ListItem>
					<asp:ListItem Value="6">2012</asp:ListItem>
					<asp:ListItem Value="7">2013</asp:ListItem>
					<asp:ListItem Value="8">2014</asp:ListItem>
					<asp:ListItem Value="9">2015</asp:ListItem>
				</asp:DropDownList>年</td>
		</tr>	
		<tr>
			<td colspan="2">
				<asp:GridView ID="StatView" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="GbText" ShowFooter="True">
					<FooterStyle ForeColor="White" HorizontalAlign="Center" BackColor="#3B6BD1" Font-Bold="True"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="Navy" BackColor="#FFCC66" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="#333333" BackColor="#FFFBD6" BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" />
					<HeaderStyle Font-Bold="True" ForeColor="#FFFFCC" CssClass="GbText" BackColor="#3B6BD1" HorizontalAlign="Left"></HeaderStyle>
					<Columns>						
						<asp:TemplateField HeaderText="访问时间">
							<ItemTemplate>
								<%# ((VisitStat)Container.DataItem).Name %>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Left" />
							<HeaderStyle Width="40%" />
							<FooterTemplate>
								总计:
							</FooterTemplate>
							<FooterStyle HorizontalAlign="left" />
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="访问次数">
							<ItemTemplate>
								<%# ((VisitStat)Container.DataItem).Number %>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
							<HeaderStyle Width="15%" HorizontalAlign="Center" />
							<FooterTemplate>
								<%=total%>
							</FooterTemplate>
						</asp:TemplateField>
						<asp:TemplateField  HeaderText="百分比">
							<ItemTemplate>
								<%# ((VisitStat)Container.DataItem).Percent %>%
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
