<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Resource.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_3_1:ASP.NET基本对象概述</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
		<tr>
			<td style="width: 120px">Application对象：</td>
			<td>
				<asp:TextBox ID="AppData" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td style="width: 120px">Session对象：</td>
			<td>
				<asp:TextBox ID="SesData" runat="server"></asp:TextBox></td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="Deliver" runat="server" Text="传送" OnClick="Deliver_Click" Width="100px" /></td>
		</tr>
    </table>
    </form>
</body>
</html>
