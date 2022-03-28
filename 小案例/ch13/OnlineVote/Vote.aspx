<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vote.aspx.cs" Inherits="Vote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>第十三章：网络在线投票系统===投票</title>
    <link rel="Stylesheet" type="text/css" href="ASPNET2.0BaseCss.css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
		<tr>
			<td><font class="HeaderText">用户投票：</font></td>
		</tr>
		<tr>
			<td><hr style="font-size: 1pt;" /></td>
		</tr>
		<tr>
			<td>
				<asp:GridView ID="VoteView" Width="100%" runat="server" AutoGenerateColumns="False"
					BorderColor="SteelBlue" BorderWidth="1px" BackColor="GradientActiveCaption" 
					CellPadding="3" OnRowDataBound="VoteView_RowDataBound" CssClass="GbText" DataKeyNames="SubjectID,Mode" BorderStyle="None" CellSpacing="1">
					<FooterStyle ForeColor="#8C4510" BackColor="#F7DFB5"></FooterStyle>
					<SelectedRowStyle Font-Bold="True" ForeColor="White" BackColor="#738A9C" BorderColor="CornflowerBlue" />
					<RowStyle ForeColor="DarkBlue" BackColor="#FFF7E7" BorderColor="CornflowerBlue" BorderStyle="Solid"/>
					<HeaderStyle Font-Bold="True" ForeColor="White" CssClass="GbText" BackColor="RoyalBlue"></HeaderStyle>	
				<Columns>
					<asp:TemplateField HeaderText="详细说明">
						<ItemTemplate>
							<%# DataBinder.Eval(Container.DataItem,"Name") %>
							<asp:Panel ID="ItemPanel" runat="server" Width="100%" CssClass="GbText" Direction="LeftToRight"></asp:Panel>												
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
			<td align="center" style="height:30">
				<asp:Button ID="VoteBtn" runat="server" Text="我要投票" CssClass="ButtonCss" OnClick="VoteBtn_Click" Width="200px" />&nbsp;&nbsp;&nbsp;
				<a href="ShowVote.aspx">以表格显示投票信息</a>&nbsp;&nbsp;&nbsp;<a href="ShowVoteByPicture.aspx">以图形显示投票信息</a>
			</td>
		</tr>
		<tr>
			<td></td>
		</tr>
    </table>
    </form>
</body>
</html>

