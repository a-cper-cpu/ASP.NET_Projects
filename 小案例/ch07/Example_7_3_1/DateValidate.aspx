<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DateValidate.aspx.cs" Inherits="DateValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_7_3_1:日期和时间验证</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
		<tr>
			<td align="left"><font color="#006699" size="6" style="font-weight: bold">日期和时间验证:</font></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBox" runat="server"></asp:TextBox>
				<asp:RangeValidator ID="rvInput" runat="server" ControlToValidate="InputBox" ErrorMessage="只能输入在2006-01-01～2006-12-31之间！"
					Font-Bold="True" MaximumValue="2006-12-31" MinimumValue="2006-01-01" Type="Date" Display="Dynamic"></asp:RangeValidator>
				<asp:RegularExpressionValidator ID="reInput" runat="server" ControlToValidate="InputBox"
					Display="Dynamic" ErrorMessage="日期的格式不正确（2006-01-01）！" Font-Bold="True" ValidationExpression="\d{4}-\d{1,2}-\d{1,2}"></asp:RegularExpressionValidator></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBoxTime" runat="server"></asp:TextBox>
				<asp:RegularExpressionValidator ID="rvInputTime" runat="server" ControlToValidate="InputBoxTime"
					ErrorMessage="日期的格式不正确（2006-01-01 00:00:00）！" Font-Bold="True" ValidationExpression="\d{4}-\d{1,2}-\d{1,2} \d{1,2}:\d{1,2}:\d{1,2}"></asp:RegularExpressionValidator></td>
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
