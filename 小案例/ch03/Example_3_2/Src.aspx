<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Src.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_3_2:Request对象和Respose对象</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
		<tr>
			<td colspan="2">
				<asp:Button ID="DeliverNoParam" runat="server" Text="传送到Dir.aspx（不携带参数）" OnClick="DeliverNoParam_Click" Width="200px" /></td>
		</tr>
		<tr>
			<td style="width: 120px">参数：</td>
			<td>
				<asp:TextBox ID="Data" runat="server"></asp:TextBox></td>
		</tr>		
		<tr>
			<td colspan="2">
				<asp:Button ID="DeliverByParam" runat="server" Text="传送到Dir.aspx（携带参数）" OnClick="Deliver_Click" Width="200px" /></td>
		</tr>
    </table>
    </form>
</body>
</html>
