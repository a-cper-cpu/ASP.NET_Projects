<%@ Page language="c#" Codebehind="stuDetail.aspx.cs" AutoEventWireup="false" Inherits="student1.stuDetail" %>
<%@ Register TagPrefix="H" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="F" TagName="Footer" Src="Footer.ascx" %>
<HTML>
	<HEAD>
		<title>ѧ����ϸ��Ϣ</title>
		<link href="student.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body text="#000000" link="#000080" vlink="#000080" alink="#000080">
		<form method="post" runat="server" ID="Form1">
			<H:Header id="Header" runat="server" />
			<input type="hidden" id="p_Record_student_id" runat="server" NAME="p_Record_emp_id">
			<table align="center">
				<tr>
					<td>
						<table width="574" id="Record_holder" runat="Server" cellspacing="1" class="tableBorder1">
							<tr>
								<th background="images/sds01_r2_c8.gif" align="center" height="35" width="574">
									ѧ����ϸ��Ϣ</th>
							</tr>
							<tr>
								<td background="images/sds01_r2_c8.gif" width="100%">
									<table width="574" align="center">
										<tr bgcolor="lightgrey">
											<td>ϵͳ���</td>
											<td>
												<asp:Label id="Record_student_id" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="#e8f4ff">
											<td>����</td>
											<td>
												<asp:Label id="Record_name" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="lightgrey">
											<td>�Ա�</td>
											<td>
												<asp:Label id="Record_sex" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="#e8f4ff">
											<td>ְ��</td>
											<td>
												<asp:Label id="Record_business" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="lightgrey">
											<td>�༶</td>
											<td>
												<asp:Label id="Record_class_id" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="#e8f4ff">
											<td>Email</td>
											<td>
												<asp:Label id="Record_email" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="lightgrey">
											<td>����绰</td>
											<td>
												<asp:Label id="Record_work_ph" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="#e8f4ff">
											<td>�ƶ��绰</td>
											<td>
												<asp:Label id="Record_mobile_ph" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="lightgrey">
											<td>��ͥ�绰</td>
											<td>
												<asp:Label id="Record_home_ph" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr bgcolor="#e8f4ff">
											<td>��ַ</td>
											<td>
												<asp:Label id="Record_address" runat="server"></asp:Label>
												&nbsp;</td>
										</tr>
										<tr>
											<td align="right" colspan="2"><center>
													<input type="button" id="Record_cancel" Value="����" runat="server" NAME="Record_cancel">
												</center>
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
		<center>
			<F:Footer id="Footer" runat="server" /></center>
	</body>
</HTML>
