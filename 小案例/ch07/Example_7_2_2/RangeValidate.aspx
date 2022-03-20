<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="RangeValidate.aspx.cs" Inherits="RangeValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_7_2_2:范围验证</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
		<tr>
			<td align="left"><font color="#006699" size="6" style="font-weight: bold">范围验证:</font></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBox" runat="server"></asp:TextBox>
				<asp:RangeValidator ID="rvInput" runat="server" ControlToValidate="InputBox" ErrorMessage="只能输入在0～100之间！"
					Font-Bold="True" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBoxLetter" runat="server"></asp:TextBox>
				<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="InputBoxLetter" ErrorMessage="只能输入在A～Z之间！"
					Font-Bold="True" MaximumValue="Z" MinimumValue="A"></asp:RangeValidator></td>
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
