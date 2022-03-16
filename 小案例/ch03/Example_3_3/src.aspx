<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="src.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_3_3:Server对象和Global.asax文件</title>
</head>
<body>
    <form id="form1" runat="server">
     <table>		
		<tr>
			<td style="width: 150px">
				参数(请输入中文)：</td>
			<td>
				<asp:TextBox ID="Data" runat="server"></asp:TextBox></td>
		</tr>		
		<tr>
			<td colspan="2">
				<asp:Button ID="DeliverByParam" runat="server" Text="传送到Dir.aspx（已编码参数）" OnClick="Deliver_Click" Width="200px" /></td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Button ID="DeliverNoEncoding" runat="server" Text="传送到Dir.aspx（参数未编码）" Width="200px" OnClick="DeliverNoEncoding_Click" /></td>
		</tr>
    </table>
    </form>
</body>
</html>
