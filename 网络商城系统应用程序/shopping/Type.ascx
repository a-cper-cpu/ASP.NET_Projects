<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Type.ascx.cs" Inherits="shopping.Type" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ OutputCache Duration="3000" VaryByParam="selection" %>
<table cellSpacing="0" cellPadding="0" width="145" border="0"  bgcolor=Gainsboro>
	<tr vAlign="top">
		<td vAlign="top" colSpan="2"><FONT face="ËÎÌו"></FONT><A href="default.aspx"></A></td>
	</tr>
	<tr vAlign="top">
		<td><asp:datalist id="MyList" Font-Size="Larger" EnableViewState="False" SelectedItemStyle-BackColor="dimgray"
				width="145px" cellpadding="3" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White"
				GridLines="Vertical" BorderWidth="1px" ShowHeader="False" ShowFooter="False" Font-Underline="True">
				<SelectedItemStyle Font-Size="Medium" Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<SelectedItemTemplate>
					<asp:HyperLink id="HyperLink2" Text='<%# DataBinder.Eval(Container.DataItem, "typeName") %>' NavigateUrl='<%# "wareList.aspx?CategoryID=" + DataBinder.Eval(Container.DataItem, "typeID") + "&selection=" + Container.ItemIndex %>' runat="server" />
				</SelectedItemTemplate>
				<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
				<ItemStyle Font-Underline="True" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<ItemTemplate>
					<asp:HyperLink id="HyperLink1" Text='<%# DataBinder.Eval(Container.DataItem, "typeName") %>' NavigateUrl='<%# "wareList.aspx?CategoryID=" + DataBinder.Eval(Container.DataItem, "typeID") + "&selection=" + Container.ItemIndex %>' runat="server" />
				</ItemTemplate>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
			</asp:datalist></td>
	</tr>
	<tr>
		<td><br>
			<br>
			<br>
			<br>
			<br>
			<br>
			&nbsp;
		</td>
	</tr>
</table>
