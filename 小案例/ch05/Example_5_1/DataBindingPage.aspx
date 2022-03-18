<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DataBindingPage.aspx.cs" Inherits="DataBindingPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Example_5_1:数据绑定</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
				<tr>
					<td colspan="2">
						绑定Label控件数据：</td>
				</tr>				
				<tr>
					<td><asp:Label ID="LabelData" Runat="server" Text='<%#sLabelData%>'></asp:Label></td>
				</tr>
				<tr>
					<td colspan="2">
						绑定TextBox控件数据：</td>
				</tr>
				<tr>
					<td><asp:TextBox ID="TextBoxData" Runat="server" Text='<%#sTextBoxData%>'></asp:TextBox>
					</td>
				</tr>				
				<tr>
					<td colspan="2">
						绑定Button控件数据：</td>
				</tr>
				<tr>
					<td>
						<asp:Button id="ButtonData" runat="server" Text='<%#sButtonData%>' Width="150px">
						</asp:Button>
					</td>
				</tr>							
				<tr>
					<td><asp:Button id="DataBindBtn" runat="server" Text="绑定各个控件的数据" OnClick="DataBindBtn_Click"></asp:Button>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>
