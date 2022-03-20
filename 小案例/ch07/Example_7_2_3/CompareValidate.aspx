<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CompareValidate.aspx.cs" Inherits="CompareValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_7_2_3:比较验证</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
		<tr>
			<td align="left"><font color="#006699" size="6" style="font-weight: bold">比较验证:</font></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBox" runat="server"></asp:TextBox>
				</td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBoxLetter" runat="server"></asp:TextBox>
				<asp:CompareValidator ID="cvInput" runat="server" ControlToCompare="InputBox"
					ControlToValidate="InputBoxLetter" ErrorMessage="两次输入的密码不相等！"></asp:CompareValidator></td>
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
