<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewState.aspx.cs" Inherits="ViewState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_3_1:ASP.NET基本对象概述</title>
</head>
<body>
    <form id="form1" runat="server">    
    <table>
		<tr>
			<td>ViewState对象：</td>
			<td>
				<asp:TextBox ID="Data" runat="server"></asp:TextBox></td>
		</tr>	
		<tr>
			<td>ViewState对象接收到的数据：</td>
			<td>
				<asp:TextBox ID="ReceData" runat="server"></asp:TextBox></td>
		</tr>	
		<tr>
			<td>
				<asp:Button ID="Deliver" runat="server" Text="传送到本页" OnClick="Deliver_Click" Width="100px" /></td>
			<td><asp:Button ID="DeliverOther" runat="server" Text="传送到其他页面" Width="150px" OnClick="DeliverOther_Click" /></td>
		</tr>		
    </table>
    </form>
</body>
</html>
