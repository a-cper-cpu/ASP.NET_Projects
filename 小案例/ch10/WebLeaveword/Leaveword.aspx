<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Leaveword.aspx.cs" Inherits="LeavewordPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>第10章：留言板===用户留言</title>
	<link href="ASPNET2.0BaseCss.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
		<table width="100%" align="center">
			<tr>
				<td><font size="6">用户留言：</font></td><td align="right"><asp:Button ID="ShowReplyBtn" runat="server" Text="展开留言的回复" CssClass="ButtonCss" OnClick="ShowReplyBtn_Click" CausesValidation="False"/></td>
			</tr>
			<tr>
				<td colspan="2">
					<asp:GridView ID="LeavewordList" CellPadding="4" CssClass="GbText" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="100%" ForeColor="#333333" GridLines="None">
						<Columns>
							<asp:TemplateField>
								<ItemTemplate>
									<table class="GbText" style="border-right: #6699cc 1px solid; border-top: #6699cc 1px solid; border-left: #6699cc 1px solid; border-bottom: #6699cc 1px solid;" width="100%" cellpadding="0" cellspacing="0" border="1">
										<tr>
											<td height="30" style="font-weight: bold; border-bottom: #6699ff thin solid;">主题：<%# DataBinder.Eval(Container.DataItem,"Title") %></td>
										</tr>
										<tr>
											<td><br />&nbsp;&nbsp;&nbsp;&nbsp;<%# FormatBody((String)DataBinder.Eval(Container.DataItem,"Body")) %></td>
										</tr>
										
										<tr>
											<td align="left" style="width:100%"><br /><asp:Panel ID="ReplyPanel" Visible='<%# IsShowReply %>' runat="server" Width="100%"><asp:Label ID="White" runat="server" Width="50"></asp:Label><font color="blue">留言回复：<br /></font><asp:Label ID="Label1" runat="server" Width="50"></asp:Label><font color="green" ><%# DataBinder.Eval(Container.DataItem,"ReplyBody") %></font></asp:Panel><br /></td>
										</tr>
										
										<tr>
											<td align="right" style="width: 100%; position: static;">
												<font class="GbText">留言时间：<%# DataBinder.Eval(Container.DataItem,"CreateTime") %>
												</font>
											</td>
										</tr>
									</table>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
						<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<RowStyle BackColor="#E3EAEB" />
						<EditRowStyle BackColor="#7C6F57" />
						<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
						<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
						<HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
						<AlternatingRowStyle BackColor="White" />
					</asp:GridView>
					</td>
				</tr>			
		</table>
		<table width="100%" align="center" style="background-color: #E3EAEB;">
			<tr>
				<td width="100%"><font class="GbText">IP地址：（<%=IPAddress%>）</font></td>
			</tr>
			<tr>
				<td style="height: 48px"><font class="GbText">留言主题：</font>
					<br>
					<asp:textbox id="Title" Runat="server" CssClass="InputCss" Width="300px"></asp:textbox>
					<font class="GbText" color="red">*</font><asp:RequiredFieldValidator id="rfTitle" runat="server" ErrorMessage="（主题不能为空！！！）" ControlToValidate="Title"
						CssClass="GbText"></asp:RequiredFieldValidator></td>
			</tr>
			<tr>
				<td><font class="Normal">留言内容（内容的长度大于10！）：</font>
					<br>
					<asp:TextBox ID="Body" CssClass="InputCss" Runat="server" TextMode="MultiLine" Width="400px" Height="200px"></asp:TextBox>
				</td>
			</tr>
		</table>
		<table width="100%" align="center" style="background-color: #E3EAEB;">
			<tr>
				<td align="center" width="400"><br>
					<asp:Button ID="SureBtn" Runat="server" CssClass="ButtonCss" Text="我要留言" Width="200px" OnClick="SureBtn_Click"></asp:Button>
					<br>
				</td>
			</tr>
		</table>
	</form>
</body>
</html>
