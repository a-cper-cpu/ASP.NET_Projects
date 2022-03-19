<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserLoginUC.ascx.cs" Inherits="UserLoginUC" %>
<table cellpadding="0" cellspacing="0" border="1" class="Text" width="200" style="BORDER-COLLAPSE: collapse; background-color: #6699cc;">
	<tr>
		<td style="width: 200px;" align="left"><hr style="width:98%;" size="1" /></td>
	</tr>
	<tr>
		<td style="width: 200px;">&nbsp;<font class="Text">名称：</font><asp:textbox id="UserName" runat="server" cssclass="InputCss" width="150px"></asp:textbox></td>
	</tr>
	<tr>
		<td style="width: 200px;">&nbsp;<font class="Text">密码：</font><asp:textbox id="Password" runat="server" cssclass="InputCss" width="150px" textmode="password"></asp:textbox></td>
	</tr>	
	<tr>
		<td align="left" style="width: 200px;"><asp:Button ID="LoginBtn" runat="server" Text="用户登录" CssClass="ButtonCss" OnClick="LoginBtn_Click1" Width="80px"></asp:Button>
			</td>
	</tr>	
</table>