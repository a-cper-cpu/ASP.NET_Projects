<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Page language="c#" Codebehind="classedit.aspx.cs" AutoEventWireup="false" Inherits="student1.classedit" %>

<HTML>
  <HEAD>
		<title>班级记录更新</title>
		<link href="student.css" rel="stylesheet" type="text/css">
  </HEAD>
	<body text="#000000" link="#000080" vlink="#000080" alink="#000080">
		<form method="post" runat="server" ID="Form1">
			<H:Header id="Header" runat="server" />
			<input type="hidden" id="p_cl_class_id" runat="server" NAME="p_cl_class_id">
			<table align="center" width="400">
				<tr>
					<td width="100%" valign="top" align="center">
						<table id="cl_holder" runat="Server" border="0" cellspacing="1" cellpadding="0" width="100%"
							class="tableBorder1">
							<tr>
								<th background="images/sds01_r2_c8.gif" align="center" height="25">
									<asp:label ID="GridForm_Title" runat="server">班级信息更新</asp:label></th>
							</tr>
							<tr>
								<td width="100%" bgcolor="#ffffff"><table width="100%">
										<tr>
											<td colspan="2">
												<asp:label ID="cl_ValidationSummary" runat="server" Visible="false"></asp:label>
												<input name="Hidden" type="hidden" id="cl_class_id" runat="server">
											</td>
										</tr>
										<tr>
											<td bgcolor=silver>班级名称</td>
											<td>
												<asp:textbox ID="cl_name" Columns="50" MaxLength="50" runat="server" />
											</td>
										</tr>
										<tr>
											<td align="right" colspan="2">
												<input name="button" type="button" id="cl_insert" value="创建" runat="server">
												<input name="button" type="button" id="cl_update" value="更新" runat="server">
												<input name="button" type="button" id="cl_delete" value="删除" runat="server">
												<input name="button" type="button" id="cl_cancel" value="取消" runat="server">
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<center><F:Footer id="Footer" runat="server" /></center>
	</body>
</HTML>
