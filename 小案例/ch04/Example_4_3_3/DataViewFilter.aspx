<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DataViewFilter.aspx.cs" Inherits="DataViewFilter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_4_3_3:使用DataView对象</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
		<tr>
			<td>分类显示用户表的数据：</td>
		</tr>
		<tr>
			<td><asp:DropDownList ID="FilterList" runat="server" Height="400px" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="FilterList_SelectedIndexChanged"></asp:DropDownList></td>
		</tr>
		<tr>
			<td valign="top"><asp:ListBox ID="UserList" runat="server" Height="400px" Width="300px"></asp:ListBox></td>
		</tr>
    </table>
    </form>
</body>
</html>
