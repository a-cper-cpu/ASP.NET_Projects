﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="EmailValidate.aspx.cs" Inherits="RangeValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_7_3_4:Email验证</title>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
		<tr>
			<td align="left"><font color="#006699" size="6" style="font-weight: bold">Email验证:</font></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBox" runat="server"></asp:TextBox>
				<asp:RegularExpressionValidator ID="reInput" runat="server" ControlToValidate="InputBox"
					ErrorMessage="Email的格式不正确！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
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
