<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CustomerValidate.aspx.cs" Inherits="CustomerValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_7_4:自定义验证</title>
</head>
<body>
	<script language="javascript">
		function DivThreeValidate(source,argument)
		{
			if(argument.Value % 3)
			{
				argument.IsVaild = false;
			}
			else
			{
				argument.IsValid = true;
			}
		}			
	</script>
    <form id="form1" runat="server">
    <table cellpadding="5" cellspacing="5" border="0" width="100%">
		<tr>
			<td align="left"><font color="#006699" size="6" style="font-weight: bold">自定义验证:</font></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBox" runat="server"></asp:TextBox>
				<asp:CustomValidator ID="cvInput" runat="server" ControlToValidate="InputBox" ErrorMessage="输入信息不是偶数！" OnServerValidate="cvInput_ServerValidate"></asp:CustomValidator></td>
		</tr>
		<tr>
			<td><asp:TextBox ID="InputBoxLetter" runat="server"></asp:TextBox>
				<asp:CustomValidator ID="cvNumber" runat="server" ControlToValidate="InputBoxLetter"
					ErrorMessage="输入的数字不能整除3！" ClientValidationFunction="DivThreeValidate" ValidateEmptyText="True" OnServerValidate="cvNumber_ServerValidate"></asp:CustomValidator></td>
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
