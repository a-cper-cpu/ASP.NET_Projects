<%@ Control Language="c#" AutoEventWireup="false" Codebehind="likeware.ascx.cs" Inherits="shopping.likeware" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ OutputCache Duration="4000" VaryByParam="None" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0"  bgcolor=Gainsboro>
	<asp:Repeater ID="MostPopularwareList" runat="server">
		<HeaderTemplate>
			<tr>
				<td class="MostPopularHead">
					&nbsp;<FONT face="宋体" size="4">精品推荐</FONT>
				</td>
			</tr>
		</HeaderTemplate>
		<ItemTemplate>
			<tr>
				<td >
					&nbsp;
					<asp:HyperLink Font-Size="14"  NavigateUrl='<%# "wareDetails.aspx?wareID=" + DataBinder.Eval(Container.DataItem, "wareID")%>' Text='<%#DataBinder.Eval(Container.DataItem, "ModelName")%>' runat="server" ID="Hyperlink1" NAME="Hyperlink1"/>
					<br>
				</td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
			<tr>
				<td >
					&nbsp;
				</td>
			</tr>
		</FooterTemplate>
	</asp:Repeater>
</table>
