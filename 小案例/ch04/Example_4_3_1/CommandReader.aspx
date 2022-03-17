<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CommandReader.aspx.cs" Inherits="CommandReader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_4_3_1:使用Command对象和 DataReader对象读取数据</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
		<tr>
			<td>显示用户表的所有数据：</td>
		</tr>
		<tr>
			<td>
				<asp:ListBox ID="UserList" runat="server" Height="400px" Width="300px"></asp:ListBox><asp:ListBox ID="UserOtherList" runat="server" Height="400px" Width="300px"></asp:ListBox></td>
		</tr>
    </table>
    </form>
</body>
</html>
