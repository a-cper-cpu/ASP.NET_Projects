<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DataAdapterDataSet.aspx.cs" Inherits="DataAdapterDataSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_4_3_2:使用DataAdapter对象填充DataSet</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
		<tr>
			<td>显示用户表的所有数据：</td>
		</tr>
		<tr>
			<td><asp:ListBox ID="UserList" runat="server" Height="400px" Width="300px"></asp:ListBox></td>
		</tr>
		<tr>
			<td valign="top"><asp:DropDownList ID="UserOtherList" runat="server" Height="400px" Width="300px"></asp:DropDownList></td>
		</tr>
    </table>
    </form>
</body>
</html>
