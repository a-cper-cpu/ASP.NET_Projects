<%@ Register TagPrefix="F" TagName="Header" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="register.aspx.cs" AutoEventWireup="false" Inherits="Bid.register" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�û�ע��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="bid.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<H:HEADER id="Header" runat="server"></H:HEADER>
		<form id="Form1" method="post" runat="server">
			<table Width="50%" Align="center" CellPadding="0" CellSpacing="0">
				<tr>
					<td>E-Mail</td>
					<td><asp:TextBox ID="txtEmail" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>����</td>
					<td><asp:TextBox ID="txtPwd" TextMode="Password" Runat="server" CssClass="textbox" />
					</td>
				</tr>
				<tr>
					<td>�ظ�����</td>
					<td>
						<asp:TextBox ID="txtPwdConfirm" TextMode="Password" Runat="server" CssClass="textbox" />
					</td>
				</tr>
				<tr>
					<td>����</td>
					<td><asp:TextBox ID="txtName" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>��¼����</td>
					<td><asp:TextBox ID="txtLogin" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>��ַ1</td>
					<td><asp:TextBox ID="txtAdd1" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>��ַ2</td>
					<td><asp:TextBox ID="txtAdd2" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>����</td>
					<td><asp:TextBox ID="txtCity" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>����</td>
					<td><asp:TextBox ID="txtState" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td>�ʱ�</td>
					<td>
						<asp:TextBox ID="txtZip" Runat="server" CssClass="textbox" />
					</td>
				</tr>
				<tr>
					<td>����</td>
					<td><asp:TextBox ID="txtCountry" Runat="server" CssClass="textbox" /></td>
				</tr>
				<tr>
					<td><asp:Button ID="btnSubmit" Text="ȷ��" Runat="server" CssClass="button" />
					</td>
					<td><input id="btnReset" type="reset" Runat="server" class="button" value="ȡ��" NAME="btnReset">
					</td>
				</tr>
				<tr>
					<td colspan="2"><asp:Label ID="lblMsg" Runat="server" /></td>
				</tr>
			</table>
		</form>
		<center><F:Header id="Footer" runat="server" /></center>
	</body>
</HTML>
