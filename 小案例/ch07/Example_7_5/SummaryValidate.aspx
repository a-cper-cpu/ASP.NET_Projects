<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="SummaryValidate.aspx.cs" Inherits="SummaryValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_7_5:页面统一验证</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
		<tr>
			<td align="left"><font color="#006699" size="6" style="font-weight: bold">页面统一验证:
			</font></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBox" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfInput" runat="server" ErrorMessage="输入不能为空！" ControlToValidate="InputBox" Display="None"></asp:RequiredFieldValidator>
				<asp:RangeValidator ID="rvInput" runat="server" ControlToValidate="InputBox" ErrorMessage="只能输入在0～100之间！"
					Font-Bold="True" MaximumValue="100" MinimumValue="0" Type="Integer" Display="None"></asp:RangeValidator></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="Email" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfEmail" runat="server" ErrorMessage="输入不能为空！" ControlToValidate="Email" Display="None"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="Email"
					Display="None" ErrorMessage="Email的格式不正确！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="Phone" runat="server"></asp:TextBox>
				<asp:RequiredFieldValidator ID="rfPhone" runat="server" ControlToValidate="Phone"
					ErrorMessage="输入不能为空！" Display="None"></asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="reInput" runat="server" ControlToValidate="Phone"
					ErrorMessage="手机号码格式不正确！" ValidationExpression="(\d{2,3}-){0,1}\d{11}" Display="None"></asp:RegularExpressionValidator></td>
		</tr>
		<tr>
			<td><asp:ValidationSummary
					ID="vsPage" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="ValidateBtn" runat="server" Text="测试验证" OnClick="ValidateBtn_Click" /></td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="ValidateMsg" runat="server"></asp:Label></td>
		</tr>
    </table>
    </form>
</body>
</html>
