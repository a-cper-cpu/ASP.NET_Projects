<%@ Page language="c#" Codebehind="adminuser.aspx.cs" AutoEventWireup="false" Inherits="Forum.adminuser" %>
<%@ register tagprefix="T" tagname="Top" src="Top.ascx"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminuser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Forum.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<T:TOP id="Top" runat="server"></T:TOP>
		<form id="Form1" method="post" runat="server">
			<table class="font" align="center" width="300">
				�û�id:<asp:Label id="id" runat="server" />
				<tr>
					<td>�û�����</td>
					<td>
						<asp:TextBox id="UserNametext" runat="server" Columns="20" />(�����޸�)
					</td>
				</tr>
				<tr>
					<td>ǩ��:</td>
					<td>
						<asp:TextBox id="Signtext" runat="server" Columns="20" />
					</td>
				</tr>
				<tr>
					<td>����:</td>
					<td>
						<asp:TextBox id="Passtext" runat="server" Columns="10" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Button id="Button1" Text="���¼�¼" runat="server" />
						<asp:Button id="Button2" Text="ɾ����¼" runat="server"  />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
