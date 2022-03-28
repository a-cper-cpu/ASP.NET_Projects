<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowVoteByPicture.aspx.cs" Inherits="ShowVoteByPicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第十三章：网络在线投票系统===显示投票结果</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">显示投票结果</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="VoteView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="SteelBlue" BorderWidth="1px" BackColor="GradientActiveCaption" 
					CellPadding="3" OnRowDataBound="VoteView_RowDataBound" CssClass="GbText" DataKeyNames="SubjectID" BorderStyle="None" CellSpacing="1">
					<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="DarkBlue" BackColor="#FFF7E7" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="GbText" BackColor="RoyalBlue"></HeaderStyle>	
				<Columns>
					<asp:TemplateField  HeaderText="详细说明">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"Name") %>
							<asp:GridView ID="VoteInfoView" BorderStyle="None" ShowHeader="true" AutoGenerateColumns="false" Width="100%" runat="server">
								<HeaderStyle BorderStyle="Solid" BorderWidth="1" BorderColor="blue" BackColor="RoyalBlue" ForeColor="White" />
							<Columns>
								<asp:TemplateField HeaderText="选择项" ItemStyle-Width="50%">
									<ItemTemplate>
										<%# ((ItemInformation)Container.DataItem).Name %>
									</ItemTemplate>
								</asp:TemplateField>								
								<asp:TemplateField HeaderText="所占总票的百分比" ItemStyle-HorizontalAlign="Left" ItemStyle-BorderWidth="1">
									<ItemStyle Width="300px"></ItemStyle>
									<ItemTemplate>
										<asp:Image ID="voteImage" Runat="server" Height="20" Width='<%# FormatVoteImage(FormatVoteCount(((ItemInformation)Container.DataItem).VoteCount,((ItemInformation)Container.DataItem).SumVoteCount))%>' ImageUrl="Images/vote.gif">
										</asp:Image>
										<%# FormatVoteCount(((ItemInformation)Container.DataItem).VoteCount,((ItemInformation)Container.DataItem).SumVoteCount)%>
										%
									</ItemTemplate>
								</asp:TemplateField>								
								<asp:TemplateField HeaderText="票数"  ItemStyle-Width="20%">
									<ItemTemplate>
										<%# ((ItemInformation)Container.DataItem).VoteCount %>
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
							</asp:GridView>							
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Left" />						
					</asp:TemplateField>								
				</Columns>					
					<PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
					<AlternatingRowStyle BorderColor="#FF8000" BorderWidth="1px" />
				</asp:GridView>
			</td>
		</tr>
		<tr>
			<td></td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>

