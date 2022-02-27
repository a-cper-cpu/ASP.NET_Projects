<%@ Page language="c#" Codebehind="speak.aspx.cs" AutoEventWireup="false" Inherits="student1.speak" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<HTML>
	<HEAD>
		<title>留言本</title>
		<LINK href="student.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<H:HEADER id="Header" runat="server" />
		<table width="600" align="center">
			<tr vAlign="top" align="center">
				<td>
					<form id="Form1" method="post" runat="server">
						<ASP:DATAGRID id="DataGrid1" runat="server" BorderColor="black" PagerStyle-HorizontalAlign="Right"
							BorderWidth="1" GridLines="Both" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt"
							HeaderStyle-BackColor="#aaaadd" AlternatingItemStyle-BackColor="#eeeeee" Width="580"></ASP:DATAGRID><BR>
						<table class="tableBorder1" id="Paste_holder" cellSpacing="1" cellPadding="0" width="100%"
							border="0" runat="Server">
							<tr>
								<th align="center" background="images/sds01_r2_c8.gif" height="25">
									信息留言<font color="#ff6633" size="2">(带"*"号的为必填项)</font></th></tr>
							<tr>
								<td bgColor="#ffffff">
									<table>
										<tr>
											<td width="35%">标题:</td>
											<td><asp:textbox id="title" Runat="server" CssClass="input1" MaxLength="25"></asp:textbox><font color="#ff6633" size="2">*</font>
												<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="title" ErrorMessage="此项不能为空"></asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td>签名:</td>
											<td><asp:textbox id="name" Runat="server" CssClass="input1" MaxLength="25"></asp:textbox><font color="#ff6633" size="2">*</font>
												<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="name" ErrorMessage="此项不能为空"></asp:requiredfieldvalidator></td>
										</tr>
										<tr>
											<td>内容:</td>
											<td><asp:textbox id="body" runat="server" Width="250" Height="70" TextMode="Multiline"></asp:textbox></td>
										</tr>
										<tr>
											<td align="center" colSpan="2"><asp:button id="Button1" runat="server" NAME="Button1" Text="提交"></asp:button></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<center><F:FOOTER id="Footer" runat="server" /></center>
	</body>
</HTML>
